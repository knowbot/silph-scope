using SilphScope.Models.Core;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.Parsers.Common;
using SilphScope.Models.Games.State.Common;
using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SilphScope.Models.Games.Parsers.Gen4
{
    public class Gen4PkmnParser : APkmnParser
    {
        private const int _unencryptedSize = 8;
        private const int _pkmnSize = 128;
        private const int _battleStats = 100;
        private const int _blockSize = 32;

        // From https://bulbapedia.bulbagarden.net/wiki/Pok%C3%A9mon_data_structure_(Generation_IV)#Block_shuffling
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
        private static int PartyPkmnSize() => _unencryptedSize + _pkmnSize + _battleStats;
        private static int BoxPkmnSize() => _unencryptedSize + _pkmnSize;

        public override List<Pokemon> ParseParty(SilphContext context)
        {
            ReadOnlySpan<byte> data = context.Data;
            IMemoryLayout layout = context.Game.Layout;
            byte partyCount = data.Read<byte>(layout.PartyCount);
            Pokemon[] party = new Pokemon[partyCount];
            for (int i = 0; i < partyCount; i++)
            {
                int pkmnAddr = layout.Party + (i * PartyPkmnSize());
                party[i] = Parse(data[pkmnAddr..]);
            }
            return [.. party];
        }

        public override List<Pokemon> ParseBoxes(SilphContext context)
        {
            throw new NotImplementedException();
        }

        private bool IsValidData(ReadOnlySpan<byte> blockA, ReadOnlySpan<byte> blockB)
        {
            ushort candidateSpecies = blockA.Read<ushort>();
            EVs candidateEVs = ParseEVs(blockA);
            return candidateSpecies < (ushort)Species.MAX_VALUE && candidateEVs.IsValid();
        }

        public override Pokemon Parse(ReadOnlySpan<byte> pkmnData)
        {
            uint pId = pkmnData.Read<uint>();
            ushort checksum = pkmnData.Read<ushort>(0x6);
            // copy over the ABCD blocks to decrypt in-place
            byte[] blocks = pkmnData.Slice(0x8, _pkmnSize).ToArray();

            // unshuffle blocks
            uint shift = ((pId & 0x3E000) >> 0xD) % 24;
            ReadOnlySpan<byte> order = BlockUnshuffle.Slice((int)shift * 4, 4);
            ReadOnlySpan<byte> blockA = blocks.AsSpan(_blockSize * order[0], 32);
            ReadOnlySpan<byte> blockB = blocks.AsSpan(_blockSize * order[1], 32);

            bool isDecrypted = IsValidData(blockA, blockB);
            // if false, attempt decryption
            if (!isDecrypted)
            {
                Span<ushort> words = MemoryMarshal.Cast<byte, ushort>(blocks);
                long prng = checksum;
                for (int i = 0; i < words.Length; i++)
                {
                    prng = ((0x41C64E6D * prng) + 0x6073) & 0xFFFFFFFF;
                    words[i] ^= (ushort)(prng >> 16);
                }
            }
            // TODO: decide what to do if check fails again


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

            // BLOCK C

            return new Pokemon(
                (Species)species,
                exp,
                GetLevel(species, exp),
                friendship,
                (Ability)ability,
                evs,
                ivs,
                moveSet
                );
        }

        protected EVs ParseEVs(ReadOnlySpan<byte> block)
        {
            return new(
                block.Read<byte>(0x10),
                block.Read<byte>(0x11),
                block.Read<byte>(0x12),
                block.Read<byte>(0x13),
                block.Read<byte>(0x14),
                block.Read<byte>(0x15)
            );
        }

        protected IVs ParseIVs(ReadOnlySpan<byte> block)
        {
            uint ivs = block.Read<uint>(0x10);
            return new(
                (int)((ivs >> 0) & 0x1F),
                (int)((ivs >> 5) & 0x1F),
                (int)((ivs >> 10) & 0x1F),
                (int)((ivs >> 20) & 0x1F),
                (int)((ivs >> 25) & 0x1F),
                (int)((ivs >> 15) & 0x1F)
            );
        }

        protected override Move[] ParseMoves(ReadOnlySpan<byte> blockB)
        {
            Move[] moves = new Move[4];
            for (int i = 0; i < 4; i++)
            {
                moves[i] = new(
                    (MoveName)blockB.Read<ushort>(i * 0x2),
                    blockB.Read<byte>(0x8 + i),
                    blockB.Read<byte>(0xC + i)
                    );
            }
            return moves;
        }
    }
}
