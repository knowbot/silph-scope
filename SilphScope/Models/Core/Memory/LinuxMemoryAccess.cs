using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using SilphScope.Models.Core.LinuxNative;

namespace SilphScope.Models.Core.Memory;

public partial class LinuxMemoryAccess : IMemoryAccess
{
    // Regex pattern matching: "%016llx-%016llx %c%c%c%c %08llx %02x:%02x %lu%*[^\n]%c"
    [GeneratedRegex(@"^([0-9a-fA-F]+)-([0-9a-fA-F]+)\s+([rwxp-]{4})\s+([0-9a-fA-F]+)\s+([0-9a-fA-F]{2}:[0-9a-fA-F]{2})\s+(\d+)\s*(.*)$")]
    private static partial Regex ProcMapsPattern();

    public IEnumerable<ReadableMemoryRegion> GetMemoryRegions(Process process)
    {
        // Open the /proc/.../maps file to read memory pages.
        using FileStream file = File.Open($"/proc/{process.Id}/maps", FileMode.Open, FileAccess.Read);
        using StreamReader reader = new(file);

        string? line = null;
        while ((line = reader.ReadLine()) != null)
        {
            var match = ProcMapsPattern().Match(line);

            // Should never happen but oh well.
            if (!match.Success)
            {
                break;
            }

            var start = ulong.Parse(match.Groups[1].Value, NumberStyles.HexNumber);
            var end = ulong.Parse(match.Groups[2].Value, NumberStyles.HexNumber);
            var permissionsString = match.Groups[3].Value;
            LinuxMemoryArea.Permissions permissions = LinuxMemoryArea.Permissions.None;
            if (permissionsString[0] == 'r')
            {
                permissions |= LinuxMemoryArea.Permissions.Read;
            }
            if (permissionsString[1] == 'w')
            {
                permissions |= LinuxMemoryArea.Permissions.Write;
            }
            if (permissionsString[2] == 'x')
            {
                permissions |= LinuxMemoryArea.Permissions.Execute;
            }
            LinuxMemoryArea.Owner owner = permissionsString[3] == 'p' ? LinuxMemoryArea.Owner.Private : LinuxMemoryArea.Owner.Shared;

            var area = new LinuxMemoryArea((nint)start, (int)(end - start), permissions, owner);
            if (area.CanReadMemory())
            {
                yield return new ReadableMemoryRegion(area.BaseAddress, area.RegionSize);
            }
        }
    }

    public byte[] ReadMemory(Process process, nint address, int size)
    {
        byte[] buffer = new byte[size];
        LinuxInterop.ProcessReadVirtualMemory(process, address, (nuint)size, buffer);
        return buffer;
    }
}
