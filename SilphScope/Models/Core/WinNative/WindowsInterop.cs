using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SilphScope.Models.Core.WinNative
{
    public static class WindowsInterop
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern nint OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(nint handle);

        [DllImport("kernel32.dll")]
        private static extern int VirtualQueryEx(nint hProcess, nint lpAddress, out MemoryBasicInformation lpBuffer, uint dwLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(nint hProcess, nint lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out nint lpNumberOfBytesRead);

        public static nint OpenProcess(Process process, ProcessAccessFlags flags)
        {
            nint res = OpenProcess(flags, false, process.Id);
            if (res == 0)
            {
                CheckResult();
            }
            return res;
        }

        public static void CloseProcess(nint handle)
        {
            if (!CloseHandle(handle))
            {
                CheckResult();
            }
        }

        public static MemoryBasicInformation? VirtualQueryEx(nint handle, nint address)
        {
            if (VirtualQueryEx(handle, address, out MemoryBasicInformation info, (uint)Marshal.SizeOf<MemoryBasicInformation>()) == 0)
            {
                CheckResult();
                return null;
            }
            return info;
        }

        public static void ReadProcessMemory(nint handle, nint address, byte[] buffer, int size, out long bytesRead)
        {
            if (!ReadProcessMemory(handle, address, buffer, size, out nint bytesReadPtr))
            {
                CheckResult();
            }
            bytesRead = bytesReadPtr;
        }

        private static void CheckResult()
        {
            int error = Marshal.GetLastWin32Error();
            if (error != 0)
            {
                throw new Win32Exception(error);
            }
        }
    }
}
