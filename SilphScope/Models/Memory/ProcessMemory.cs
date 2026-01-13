using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SilphScope.Models.Memory
{
    public class ProcessMemory<T>(Process process) where T : IMemoryAccess
    {
        private readonly Process _process = process;
       
        public List<nint> PatternScanAll(string pattern)
        {
            List<nint> matches = [];

            foreach (ReadableMemoryRegion region in T.GetMemoryRegions(_process))
            {
                byte[] buffer = T.ReadMemory(_process, region.BaseAddress, region.Size);
                matches.AddRange(PatternScanner.FindAll(buffer, pattern).Select(m => m + region.BaseAddress));
            }
            return matches;
        }
    }
}