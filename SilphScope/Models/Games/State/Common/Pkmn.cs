using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common
{
    public record Pkmn(
        Species Species,
        // HELD ITEM
        uint Exp,
        Level Level,
        byte Friendship,
        Ability Ability,
        EVs EVs,
        IVs IVs,
        MoveSet MoveSet,
        bool IsEgg,
        string Nickname
        );
}
