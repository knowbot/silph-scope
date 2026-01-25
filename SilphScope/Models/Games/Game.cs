using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.MemoryLayouts.Gen4;
using System;
using System.Collections.Generic;

namespace SilphScope.Models.Games
{
    public record Game(string Name, string ProductId, string IconPath, byte Generation, IMemoryLayout Layout)
    {
        public string Name = Name;
        public string ProductId = ProductId;
        public Uri Icon = new(IconPath);
        public byte Generation = Generation;
        public IMemoryLayout Layout = Layout;

        public static readonly IReadOnlyList<Game> Supported = [
            new Game("Pokémon Platinum (U)", "CPUE", "avares://SilphScope/Assets/Images/GameIcons/NDS/Platinum_icon.png", 4, new PtLayout()),
        ];
    }
}
