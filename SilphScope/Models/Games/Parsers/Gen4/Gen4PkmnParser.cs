using SilphScope.Models.Extensions;
using SilphScope.Models.Games.Parsers.Common;
using SilphScope.Models.Games.Parsers.Gen4.Text;
using SilphScope.Models.Games.State.Common;
using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData;
using SilphScope.Models.Games.StaticData.Enums;
using System;
using System.Runtime.InteropServices;

namespace SilphScope.Models.Games.Parsers.Gen4
{
	public class Gen4PkmnParser : APkmnParser
	{
		private const int _unencryptedSize = 8;
		private const int _encryptedSize = 128;
		private const int _battleStatsSize = 100;
		private const int _blockSize = 32;

		private static ReadOnlySpan<byte> BlockOffsets =>
			[
				0, 32, 64, 96, // ABCD
                0, 32, 96, 64, // ABDC
                0, 64, 32, 96, // ACBD
                0, 96, 32, 64, // ADBC
                0, 64, 96, 32, // ACDB
                0, 96, 64, 32, // ADCB
                32, 0, 64, 96, // BACD
                32, 0, 96, 64, // BADC
                64, 0, 32, 96, // CABD
                96, 0, 32, 64, // DABC
                64, 0, 96, 32, // CADB
                96, 0, 64, 32, // DACB
                32, 64, 0, 96, // BCAD
                32, 96, 0, 64, // BDAC
                64, 32, 0, 96, // CBAD
                96, 32, 0, 64, // DBAC
                64, 96, 0, 32, // CDAB
                96, 64, 0, 32, // DCAB
                32, 64, 96, 0, // BCDA
                32, 96, 64, 0, // BDCA
                64, 32, 96, 0, // CBDA
                96, 32, 64, 0, // DBCA
                64, 96, 32, 0, // CDBA
                96, 64, 32, 0  // DCBA
            ];

		public override Pkmn? Parse(ReadOnlySpan<byte> pkmnData, bool isParty)
		{
			uint pId = pkmnData.Read<uint>();
			ushort checksum = pkmnData.Read<ushort>(0x6);

			Span<byte> blocks = stackalloc byte[_encryptedSize];
			pkmnData.Slice(0x8, _encryptedSize).CopyTo(blocks);

			int shiftIndex = (int)((pId & 0x3E000) >> 0xD) % 24 * 4;
			ReadOnlySpan<byte> blockA = blocks.Slice(BlockOffsets[shiftIndex], 32);
			ReadOnlySpan<byte> blockB = blocks.Slice(BlockOffsets[shiftIndex + 1], 32);
			ReadOnlySpan<byte> blockC = blocks.Slice(BlockOffsets[shiftIndex + 2], 32);

			bool isDecrypted = IsValidData(blockA);
			// if false, attempt decryption
			if (!isDecrypted) Decrypt(blocks, checksum);
			// TODO: decide what to do if check fails again
			if (!IsValidData(blockA)) throw new ParserException($"Invalid Pokémon data, read species #{blockA.Read<ushort>()}.");

			// BLOCK A
			ushort species = blockA.Read<ushort>();
			if (species == 0) return null;

			ushort heldItem = blockA.Read<ushort>(0x2);
			uint exp = blockA.Read<uint>(0x8);
			byte friendship = blockA.Read<byte>(0xC);
			byte ability = blockA.Read<byte>(0xD);
			EVs evs = ParseEVs(blockA);

			// BLOCK B
			MoveSet moveSet = new(ParseMoves(blockB));
			IVs ivs = ParseIVs(blockB);
			byte bflags = blockB.Read<byte>(0x13);
			bool isEgg = ((bflags >> 6) & 0x1) != 0;
			bool hasNickname = ((bflags >> 7) & 0x1) != 0;
			byte formFlags = blockB.Read<byte>(0x18);
			Gender gender = (formFlags & 0x4) != 0 ? Gender.None : (formFlags & 0x2) != 0 ? Gender.Female : Gender.Male;
			int altForm = (formFlags & 0xF8) >> 3;

			// BLOCK C
			string nickname = hasNickname ? Gen4Decoder.Decode(blockC[..0x14]) : "";
			Level level = GetLevel(species, exp);

			// Deduction of some fields.
			Nature nature = (Nature)(pId % 25);

			Stats stats;
			BattleInfo? battleInfo = null;
			if (isParty)
			{
				Span<byte> battleStats = stackalloc byte[_battleStatsSize];
				pkmnData.Slice(0x88, _battleStatsSize).CopyTo(battleStats);
				if (!isDecrypted) Decrypt(battleStats, pId);
				stats = ParseStats(battleStats);
				byte statusFlags = battleStats.Read<byte>();
				ushort currHP = battleStats.Read<ushort>(0x6);
				byte sleepTurns = (byte)(statusFlags & 0x7);
				if (sleepTurns > 0)
				{
					battleInfo = new(currHP, Status.Asleep, sleepTurns);
				}
				else
				{
					Status status = (statusFlags & 0xF8) switch
					{
						0 => Status.Healthy,
						0x08 => Status.Poisoned,
						0x10 => Status.Burned,
						0x20 => Status.Frozen,
						0x40 => Status.Paralyzed,
						0x80 => Status.BadlyPoisoned,
						_ => throw new ParserException("Error while reading status.")
					};
					battleInfo = new(currHP, status, 0);
				}
			}
			else
			{
				stats = StatsCalc.GetStats((Species)species, ivs, evs, level.Current, nature);
			}

			return new Pkmn(
				(Species)species,
				ItemTables.Gen4Plus[heldItem],
				(Ability)ability,
				moveSet,
				exp,
				GetLevel(species, exp),
				friendship,
				evs,
				ivs,
				stats,
				"",
				gender,
				isEgg,
				nature,
				battleInfo
				);
		}

