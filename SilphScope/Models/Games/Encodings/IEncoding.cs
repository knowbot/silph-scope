using System;

namespace SilphScope.Models.Games.Strings
{
    public interface IEncoding
    {
        /// <summary>
        /// Convert generation-specific encoded data to a UTF-16 string.
        /// </summary>
        /// <param name="encoded">Encoded data</param>
        /// <returns>Decoded UTF-16 string</returns>
        public abstract static string Decode(ReadOnlySpan<byte> encoded);
    }
}
