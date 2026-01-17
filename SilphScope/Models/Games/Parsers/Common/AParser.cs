using System;
using System.Runtime.InteropServices;

namespace SilphScope.Models.Games.Parsers.Common
{
    public abstract class AParser
    {
        protected static T ReadAt<T>(ReadOnlySpan<byte> span, int offset = 0) where T : struct
        {
            return MemoryMarshal.Read<T>(span[offset..]);
        }
    }
}
