using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common
{
	public record Pkmn(
		uint PID,
		Species Species,
		int Form,
		ItemName HeldItem,
		ushort OT,
		ushort OTSecret,
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
		// TODO: shiny odds based on game of origin? Or based on current game.
		public bool IsShiny { get { return (OT ^ OTSecret ^ (ushort)(PID >> 16) ^ (ushort)(PID & 0xFFFF)) < 8; } }
	}
}
