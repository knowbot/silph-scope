using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SilphScope.Models.Core.Utils;

namespace SilphScope.Models.Core.Memory;

public class ProcessMemory(Process process, IMemoryAccess memoryAccess)
{
    public Process Process => _process;
    private readonly Process _process = process;
    private readonly IMemoryAccess _memoryAccess = memoryAccess;

    public List<nint> PatternScanAll(string pattern)
    {
        List<nint> matches = [];

        foreach (ReadableMemoryRegion region in _memoryAccess.GetMemoryRegions(_process))
        {
            byte[] buffer = _memoryAccess.ReadMemory(_process, region.BaseAddress, region.Size);
            matches.AddRange(PatternScanner.FindAll(buffer, pattern).Select(m => m + region.BaseAddress));
        }
        return matches;
    }

    public byte[] Read(nint address, int size)
    {
        return _memoryAccess.ReadMemory(_process, address, size);
    }
}
