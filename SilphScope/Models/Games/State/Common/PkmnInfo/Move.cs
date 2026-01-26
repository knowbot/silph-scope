using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common.PkmnInfo
{
    public readonly record struct Move(MoveName Name, int CurrPP, int PPUp)
    {
        public readonly int TotPP => StaticData.MoveData.MaxPP[(int)Name] + PPUp;
    }
}
