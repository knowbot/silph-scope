using System.Diagnostics;

namespace SilphScope.Models.Core.WinNative;

public class DisposableProcessHandle : TracingDisposable
{
    private readonly nint _handle;

    public DisposableProcessHandle(Process process, ProcessAccessFlags flags)
    {
        _handle = WindowsInterop.OpenProcess(process, flags);
    }

    public MemoryBasicInformation? VirtualQuery(nint address)
    {
        return WindowsInterop.VirtualQueryEx(_handle, address);
    }

    public void ReadMemory(nint address, int size, byte[] buffer)
    {
        WindowsInterop.ReadProcessMemory(_handle, address, buffer, size, out _);
    }

    protected override void Dispose(bool disposing)
    {
        WindowsInterop.CloseProcess(_handle);
        base.Dispose(disposing);
    }
}
