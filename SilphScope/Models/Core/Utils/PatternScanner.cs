using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using static System.MemoryExtensions;

namespace SilphScope.Models.Core.Utils;

public static class PatternScanner
{
    private const int AVX_REGISTER_SIZE = 32;

    /// <summary>
    /// Scan a byte array for a specific byte pattern, and return all offsets at which a match was found.
    /// </summary>
    /// <param name="data">Byte array to scan.</param>
    /// <param name="patternString">Pattern to find.</param>
    /// <returns>List of offsets from the start of the byte array at whoch a full match starts.</returns>
    /// <exception cref="NotSupportedException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static List<nint> FindAll(ReadOnlySpan<byte> data, string patternString)
    {
        if (!Avx2.IsSupported)
        {
            throw new NotSupportedException("Current machine does not support AVX2 instructions.");
        }

        ParsePattern(patternString, out byte[] pattern, out byte[] mask, out int firstByteIndex);

        if (firstByteIndex >= pattern.Length)
        {
            throw new ArgumentException("Pattern cannot be composed of just wildcards");
        }

        List<nint> matches = [];
        Vector256<byte> firstByteVec = Vector256.Create(pattern[firstByteIndex]);
        BuildMatchingVectors(ref pattern[0], ref mask[0], pattern.Length, out Vector256<byte>[] patternVecs, out Vector256<byte>[] maskVecs);
        ref byte dataRef = ref MemoryMarshal.GetReference(data);
        long searchLength = data.Length - pattern.Length;
        int offset = 0;

        while (offset <= searchLength - AVX_REGISTER_SIZE)
        {
            ref byte searchStart = ref Unsafe.Add(ref dataRef, offset + firstByteIndex);
            Vector256<byte> firstChunk = Vector256.LoadUnsafe(ref searchStart);
            Vector256<byte> compareVec = Avx2.CompareEqual(firstByteVec, firstChunk);
            int result = Avx2.MoveMask(compareVec);
            while (result != 0)
            {
                int pos = BitOperations.TrailingZeroCount(result);
                result &= ~(1 << pos);
                int matchOffset = offset + pos;
                if (matchOffset >= 0 && matchOffset <= searchLength)
                {
                    if (MatchPatternAvx2(ref dataRef, matchOffset, patternVecs, maskVecs))
                    {
                        matches.Add(matchOffset);
                    }
                }
            }
            offset += AVX_REGISTER_SIZE;
        }

        while (offset <= searchLength)
        {
            if (Unsafe.Add(ref dataRef, offset + firstByteIndex) == pattern[firstByteIndex])
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (MatchPatternNaive(ref dataRef, offset, pattern, mask))
                    {
                        matches.Add(offset);
                    }
                }
            }
            offset++;
        }

        return matches;
    }

    /// <summary>
    /// Scan a byte array for a specific byte pattern, and return first offset at which a match was found.
    /// </summary>
    /// <param name="data">Byte array to scan.</param>
    /// <param name="patternString">Pattern to find.</param>
    /// <returns>First offset from the start of the byte array at whoch a full match starts.</returns>
    /// <exception cref="NotSupportedException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static nint FindFirst(ReadOnlySpan<byte> data, string patternString)
    {
        if (!Avx2.IsSupported)
        {
            throw new NotSupportedException("Current machine does not support AVX2 instructions.");
        }

        ParsePattern(patternString, out byte[] pattern, out byte[] mask, out int firstByteIndex);

        if (firstByteIndex >= pattern.Length)
        {
            throw new ArgumentException("Pattern cannot be composed of just wildcards");
        }

        Vector256<byte> firstByteVec = Vector256.Create(pattern[firstByteIndex]);
        BuildMatchingVectors(ref pattern[0], ref mask[0], pattern.Length, out Vector256<byte>[] patternVecs, out Vector256<byte>[] maskVecs);
        ref byte dataRef = ref MemoryMarshal.GetReference(data);
        long searchLength = data.Length - pattern.Length;
        int offset = 0;

        while (offset <= searchLength - AVX_REGISTER_SIZE)
        {
            ref byte searchStart = ref Unsafe.Add(ref dataRef, offset + firstByteIndex);
            Vector256<byte> firstChunk = Vector256.LoadUnsafe(ref searchStart);
            Vector256<byte> compareVec = Avx2.CompareEqual(firstByteVec, firstChunk);
            int result = Avx2.MoveMask(compareVec);
            while (result != 0)
            {
                int pos = BitOperations.TrailingZeroCount(result);
                result &= ~(1 << pos);
                int matchOffset = offset + pos;
                if (matchOffset >= 0 && matchOffset <= searchLength)
                {
                    if (MatchPatternAvx2(ref dataRef, matchOffset, patternVecs, maskVecs))
                    {
                        return matchOffset;
                    }
                }
            }
            offset += AVX_REGISTER_SIZE;
        }

        while (offset <= searchLength)
        {
            if (Unsafe.Add(ref dataRef, offset + firstByteIndex) == pattern[firstByteIndex])
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (MatchPatternNaive(ref dataRef, offset, pattern, mask))
                    {
                        return offset;
                    }
                }
            }
            offset++;
        }

        return 0;
    }

    /// <summary>
    /// Check if there is a full match for the desired pattern starting at a certain offset using Avx2 instructions for speed.
    /// </summary>
    /// <param name="dataRef">Reference to the start of the byte array.</param>
    /// <param name="matchOffset">Offset of the potential match.</param>
    /// <param name="patternVecs">Vectors containing the pattern bytes in 32-byte chunks.</param>
    /// <param name="maskVecs">Vectors containing the mask bytes in 32-byte chunks.</param>
    /// <returns>True if there is a full match starting at matchOffset, false otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool MatchPatternAvx2(ref byte dataRef, int matchOffset, Vector256<byte>[] patternVecs, Vector256<byte>[] maskVecs)
    {
        for (int i = 0; i < patternVecs.Length; i++)
        {
            ref byte matchStart = ref Unsafe.Add(ref dataRef, matchOffset + (i * AVX_REGISTER_SIZE));
            Vector256<byte> matchChunk = Vector256.LoadUnsafe(ref matchStart);
            Vector256<byte> diff = Avx2.Xor(patternVecs[i], matchChunk);
            if (!Avx2.TestZ(diff, maskVecs[i]))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Check if there is a full match for the desired pattern starting at a certain offset, naive approach.
    /// </summary>
    /// <param name="dataRef">Reference to the start of the byte array.</param>
    /// <param name="matchOffset">Offset of the potential match.</param>
    /// <param name="pattern">Byte array representing the pattern.</param>
    /// <param name="mask">Byte array representing the matching mask.</param>
    /// <returns>True if there is a full match starting at matchOffset, false otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool MatchPatternNaive(ref byte dataRef, int matchOffset, byte[] pattern, byte[] mask)
    {
        for (int i = 0; i < pattern.Length; i++)
        {
            if (mask[i] != 0 && Unsafe.Add(ref dataRef, matchOffset + i) != pattern[i])
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Parse a string into a byte pattern and a matching mask.
    /// </summary>
    /// <param name="patternString">Input string to parse.</param>
    /// <param name="pattern">Byte array representing the pattern, wildcards are translated as 0x0.</param>
    /// <param name="mask">Byte array representing the matching mask for each token of the pattern (0x00 if byte, 0xFF if wildcard).</param>
    /// <param name="leadingWildcards">Amount of wildcards at the start of the pattern.</param>
    private static void ParsePattern(string patternString, out byte[] pattern, out byte[] mask, out int leadingWildcards)
    {
        ReadOnlySpan<char> span = patternString.AsSpan().Trim();
        ReadOnlySpan<char> wildcard = ['?', '?'];
        int tokenCount = span.Count(' ') + 1;
        pattern = new byte[tokenCount];
        mask = new byte[tokenCount];
        leadingWildcards = 0;
        bool foundFirstByte = false;
        int i = 0;
        foreach (Range range in span.Split(' '))
        {
            ReadOnlySpan<char> token = span[range];
            if (token.IsEmpty)
                continue;
            if (token.Equals(wildcard, StringComparison.Ordinal))
            {
                if (!foundFirstByte)
                {
                    leadingWildcards++;
                }
            }
            else
            {
                pattern[i] = (byte)((CharToHexByte(token[0]) << 4) | CharToHexByte(token[1]));
                mask[i] = 0xFF;
                foundFirstByte = true;
            }
            i++;
        }
    }

    /// <summary>
    /// Load the pattern and the mask into 32-byte vectors for SIMD operations.
    /// </summary>
    /// <param name="patternRef">Reference to the start of the pattern byte array.</param>
    /// <param name="maskRef">Reference to the start of the mask byte array.</param>
    /// <param name="length">Pattern length.</param>
    /// <param name="patternVecs">Vectors representing the pattern.</param>
    /// <param name="maskVecs">Vectors representing the mask.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void BuildMatchingVectors(ref byte patternRef, ref byte maskRef, int length, out Vector256<byte>[] patternVecs, out Vector256<byte>[] maskVecs)
    {
        int vecCount = (int)Math.Ceiling(length / (float)AVX_REGISTER_SIZE);
        patternVecs = new Vector256<byte>[vecCount];
        maskVecs = new Vector256<byte>[vecCount];
        Span<byte> paddedPattern = stackalloc byte[AVX_REGISTER_SIZE];
        Span<byte> paddedMask = stackalloc byte[AVX_REGISTER_SIZE];

        for (int i = 0; i < vecCount; i++)
        {
            int offset = i * AVX_REGISTER_SIZE;
            if (i < vecCount - 1)
            {
                patternVecs[i] = Vector256.LoadUnsafe(ref Unsafe.Add(ref patternRef, offset));
                maskVecs[i] = Vector256.LoadUnsafe(ref Unsafe.Add(ref maskRef, offset));
            }
            else
            {
                int leftoverCount = length - (i * AVX_REGISTER_SIZE);
                paddedPattern.Clear();
                paddedMask.Clear();
                Unsafe.CopyBlock(ref MemoryMarshal.GetReference(paddedPattern), ref Unsafe.Add(ref patternRef, offset), (uint)leftoverCount);
                Unsafe.CopyBlock(ref MemoryMarshal.GetReference(paddedMask), ref Unsafe.Add(ref maskRef, offset), (uint)leftoverCount);
                patternVecs[i] = Vector256.LoadUnsafe(ref MemoryMarshal.GetReference(paddedPattern));
                maskVecs[i] = Vector256.LoadUnsafe(ref MemoryMarshal.GetReference(paddedMask));
            }
        }
    }

    /// <summary>
    /// Simple inline char to byte conversion.
    /// </summary>
    /// <param name="c">Char (0-9, A-F, a-f).</param>
    /// <returns>Hex value of c in byte form.</returns>
    private static byte CharToHexByte(char c)
    {
        return (byte)((c & 0xF) + ((c >> 6) * 9));
    }
}
