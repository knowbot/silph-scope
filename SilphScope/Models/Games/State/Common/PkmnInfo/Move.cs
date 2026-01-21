using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common.PkmnInfo
{
    public record Move(MoveName Name, int CurrPP, int PPUp)
    {
        public int TotPP => StaticData.MoveData.MaxPP[(int)Name] + PPUp;
    }
}
