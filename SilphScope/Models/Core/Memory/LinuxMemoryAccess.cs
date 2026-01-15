using System.Collections.Generic;
using System.Diagnostics;

namespace SilphScope.Models.Core.Memory
{
    public class LinuxMemoryAccess : IMemoryAccess
    {
        public IEnumerable<ReadableMemoryRegion> GetMemoryRegions(Process process)
        {
            throw new System.NotImplementedException();
        }

        public byte[] ReadMemory(Process process, nint address, int size)
        {
            throw new System.NotImplementedException();
        }
    }
}
