using System.Collections.Generic;
using System.Diagnostics;

namespace SilphScope.Models.Core.Memory;

public interface IMemoryAccess
{
    abstract IEnumerable<ReadableMemoryRegion> GetMemoryRegions(Process process);
    abstract byte[] ReadMemory(Process process, nint address, int size);
}
