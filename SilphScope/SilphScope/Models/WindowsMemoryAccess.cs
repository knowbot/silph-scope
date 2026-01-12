using SilphScope.Models.Win32;
using System.Collections.Generic;
using System.Diagnostics;

namespace SilphScope.Models
{
    public class WindowsMemoryAccess : IMemoryAccess
    {
        public static IEnumerable<ReadableMemoryRegion> GetMemoryRegions(Process process)
        {
            using (DisposableProcessHandle handle = new DisposableProcessHandle(process, ProcessAccessFlags.VirtualMemoryRead | ProcessAccessFlags.QueryInformation))
            {
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

                        yield return new ReadableMemoryRegion
                        {
                            BaseAddress = info.BaseAddress,
                            Size = (int)info.RegionSize
                        };
                    }

                    nint nextAddress = info.BaseAddress + info.RegionSize;
                    if (nextAddress <= address)
                    {
                        break;
                    }
                    address = nextAddress;
                }
            }
        }

        public static byte[] ReadMemory(Process process, nint address, int size)
        {
            using (DisposableProcessHandle handle = new DisposableProcessHandle(process, ProcessAccessFlags.VirtualMemoryRead))
            {
                byte[] buffer = new byte[size];
                handle.ReadMemory(address, size, buffer);
                return buffer;
            }
        }
    }
}