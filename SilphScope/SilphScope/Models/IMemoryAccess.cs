using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SilphScope.Models;
public interface IMemoryAccess
{
    public static abstract IEnumerable<ReadableMemoryRegion> GetMemoryRegions(Process process);
    public static abstract byte[] ReadMemory(Process process, nint address, nuint size);
}