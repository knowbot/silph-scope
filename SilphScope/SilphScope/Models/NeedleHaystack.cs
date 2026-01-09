using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilphScope.Models
{
    public static class NeedleHaystack
    {
        public static nint Bitap(in byte[] pattern, in byte[] buffer)
        {
            if (pattern.Length > 64)
            {
                throw new ArgumentException("Pattern must be shorter than 64 characters");    
            }
            int m = buffer.Length;
            if (m == 0)
                return 0;
            int r = 0; // init bit array to track found elements to all 0
            int[] patternMask = new int[256];
            for (int i = 0; i < patternMask.Length; i++) 
            {
                patternMask[i] = 0; // init all masks to all 0s
            }
            for (int i = 0; i < m; i++)
            {
                patternMask[pattern[i]] &= ~(1 << i); // init masks for symbols in the pattern to be all 0 except 1 in the correct position
            }

            for (int i = 0; i < buffer.Length; i++)
            {
                for (int j = m; j > 0; j--)
                {
                    
                }
            }

            return 0;
        }
    }
}