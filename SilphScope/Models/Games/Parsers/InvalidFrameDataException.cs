using System;

namespace SilphScope.Models.Games.Parsers
{
    [Serializable]
    public class InvalidFrameDataException : Exception
    {
        public InvalidFrameDataException(string message) : base(message) { }
    }
}
