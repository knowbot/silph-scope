using System;
using System.Runtime.InteropServices;

namespace SilphScope.Models.Extensions
{
    public static class SpanExtensions
    {
        public static T Read<T>(this ReadOnlySpan<byte> span, int offset = 0) where T : struct
        {
            return offset > span.Length ? throw new ArgumentOutOfRangeException(nameof(offset)) : MemoryMarshal.Read<T>(span[offset..]);
        }

        public static T Read<T>(this Span<byte> span, int offset = 0) where T : struct
        {
            return offset > span.Length ? throw new ArgumentOutOfRangeException(nameof(offset)) : MemoryMarshal.Read<T>(span[offset..]);
        }
    }
}
