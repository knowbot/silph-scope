using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SilphScope.Models.Memory
{
    public class MemoryReader<T>(Process process) where T : IMemoryAccess
    {
        private readonly Process _process = process;

        public nint FindPattern(ReadOnlySpan<byte> pattern)
        {
            return FindPatternAll(pattern).FirstOrDefault();
        }

        public List<nint> FindPatternAll(ReadOnlySpan<byte> pattern)
        {
            List<nint> matches = new List<nint>();

            foreach (ReadableMemoryRegion region in T.GetMemoryRegions(_process))
            {
                byte[] buffer = T.ReadMemory(_process, region.BaseAddress, region.Size);

                // Just perform brute force search (worst case quadratic).
                for (int i = 0; i < buffer.Length - pattern.Length; i++)
                {
                    int j = 0;
                    for (j = 0; j < pattern.Length; j++)
                    {
                        if (buffer[i + j] != pattern[j])
                        {
                            break;
                        }
                    }

                    // Found match?
                    if (j == pattern.Length)
                    {
                        matches.Add(region.BaseAddress + i);
                    }
                }
            }

            return matches;
        }
    }
}