using SilphScope.Models.Games.Data.Enums;
using SilphScope.Models.Games.State.Common.PkmnInfo;

namespace SilphScope.Models.Games.State.Common
{
    public record Pokemon(
        Species Species,
        // HELD ITEM
        uint Exp,
        Level Level,
        byte Friendship,
        Ability Ability,
        EVs EVs,
        IVs IVs,
        MoveSet MoveSet
        );
}
