using SilphScope.Models.Core;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.Models.Games.Parsers.Common
{
    public interface IBoxParser
    {
        public Box[] Parse(SilphContext context);
    }
}
