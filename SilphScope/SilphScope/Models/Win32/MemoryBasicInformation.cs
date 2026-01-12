using System;
using System.Runtime.InteropServices;

namespace SilphScope.Models.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryBasicInformation
    {
        public enum AllocationProtectEnum : uint
        {
            Execute = 0x00000010,
            ExecuteRead = 0x00000020,
            ExecuteReadWrite = 0x00000040,
            ExecuteWriteCopy = 0x00000080,
            NoAccess = 0x00000001,
            ReadOnly = 0x00000002,
            ReadWrite = 0x00000004,
            WriteCopy = 0x00000008,
            Guard = 0x00000100,
            NoCache = 0x00000200,
            WriteCombine = 0x00000400
        }

        public enum StateEnum : uint
        {
            Commit = 0x1000,
            Free = 0x10000,
            Reserve = 0x2000
        }

        public enum TypeEnum : uint
        {
            Image = 0x1000000,
            Mapped = 0x40000,
            Private = 0x20000
        }

        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public uint AllocationProtect;
        public IntPtr RegionSize;
        public StateEnum State;
        public AllocationProtectEnum Protect;
        public TypeEnum Type;

        public bool CanReadMemory()
        {
            return Protect == AllocationProtectEnum.ReadWrite || Protect == AllocationProtectEnum.ReadOnly || Protect == AllocationProtectEnum.ExecuteRead || Protect == AllocationProtectEnum.ExecuteReadWrite;
        }
    }
}
