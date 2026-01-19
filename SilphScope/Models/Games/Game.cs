using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.MemoryLayouts.Gen4;
using System;
using System.Collections.Generic;

namespace SilphScope.Models.Games
{
    public record Game(string Name, string ProductId, string IconPath, GenEnum Generation, IMemoryLayout Layout)
    {
        public string Name = Name;
        public string ProductId = ProductId;
        public Uri Icon = new(IconPath);
        public GenEnum Generation = Generation;
        public IMemoryLayout Layout = Layout;

        public static readonly IReadOnlyList<Game> Supported = [
                    new Game("Pokémon Platinum (U)", "CPUE", "avares://SilphScope/Assets/Images/GameIcons/NDS/Platinum_icon.png", GenEnum.GEN_4, new PtLayout()),
        ];
    }
}
