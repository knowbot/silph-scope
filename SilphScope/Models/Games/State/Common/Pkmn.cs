using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common
{
	public record Pkmn(
		Species Species,
		ItemName HeldItem,
		uint Exp,
		Level Level,
		byte Friendship,
		Ability Ability,
		EVs EVs,
		IVs IVs,
		Stats Stats,
		MoveSet MoveSet,
		bool IsEgg,
		string Nickname
		);
}
