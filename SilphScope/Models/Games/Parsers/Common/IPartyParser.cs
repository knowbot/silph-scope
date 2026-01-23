using SilphScope.Models.Core;
using SilphScope.Models.Games.State.Common;
using System.Collections.Generic;

namespace SilphScope.Models.Games.Parsers.Common
{
    public interface IPartyParser
    {
        public List<Pokemon> ParseParty(SilphContext context);
    }
}
