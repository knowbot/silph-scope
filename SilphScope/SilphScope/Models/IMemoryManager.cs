using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SilphScope.Models;

public interface IMemoryManager
{
    public static abstract IEnumerable<MemoryRegion> GetMemoryRegions(Process process);
    public static abstract byte[] ReadMemory(Process process, IntPtr address, int size);
}