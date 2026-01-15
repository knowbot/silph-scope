using SilphScope.Models.Core.WinNative;
using System.Collections.Generic;
using System.Diagnostics;

namespace SilphScope.Models.Core.Memory
{
    public class WindowsMemoryAccess : IMemoryAccess
    {
        public IEnumerable<ReadableMemoryRegion> GetMemoryRegions(Process process)
        {
            using DisposableProcessHandle handle = new(process, ProcessAccessFlags.VirtualMemoryRead | ProcessAccessFlags.QueryInformation);
            nint address = 0;
            MemoryBasicInformation? maybeInfo;
            while ((maybeInfo = handle.VirtualQuery(address)) != null)
            {
                MemoryBasicInformation info = maybeInfo.Value;

                if (info.State == MemoryBasicInformation.StateEnum.Commit && info.CanReadMemory())
                {
                    if (info.RegionSize == 0)
                    {
                        break;
                    }

                    yield return new ReadableMemoryRegion(info.BaseAddress, (int)info.RegionSize);
                }

                nint nextAddress = info.BaseAddress + info.RegionSize;
                if (nextAddress <= address)
                {
                    break;
                }
                address = nextAddress;
            }
        }

        public byte[] ReadMemory(Process process, nint address, int size)
        {
            using DisposableProcessHandle handle = new(process, ProcessAccessFlags.VirtualMemoryRead);
            byte[] buffer = new byte[size];
            handle.ReadMemory(address, size, buffer);
            return buffer;
        }
    }
}