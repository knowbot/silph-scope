using SilphScope.Models.Core;
using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.Parsers.Common;
using SilphScope.Models.Games.Parsers.Gen4.Text;
using SilphScope.Models.Games.State.Common;
using System;

namespace SilphScope.Models.Games.Parsers.Gen4
{
    public class Gen4BoxParser : IBoxParser
    {
        private const int _boxCount = 18;
        private const int _pkmnPerBox = 30;
        private const int _nameSize = 40;
        public Box[] Parse(SilphContext context)
        {
            Box[] boxes = new Box[_boxCount];
            Gen4PkmnParser pkmnParser = new();
            IMemoryLayout layout = context.Game.Layout;
            ReadOnlySpan<byte> data = context.Data.AsSpan()[layout.BigBlock..];

            int pkmnSize = pkmnParser.GetBoxPkmnSize();
            int boxSize = pkmnSize * _pkmnPerBox;
            for (int i = 0; i < _boxCount; i++)
            {
                string name = Gen4Decoder.Decode(data.Slice(layout.BoxNames + (i * _nameSize), _nameSize));
                boxes[i] = new(name, new Pkmn?[_pkmnPerBox]);
                for (int j = 0; j < _pkmnPerBox; j++)
                {
                    boxes[i].Slots[j] = pkmnParser.Parse(data[(layout.BoxPokemon + (pkmnSize * j) + (boxSize * i))..], false);
                }
            }
            return boxes;
        }
    }
}
