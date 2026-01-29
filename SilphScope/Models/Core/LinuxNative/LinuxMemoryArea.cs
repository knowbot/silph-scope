using System;

namespace SilphScope.Models.Core.LinuxNative
{
    public readonly struct LinuxMemoryArea
    {
        [Flags]
        public enum Permissions
        {
            None = 0,
            Read = 1,
            Write = 2,
            Execute = 4
        }

        public enum Owner
        {
            Shared,
            Private
        }

        public readonly nint BaseAddress;
        public readonly int RegionSize;
        public readonly Permissions Perm;
        public readonly Owner Own;

        public LinuxMemoryArea(nint baseAddress, int regionSize, Permissions perm, Owner own)
        {
            BaseAddress = baseAddress;
            RegionSize = regionSize;
            Perm = perm;
            Own = own;
        }

        public bool CanReadMemory()
        {
            return (Perm & Permissions.Read) == Permissions.Read;
        }
    }
}