using System;

namespace SilphScope.Models.Games.Parsers
{
    [Serializable]
    public class ParserException(string message) : Exception(message)
    {
    }
}
