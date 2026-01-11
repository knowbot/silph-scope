using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace SilphScope.Models
{
    struct PatternData
    {
        private static readonly char[] _wildcard = {'?', '?'};
        public byte[] Bytes;
        public byte[] Mask;
        public readonly int LeadingWildcards = 0;

        public PatternData(string pattern)
        {
            List<byte> bytes = [];
            List<byte> mask = [];
            ReadOnlySpan<char> patternSpan = pattern.AsSpan();
            foreach (Range range in patternSpan.Split(' '))
            {
                if(patternSpan[range].Equals(_wildcard, StringComparison.Ordinal))
                {
                    bytes.Add(0x0);
                    mask.Add(0x0);
                } 
                else
                {
                    bytes.Add(byte.Parse(patternSpan[range], System.Globalization.NumberStyles.AllowHexSpecifier));
                    mask.Add(0x1);
                }
            }
            Bytes = [.. bytes];
            Mask = [.. mask];
            LeadingWildcards = Array.IndexOf(Mask, 0x1);
        }
    }

    public class MemoryScanner
    {
        public static int FindPattern(ReadOnlySpan<byte> data, string pattern)
        {
            if (!Avx2.IsSupported)
            {
                throw new NotSupportedException("Current machine does not support AVX2 instructions.");
            }

            PatternData patternData = new(pattern);

            if(patternData.Bytes.Length == 1) // Single byte pattern
            {
                throw new NotImplementedException("Single byte pattern scanning is not implemented yet.");
            }

            if(patternData.Bytes.Length == patternData.LeadingWildcards) // All wildcards
            {
                return 0;
            }

            // Make array with first non-wildcard byte
            // Loop over memory in 32 byte chunks to find a match
            // Once a match is found, check the rest of the pattern including wildcards
            // Start of search = data start + leading wildcards
            // End of search = data end - (pattern length - leading wildcards)
            
            return 0;
        }

        private static Span<ushort> GetNonWildcardIndices(PatternData pattern)
        {
            int maskLength = pattern.Mask.Length;
            ushort[] nwTable = new ushort[maskLength];
            int nwCount = 0;
            for(int i = 1; i < maskLength; i ++)
            {
                if(pattern.Mask[i] != 0x1) // Wildcard
                {
                    continue;
                }
                nwTable[i] = (ushort)(i - 1); // Shift by 1 cause we skip the first byte
                nwCount++;
            }
            return new Span<ushort>(nwTable)[..nwCount];
        }
        

    }
}