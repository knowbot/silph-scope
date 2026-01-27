using System;

namespace SilphScope.Models.Games.Parsers.Common.Text
{
    public interface IDecoder
    {
        /// <summary>
        /// Convert generation-specific encoded data to a UTF-16 string.
        /// </summary>
        /// <param name="encoded">Encoded data</param>
        /// <returns>Decoded UTF-16 string</returns>
        public static abstract string Decode(ReadOnlySpan<byte> encoded);
    }
}
