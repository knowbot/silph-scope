using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using static System.MemoryExtensions;

namespace SilphScope.Models
{
    public static class MemoryScanner
    {
        private const int REGISTER_SIZE = 32;
        struct ScanData(byte[] patternBytes, byte[] maskBytes)
        {
            public byte[] PatternBytes = patternBytes;
            public byte[] MaskBytes = maskBytes;
        }

        public static int FindPattern(ReadOnlySpan<byte> data, string pattern)
        {
            if (!Avx2.IsSupported)
            {
                throw new NotSupportedException("Current machine does not support AVX2 instructions.");
            }

            // Preprocessing
            ParsePattern(pattern, out byte[] pBytes, out byte[] mBytes, out int firstByteIndex);
            if(firstByteIndex >= pBytes.Length)
            {
                throw new ArgumentException("Pattern cannot be composed of just wildcards");
            }

            Vector256<byte> firstByteVec = Vector256.Create(pBytes[firstByteIndex]);
            BuildMatchingVectors(ref pBytes[1], ref mBytes[1], pBytes.Length - 1, out Vector256<byte>[] patternVecs, out Vector256<byte>[] maskVecs);

            
            // Find match for first byte
            // On match found, load data in 32bytes chunks
            // data XOR pattern = 0 if match, non-0 if different
            // result AND mask = if match, still 0; if wildcard, still 0; if not match not wildcard, different


            return 0;
        }

        private static Vector256<byte>[] CreateMatchVectors(byte[] pBytes, int leadingWildcards)
        {
            throw new NotImplementedException();
        }

        private static void ParsePattern(string pattern, out byte[] pBytes, out byte[] mBytes, out int leadingWildcards)
        {
            ReadOnlySpan<char> span = pattern.AsSpan().Trim();
            ReadOnlySpan<char> wildcard = ['?', '?'];
            int tokenCount = span.Count(' ') + 1;
            pBytes = new byte[tokenCount];
            mBytes = new byte[tokenCount];
            leadingWildcards = 0;
            bool foundMatch = false;
            int i = 0;
            foreach (Range range in span.Split(' '))
            {
                ReadOnlySpan<char> token = span[range];
                if (token.IsEmpty) continue;
                if (token.Equals(wildcard, StringComparison.Ordinal))
                {
                    if(!foundMatch)
                    {
                        leadingWildcards++;
                    }
                } else
                {
                    pBytes[i] = (byte)((CharToHex(token[0]) << 4) | CharToHex(token[1]));
                    mBytes[i] = 0xFF;
                    foundMatch = true;
                }
                i++;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void BuildMatchingVectors(ref byte pBytesRef, ref byte mBytesRef, int length, out Vector256<byte>[] patternVecs, out Vector256<byte>[] maskVecs)
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
                    patternVecs[i] = Unsafe.ReadUnaligned<Vector256<byte>>(ref Unsafe.Add(ref pBytesRef, offset));
                    maskVecs[i] = Unsafe.ReadUnaligned<Vector256<byte>>(ref Unsafe.Add(ref mBytesRef, offset));
                }
                else
                {
                    int leftoverCount = length - i * 32;
                    Unsafe.CopyBlock(ref MemoryMarshal.GetReference(paddedPattern), ref Unsafe.Add(ref pBytesRef, offset), (uint)leftoverCount);
                    Unsafe.CopyBlock(ref MemoryMarshal.GetReference(paddedMask), ref Unsafe.Add(ref mBytesRef, offset), (uint)leftoverCount);
                    patternVecs[i] = Unsafe.ReadUnaligned<Vector256<byte>>(ref MemoryMarshal.GetReference(paddedPattern));
                    maskVecs[i] = Unsafe.ReadUnaligned<Vector256<byte>>(ref MemoryMarshal.GetReference(paddedMask));
                }
            }
        }

        private static byte CharToHex(char c)
        {
  
            return (byte)((c & 0xF) + (c >> 6) * 9);
        }
    }
}