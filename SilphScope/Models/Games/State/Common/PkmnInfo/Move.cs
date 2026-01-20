using SilphScope.Models.Games.Data;
using SilphScope.Models.Games.Data.Enums;

namespace SilphScope.Models.Games.State.Common.PkmnInfo
{
    public record Move(MoveName Name, int CurrPP, int PPUp)
    {
        public int TotPP => GameData.MovePP[(int)Name] + PPUp;
    }
}
