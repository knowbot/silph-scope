using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SilphScope.Models
{
    public class MemoryManager<T>(Process process) where T : IMemoryAccess
    {
        private readonly Process _process = process;

        public byte[] ReadMemory(nint address, nuint size) => T.ReadMemory(_process, address, size);
        // TODO: add other useful methods such as ReadInt, ReadBool, etc

        public nint FindPattern(ReadOnlySpan<byte> pattern)
        {
            nint first = 0;
            foreach (var region in T.GetMemoryRegions(_process))
            {
                ReadOnlySpan<byte> buffer = T.ReadMemory(_process, region.BaseAddress, region.Size);
                // TODO: scan for pattern inside of buffer
            }
            return first;
        }

        public List<nint> FindPatternAll(ReadOnlySpan<byte> pattern)
        {
            List<nint> matches = [];
            foreach (var region in T.GetMemoryRegions(_process))
            {
                ReadOnlySpan<byte> buffer = T.ReadMemory(_process, region.BaseAddress, region.Size);
                // TODO: scan for pattern inside of buffer
            }
            return matches;
        }
    }
}