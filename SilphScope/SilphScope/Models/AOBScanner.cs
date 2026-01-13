using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using static System.MemoryExtensions;

namespace SilphScope.Models
{
    public static class AOBScanner
    {
        private const int REGISTER_SIZE = 32;

        public static List<nint> FindAll(ReadOnlySpan<byte> data, string patternString)
        {
            if (!Avx2.IsSupported)
            {
                throw new NotSupportedException("Current machine does not support AVX2 instructions.");
            }

            ParsePattern(patternString, out byte[] pattern, out byte[] mask, out int firstByteIndex);

            if(firstByteIndex >= pattern.Length)
            {
                throw new ArgumentException("Pattern cannot be composed of just wildcards");
            }

            List<nint> matches = [];
            Vector256<byte> firstByteVec = Vector256.Create(pattern[firstByteIndex]);
            BuildMatchingVectors(ref pattern[0], ref mask[0], pattern.Length, out Vector256<byte>[] patternVecs, out Vector256<byte>[] maskVecs);
            ref byte dataRef = ref MemoryMarshal.GetReference(data);
            long searchLength = data.Length - pattern.Length;
            int offset = 0;

            while(offset <= searchLength - 32)
            {
                ref byte searchStart = ref Unsafe.Add(ref dataRef, offset + firstByteIndex);
                Vector256<byte> firstChunk = Vector256.LoadUnsafe(ref searchStart);
                Vector256<byte> compareVec = Avx2.CompareEqual(firstByteVec, firstChunk);
                int result = Avx2.MoveMask(compareVec);
                while (result != 0) {
                    int pos = BitOperations.TrailingZeroCount(result);
                    result &= ~(1 << pos);
                    int matchOffset = offset + pos;
                    if (matchOffset >= 0 && matchOffset <= searchLength)
                    {
                        if(MatchPatternAvx2(ref dataRef, matchOffset, patternVecs, maskVecs))
                        {
                            matches.Add(matchOffset);
                        }
                    }
                }
                offset += 32;
            }

            while(offset <= searchLength)
            {
                if(Unsafe.Add(ref dataRef, offset + firstByteIndex) == pattern[firstByteIndex])
                {
                    for (int i = 0; i < pattern.Length; i++)
                    {
                        if (MatchPatternScalar(ref dataRef, offset, pattern, mask))
                        {
                            matches.Add(offset);
                        }
                    }
                }
                offset++;
            }

            return matches;
        }

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

            while (offset <= searchLength - 32)
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
                offset += 32;
            }

            while (offset <= searchLength)
            {
                if (Unsafe.Add(ref dataRef, offset + firstByteIndex) == pattern[firstByteIndex])
                {
                    for (int i = 0; i < pattern.Length; i++)
                    {
                        if (MatchPatternScalar(ref dataRef, offset, pattern, mask))
                        {
                            return offset;
                        }
                    }
                }
                offset++;
            }

            return 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool MatchPatternAvx2(ref byte dataRef, int matchOffset, Vector256<byte>[] patternVecs, Vector256<byte>[] maskVecs)
        {
            for (int i = 0; i < patternVecs.Length; i++)
            {
                ref byte matchStart = ref Unsafe.Add(ref dataRef, matchOffset + (i * 32));
                Vector256<byte> matchChunk = Vector256.LoadUnsafe(ref matchStart);
                Vector256<byte> diff = Avx2.Xor(patternVecs[i], matchChunk);
                if (!Avx2.TestZ(diff, maskVecs[i]))
                {
                    return false;
                }
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool MatchPatternScalar(ref byte dataRef, int matchOffset, byte[] pattern, byte[] mask)
        {
            for (int i = 0; i < pattern.Length; i++) // check entire pattern
            {
                if (mask[i] != 0 && Unsafe.Add(ref dataRef, matchOffset + i) != pattern[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static void ParsePattern(string pattern, out byte[] pBytes, out byte[] mBytes, out int leadingWildcards)
        {
            ReadOnlySpan<char> span = pattern.AsSpan().Trim();
            ReadOnlySpan<char> wildcard = ['?', '?'];
            int tokenCount = span.Count(' ') + 1;
            pBytes = new byte[tokenCount];
            mBytes = new byte[tokenCount];
            leadingWildcards = 0;
            bool foundFirstByte = false;
            int i = 0;
            foreach (Range range in span.Split(' '))
            {
                ReadOnlySpan<char> token = span[range];
                if (token.IsEmpty) continue;
                if (token.Equals(wildcard, StringComparison.Ordinal))
                {
                    if(!foundFirstByte)
                    {
                        leadingWildcards++;
                    }
                } else
                {
                    pBytes[i] = (byte)((CharToHex(token[0]) << 4) | CharToHex(token[1]));
                    mBytes[i] = 0xFF;
                    foundFirstByte = true;
                }
                i++;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void BuildMatchingVectors(ref byte patternRef, ref byte maskRef, int length, out Vector256<byte>[] patternVecs, out Vector256<byte>[] maskVecs)
        {
            int vecCount = (int)(Math.Ceiling(length / (double)REGISTER_SIZE));
            patternVecs = new Vector256<byte>[vecCount];
            maskVecs = new Vector256<byte>[vecCount];
            Span<byte> paddedPattern = stackalloc byte[32];
            Span<byte> paddedMask = stackalloc byte[32];

            for (int i = 0; i < vecCount; i++)
            {
                int offset = i * REGISTER_SIZE;
                if (i < vecCount - 1)
                {
                    patternVecs[i] = Vector256.LoadUnsafe(ref Unsafe.Add(ref patternRef, offset));
                    maskVecs[i] = Vector256.LoadUnsafe(ref Unsafe.Add(ref maskRef, offset));
                }
                else
                {
                    int leftoverCount = length - i * 32;
                    paddedPattern.Clear();
                    paddedMask.Clear();
                    Unsafe.CopyBlock(ref MemoryMarshal.GetReference(paddedPattern), ref Unsafe.Add(ref patternRef, offset), (uint)leftoverCount);
                    Unsafe.CopyBlock(ref MemoryMarshal.GetReference(paddedMask), ref Unsafe.Add(ref maskRef, offset), (uint)leftoverCount);
                    patternVecs[i] = Vector256.LoadUnsafe(ref MemoryMarshal.GetReference(paddedPattern));
                    maskVecs[i] = Vector256.LoadUnsafe(ref MemoryMarshal.GetReference(paddedMask));
                }
            }
        }
        
        private static byte CharToHex(char c)
        {
            return (byte)((c & 0xF) + (c >> 6) * 9);
        }
    }
}