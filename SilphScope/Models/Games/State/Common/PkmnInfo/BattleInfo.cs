using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common.PkmnInfo
{
    public record BattleInfo(int CurrHP, Status Status, int SleepTurns)
    {
        public bool HasFainted => CurrHP == 0;
    }
}
