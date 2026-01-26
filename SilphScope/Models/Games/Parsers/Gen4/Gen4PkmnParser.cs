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

        private static ReadOnlySpan<byte> BlockUnshuffle =>
            [
                0, 1, 2, 3, //00 ABCD
                0, 1, 3, 2, //01 ABDC
                0, 2, 1, 3, //02 ACBD
                0, 3, 1, 2, //03 ADBC
                0, 2, 3, 1, //04 ACDB
                0, 3, 2, 1, //05 ADCB
                1, 0, 2, 3, //06 BACD
                1, 0, 3, 2, //07 BADC
                2, 0, 1, 3, //08 CABD
                3, 0, 1, 2, //09 DABC
                2, 0, 3, 1, //10 CADB
                3, 0, 2, 1, //11 DACB
                1, 2, 0, 3, //12 BCAD
                1, 3, 0, 2, //13 BDAC
                2, 1, 0, 3, //14 CBAD
                3, 1, 0, 2, //15 DBAC
                2, 3, 0, 1, //16 CDAB
                3, 2, 0, 1, //17 DCAB
                1, 2, 3, 0, //18 BCDA
                1, 3, 2, 0, //19 BDCA
                2, 1, 3, 0, //20 CBDA
                3, 1, 2, 0, //21 DBCA
                2, 3, 1, 0, //22 CDBA
                3, 2, 1, 0  //23 DCBA
            ];

        public override Pkmn? Parse(ReadOnlySpan<byte> pkmnData, bool isParty)
        {
            uint pId = pkmnData.Read<uint>();
            if (pId == 0) return null;
            ushort checksum = pkmnData.Read<ushort>(0x6);

            Span<byte> blocks = stackalloc byte[_encryptedSize];
            pkmnData.Slice(0x8, _encryptedSize).CopyTo(blocks);

            uint shift = ((pId & 0x3E000) >> 0xD) % 24;
            ReadOnlySpan<byte> order = BlockUnshuffle.Slice((int)shift * 4, 4);
            ReadOnlySpan<byte> blockA = blocks.Slice(_blockSize * order[0], 32);
            ReadOnlySpan<byte> blockB = blocks.Slice(_blockSize * order[1], 32);
            ReadOnlySpan<byte> blockC = blocks.Slice(_blockSize * order[2], 32);

            bool isDecrypted = IsValidData(blockA);
            // if false, attempt decryption
            if (!isDecrypted) Decrypt(blocks, checksum);
            // TODO: decide what to do if check fails again
            if (!IsValidData(blockA)) throw new ParserException($"Invalid Pokémon data.");

            // BLOCK A
            ushort species = blockA.Read<ushort>();
            ushort heldItem = blockA.Read<ushort>(0x2);
            uint exp = blockA.Read<uint>(0x8);
            byte friendship = blockA.Read<byte>(0xC);
            byte ability = blockA.Read<byte>(0xD);
            EVs evs = ParseEVs(blockA);

            // BLOCK B
            Move[] moves = ParseMoves(blockB);
            MoveSet moveSet = new(moves[0], moves[1], moves[2], moves[3]);
            IVs ivs = ParseIVs(blockB);
            byte bflags = blockB.Read<byte>(0x10);
            bool isEgg = (bflags & 0x1) != 0;
            bool hasNickname = (bflags & 0x2) != 0;
            byte formFlags = blockB.Read<byte>(0x18);
            Gender gender = (formFlags & 0x4) != 0 ? Gender.None : (formFlags & 0x2) != 0 ? Gender.Female : Gender.Male;
            int altForm = (formFlags & 0xF8) >> 3;

            // BLOCK C
            string nickname = hasNickname ? Gen4Decoder.Decode(blockC[..0x14]) : "";
            Level level = GetLevel(species, exp);

            Stats stats = new();
            BattleInfo? battleInfo = null;
            if (isParty)
            {
                Span<byte> battleStats = stackalloc byte[_battleStatsSize];
                pkmnData.Slice(0x88, _battleStatsSize).CopyTo(battleStats);
                if (!isDecrypted) Decrypt(battleStats, pId);
                byte statusFlags = battleStats.Read<byte>();
                ushort currHP = battleStats.Read<ushort>(0x6);
                stats = ParseStats(battleStats);
                int sleepTurns = statusFlags & 0x7;
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
                stats = StatsCalc.GetStats((Species)species, ivs, evs, level.Current, Nature.Hardy);
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
                (int)((ivs >> 0) & 0x1F),
                (int)((ivs >> 5) & 0x1F),
                (int)((ivs >> 10) & 0x1F),
                (int)((ivs >> 20) & 0x1F),
                (int)((ivs >> 25) & 0x1F),
                (int)((ivs >> 15) & 0x1F)
            );
        }

        protected override Stats ParseStats(ReadOnlySpan<byte> data)
        {
            return new(
                data.Read<ushort>(0x8),
                data.Read<ushort>(0x10),
                data.Read<ushort>(0x12),
                data.Read<ushort>(0x16),
                data.Read<ushort>(0x18),
                data.Read<ushort>(0x14)
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

        public override int GetPartyPkmnSize() => _unencryptedSize + _encryptedSize + _battleStatsSize;
        public override int GetBoxPkmnSize() => _unencryptedSize + _encryptedSize;
    }
}
