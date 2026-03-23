using System;
using SilphScope.Models.Core;
using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.Parsers.Common;
using SilphScope.Models.Games.Parsers.Gen4.Text;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.Models.Games.Parsers.Gen4;

public class Gen4BoxParser : IBoxParser
{
    private const int BoxCount = 18;
    private const int PkmnPerBox = 30;
    private const int NameSize = 40;
    public Box[] Parse(SilphContext context)
    {
        Box[] boxes = new Box[BoxCount];
        Gen4PkmnParser pkmnParser = new();
        IMemoryLayout layout = context.Game.Layout;
        ReadOnlySpan<byte> data = context.Data.AsSpan()[layout.BigBlock..];

        int pkmnSize = pkmnParser.GetBoxPkmnSize();
        int boxSize = pkmnSize * PkmnPerBox;
        for (int i = 0; i < BoxCount; i++)
        {
            string name = Gen4Decoder.Decode(data.Slice(layout.BoxNames + (i * NameSize), NameSize));
            boxes[i] = new(name, new Pkmn?[PkmnPerBox]);
            for (int j = 0; j < PkmnPerBox; j++)
            {
                boxes[i].Slots[j] = pkmnParser.Parse(data[(layout.BoxPokemon + (pkmnSize * j) + (boxSize * i))..], false);
            }
        }
        return boxes;
    }
}
