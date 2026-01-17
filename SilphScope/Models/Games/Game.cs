using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.MemoryLayouts.Gen4;
using System.Collections.Generic;

namespace SilphScope.Models.Games
{
    public record Game(string Name, string ProductId, GenEnum Generation, IMemoryLayout Layout)
    {
        public string Name = Name;
        public string ProductId = ProductId;
        public GenEnum Generation = Generation;
        public IMemoryLayout Layout = Layout;

        public static readonly IReadOnlyList<Game> Supported = [
                    new Game("Pokémon Platinum (U)", "CPUE", GenEnum.GEN_4, new PtLayout()),
        ];
    }
}
