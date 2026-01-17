using SilphScope.Models.Core;
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
    public class Gen4PkmnParser : AParser
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

        public static List<Pokemon> ParseParty(SilphContext context)
        {
            List<Pokemon> party = [];
            ReadOnlySpan<byte> data = context.Data;
            IMemoryLayout layout = context.Game.Layout;
            int partyCount = ReadAt<byte>(data, layout.PartyCount);
            for (int i = 0; i < partyCount; i++)
            {
                int pkmnAddr = layout.Party + (i * PartyPkmnSize());
                Pokemon pkmn = Parse(data[pkmnAddr..]);
            }

            return party;
        }

        private static Pokemon Parse(ReadOnlySpan<byte> data)
        {
            uint pId = ReadAt<uint>(data);
            long prng = ReadAt<ushort>(data, 0x6);
            // copy over the ABCD blocks to decrypt in-place
            byte[] blocks = data.Slice(0x8, _pkmnSize).ToArray();
            // read the data as 2-byte words for decryption
            Span<ushort> words = MemoryMarshal.Cast<byte, ushort>(blocks);
            for (int i = 0; i < words.Length; i++)
            {
                prng = (0x41C64E6D * prng) + 0x6073;
                words[i] ^= (ushort)(prng >> 16);
            }
            uint shift = ((pId & 0x3E000) >> 0xD) % 24;
            // now, read the data from the blocks (A > B > C > D)
            ReadOnlySpan<byte> order = BlockUnshuffle.Slice((int)shift * 4, 4);

            // BLOCK A
            int blockAddr = _blockSize * order[0];
            ushort species = ReadAt<ushort>(blocks, blockAddr);
            ushort heldItem = ReadAt<ushort>(blocks, blockAddr + 0x2);
            uint exp = ReadAt<uint>(blocks, blockAddr + 0x8);
            byte friendship = ReadAt<byte>(blocks, blockAddr + 0xC);
            byte ability = ReadAt<byte>(blocks, blockAddr + 0xD);
            EVs evs = new(
                ReadAt<byte>(blocks, blockAddr + 0x10),
                ReadAt<byte>(blocks, blockAddr + 0x11),
                ReadAt<byte>(blocks, blockAddr + 0x12),
                ReadAt<byte>(blocks, blockAddr + 0x13),
                ReadAt<byte>(blocks, blockAddr + 0x14),
                ReadAt<byte>(blocks, blockAddr + 0x15)
            );

            // BLOCK B
            blockAddr = _blockSize * order[1];
            Move[] moves = ParseMoves(blocks.AsSpan(_blockSize * order[1], 32));
            MoveSet moveSet = new(moves[0], moves[1], moves[2], moves[3]);
            IVs ivs = new(
                ReadAt<byte>(blocks, blockAddr + 0x10),
                ReadAt<byte>(blocks, blockAddr + 0x11),
                ReadAt<byte>(blocks, blockAddr + 0x12),
                ReadAt<byte>(blocks, blockAddr + 0x13),
                ReadAt<byte>(blocks, blockAddr + 0x14),
                ReadAt<byte>(blocks, blockAddr + 0x15)
            );

            // BLOCK C

            return new Pokemon();
        }

        private static Move[] ParseMoves(ReadOnlySpan<byte> blockB)
        {
            Move[] moves = new Move[4];
            for (int i = 0; i < 4; i++)
            {
                moves[i] = new(
                    (MoveName)ReadAt<ushort>(blockB),
                    ReadAt<byte>(blockB, 0x8 + i),
                    ReadAt<byte>(blockB, 0xC + i)
                    );
            }
            return moves;
        }

    }
}
