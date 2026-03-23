using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common.PkmnInfo;

public readonly record struct BattleInfo(ushort CurrHP, Status Status, byte SleepTurns)
{
    public bool HasFainted => CurrHP == 0;
}
