using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace SilphScope.Models
{
    public class WindowsMemoryAccess : IMemoryAccess
    {
        // memory page state
        private const uint MEM_COMMIT = 0x1000;
        // memory protection
        private static readonly HashSet<uint> PROTECT_READ_FLAGS = [0x02, 0x04, 0x20, 0x40];
        // process access
        private const uint PROCESS_VM_READ = 0x0010;
        private const uint PROCESS_VM_WRITE = 0x0020;

        [StructLayout(LayoutKind.Sequential)]
        private struct MEMORY_BASIC_INFORMATION
        {
            public nint BaseAddress;
            public nint AllocationBase;
            public uint AllocationProtect;
            public nuint RegionSize;
            public uint State;
            public uint Protect;
            public uint lType;
        }

        [DllImport("kernel32.dll")]
        private static extern nint OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(nint hProcess, nint lpBaseAddress, out byte[] lpBuffer, nuint dwSize, ref nuint lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        private static extern int VirtualQueryEx(nint hProcess, nint lpBaseAddress, out MEMORY_BASIC_INFORMATION lpBuffer, nuint dwLength);


        public static IEnumerable<ReadableMemoryRegion> GetMemoryRegions(Process process)
        {
            nint address = 0;
            while (VirtualQueryEx(process.Handle, address, out MEMORY_BASIC_INFORMATION info, (nuint)Marshal.SizeOf<MEMORY_BASIC_INFORMATION>()) != 0)
            {
                if (info.State == MEM_COMMIT && !PROTECT_READ_FLAGS.Contains(info.Protect))
                {
                    if (info.RegionSize == 0)
                    {
                        break;
                    }

                    yield return new ReadableMemoryRegion
                    {
                        BaseAddress = info.BaseAddress,
                        Size = info.RegionSize
                    };
                }
                nint nextAddress = info.BaseAddress + (nint)info.RegionSize;
                if (nextAddress <= address)
                {
                    break;
                }
                address = nextAddress;
            }
        }

        public static byte[] ReadMemory(Process process, nint address, nuint size)
        {
            byte[] buffer = new byte[size];
            nuint bytesRead = 0;
            ReadProcessMemory(process.Handle, address, out buffer, size, ref bytesRead);
            return buffer;
        }
    }
}