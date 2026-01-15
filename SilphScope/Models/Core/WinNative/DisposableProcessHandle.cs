using SilphScope.Models.Core;
using System.Diagnostics;

namespace SilphScope.Models.Core.WinNative
{
    public class DisposableProcessHandle : TracingDisposable
    {
        private readonly nint handle;

        public DisposableProcessHandle(Process process, ProcessAccessFlags flags)
        {
            handle = WindowsInterop.OpenProcess(process, flags);
        }

        public MemoryBasicInformation? VirtualQuery(nint address)
        {
            return WindowsInterop.VirtualQueryEx(handle, address);
        }

        public void ReadMemory(nint address, int size, byte[] buffer)
        {
            WindowsInterop.ReadProcessMemory(handle, address, buffer, size, out _);
        }

        protected override void Dispose(bool disposing)
        {
            WindowsInterop.CloseProcess(handle);
            base.Dispose(disposing);
        }
    }
}
