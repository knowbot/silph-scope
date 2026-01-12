namespace SilphScope.Models;

public struct ReadableMemoryRegion
{
    public nint BaseAddress { get; set; }
    public int Size { get; set; }
}