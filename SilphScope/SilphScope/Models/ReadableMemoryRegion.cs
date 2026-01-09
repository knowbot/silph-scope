using System;
namespace SilphScope.Models;

public struct ReadableMemoryRegion
{
    public nint BaseAddress { get; set; }
    public nuint Size { get; set; }
}