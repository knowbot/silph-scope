using SilphScope.Models.Core.Utils;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SilphScope.Models.Core.Memory
{
    public class ProcessMemory(Process process, IMemoryAccess memoryAccess)
    {
        private readonly Process process = process;
        private readonly IMemoryAccess memoryAccess = memoryAccess;

        public List<nint> PatternScanAll(string pattern)
        {
            List<nint> matches = [];

            foreach (ReadableMemoryRegion region in memoryAccess.GetMemoryRegions(process))
            {
                byte[] buffer = memoryAccess.ReadMemory(process, region.BaseAddress, region.Size);
                matches.AddRange(PatternScanner.FindAll(buffer, pattern).Select(m => m + region.BaseAddress));
            }
            return matches;
        }

        public byte[] Read(nint address, int size)
        {
            return memoryAccess.ReadMemory(process, address, size);
        }
    }
}