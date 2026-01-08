using System;
namespace SilphScope.Models;

public struct MemoryRegion
{
    public IntPtr BaseAddress { get; set; }
    public int Size { get; set; }
    public bool IsReadable { get; set; }
}