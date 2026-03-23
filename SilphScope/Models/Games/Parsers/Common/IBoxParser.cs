using SilphScope.Models.Core;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.Models.Games.Parsers.Common;

public interface IBoxParser
{
    Box[] Parse(SilphContext context);
}
