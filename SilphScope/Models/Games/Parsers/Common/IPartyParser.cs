using SilphScope.Models.Core;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.Models.Games.Parsers.Common;

public interface IPartyParser
{
    Pkmn[] Parse(SilphContext context);
}