		protected static void Decrypt(Span<byte> data, long seed)
		{
			Span<ushort> words = MemoryMarshal.Cast<byte, ushort>(data);
			long prng = seed;
			for (int i = 0; i < words.Length; i++)
			{
				prng = ((0x41C64E6D * prng) + 0x6073) & 0xFFFFFFFF;
				words[i] ^= (ushort)(prng >> 16);
			}
		}

		protected bool IsValidData(ReadOnlySpan<byte> blockA)
		{
			ushort candidateSpecies = blockA.Read<ushort>();
			EVs candidateEVs = ParseEVs(blockA);
			return candidateSpecies < (ushort)Species.MAX_VALUE && candidateEVs.IsValid();
		}


		protected override EVs ParseEVs(ReadOnlySpan<byte> data)
		{
			return new(
				data.Read<byte>(0x10),
				data.Read<byte>(0x11),
				data.Read<byte>(0x12),
				data.Read<byte>(0x14),
				data.Read<byte>(0x15),
				data.Read<byte>(0x13)
			);
		}

		protected override IVs ParseIVs(ReadOnlySpan<byte> data)
		{
			uint ivs = data.Read<uint>(0x10);
			return new(
				(byte)((ivs >> 0) & 0x1F),
				(byte)((ivs >> 5) & 0x1F),
				(byte)((ivs >> 10) & 0x1F),
				(byte)((ivs >> 20) & 0x1F),
				(byte)((ivs >> 25) & 0x1F),
				(byte)((ivs >> 15) & 0x1F)
			);
		}

		protected override Stats ParseStats(ReadOnlySpan<byte> data)
		{
			return new(
				data.Read<ushort>(0x08),
				data.Read<ushort>(0x0A),
				data.Read<ushort>(0x0C),
				data.Read<ushort>(0x10),
				data.Read<ushort>(0x12),
				data.Read<ushort>(0x0E)
			);
		}

		protected override Move[] ParseMoves(ReadOnlySpan<byte> data)
		{
			Move[] moves = new Move[4];
			for (int i = 0; i < 4; i++)
			{
				moves[i] = new(
					(MoveName)data.Read<ushort>(i * 0x2),
					data.Read<byte>(0x8 + i),
					data.Read<byte>(0xC + i)
					);
			}
			return moves;
		}

		public override int GetPartyPkmnSize()
		{
			return _unencryptedSize + _encryptedSize + _battleStatsSize;
		}

		public override int GetBoxPkmnSize()
		{
			return _unencryptedSize + _encryptedSize;
		}
	}
}
