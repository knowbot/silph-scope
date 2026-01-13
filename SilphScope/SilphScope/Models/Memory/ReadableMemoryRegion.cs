namespace SilphScope.Models.Memory
{
    public readonly record struct ReadableMemoryRegion(nint baseAddress, int size)
    {
        public readonly nint BaseAddress = baseAddress;
        public readonly int Size = size;
    }
}
