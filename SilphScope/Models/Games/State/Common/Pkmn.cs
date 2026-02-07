using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common
{
	public record Pkmn(
		Species Species,
		int Form,
		ItemName HeldItem,
		Ability Ability,
		MoveSet MoveSet,
		uint Exp,
		Level Level,
		byte Friendship,
		EVs EVs,
		IVs IVs,
		Stats Stats,
		string Nickname,
		Gender Gender,
		bool IsEgg,
		Nature Nature,
		BattleInfo? BattleInfo
		)
	{
		// TODO.
		public bool IsShiny { get { return false; } }
	}
}
