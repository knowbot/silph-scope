using SilphScope.Models.Core;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games.Data.Enums;
using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.Parsers.Common;
using SilphScope.Models.Games.State.Common;
using SilphScope.Models.Games.State.Common.PkmnInfo;
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
                party[i] = this.Parse(data[pkmnAddr..]);
            }
            return [.. party];
        }

        public override List<Pokemon> ParseBoxes(SilphContext context)
        {
            throw new NotImplementedException();
        }

        public override Pokemon Parse(ReadOnlySpan<byte> pkmnData)
        {
            uint pId = pkmnData.Read<uint>();
            long prng = pkmnData.Read<ushort>(0x6);
            // copy over the ABCD blocks to decrypt in-place
            byte[] blocks = pkmnData.Slice(0x8, _pkmnSize).ToArray();
            // read the data as 2-byte words for decryption
            Span<ushort> words = MemoryMarshal.Cast<byte, ushort>(blocks);
            for (int i = 0; i < words.Length; i++)
            {
                prng = ((0x41C64E6D * prng) + 0x6073) & 0xFFFFFFFF;
                words[i] ^= (ushort)(prng >> 16);
            }
            uint shift = ((pId & 0x3E000) >> 0xD) % 24;
            // now, read the data from the blocks (A > B > C > D)
            ReadOnlySpan<byte> order = BlockUnshuffle.Slice((int)shift * 4, 4);

            // BLOCK A
            ReadOnlySpan<byte> blockA = blocks.AsSpan(_blockSize * order[0], 32);
            ushort species = blockA.Read<ushort>();
            ushort heldItem = blockA.Read<ushort>(0x2);
            uint exp = blockA.Read<uint>(0x8);
            byte friendship = blockA.Read<byte>(0xC);
            byte ability = blockA.Read<byte>(0xD);
            EVs evs = new(
                blockA.Read<byte>(0x10),
                blockA.Read<byte>(0x11),
                blockA.Read<byte>(0x12),
                blockA.Read<byte>(0x13),
                blockA.Read<byte>(0x14),
                blockA.Read<byte>(0x15)
            );

            // BLOCK B
            ReadOnlySpan<byte> blockB = blocks.AsSpan(_blockSize * order[1], 32);
            Move[] moves = ParseMoves(blockB);
            MoveSet moveSet = new(moves[0], moves[1], moves[2], moves[3]);
            IVs ivs = new(
                blockB.Read<byte>(0x10),
                blockB.Read<byte>(0x11),
                blockB.Read<byte>(0x12),
                blockB.Read<byte>(0x13),
                blockB.Read<byte>(0x14),
                blockB.Read<byte>(0x15)
            );

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

        protected Move[] ParseMoves(ReadOnlySpan<byte> blockB)
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
