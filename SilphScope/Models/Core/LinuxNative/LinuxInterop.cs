using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SilphScope.Models.Core.LinuxNative
{
    public static partial class LinuxInterop
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct IOVec(nint baseAddress, nuint length)
        {
            public nint BaseAddress = baseAddress;
            public nuint Length = length;
        }

        [LibraryImport("libc", SetLastError = true)]
        private static unsafe partial nint process_vm_readv(int pid, IOVec* localAreas, CULong localAreasCount, IOVec* remoteAreas, CULong remoteAreasCount, CULong flags);

        public static unsafe void ProcessReadVirtualMemory(Process process, nint offset, nuint size, byte[] buffer)
        {
            fixed (byte* bufferPtr = &buffer[0])
            {
                IOVec localBuffer = new((nint)bufferPtr, size);
                IOVec remoteBuffer = new(offset, size);
                var res = process_vm_readv(process.Id, &localBuffer, new(1), &remoteBuffer, new(1), new(0));

                // NOTE(Riccardo): something went wrong. Apparently, under Linux, it is entirely possible for
                // one of the call to fail if the memory is somehow protected by the kernel. I did not find a way
                // to distinguish this failure from other failures, so I will hope the caller of this method
                // was in good faith and clear the array.
                //
                // This is absolutely horrible.
                if (res < (nint)size)
                {
                    Array.Clear(buffer);
                }
            }
        }

        private static void CheckResult()
        {
            int error = Marshal.GetLastPInvokeError();
            if (error != 0)
            {
                throw new Win32Exception(error);
            }
        }
    }
}