using System.Collections.Generic;
using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.MemoryLayouts.Gen4;

namespace SilphScope.Models.Games;

public record Game(string Name, string ProductId, byte Generation, IMemoryLayout Layout, string IconPath, string BadgesPath, bool HasExtraBadges = false)
{
    public string Name = Name;
    public string ProductId = ProductId;
    public byte Generation = Generation;
    public IMemoryLayout Layout = Layout;
    public string IconPath = new(IconPath);
    public string BadgesPath = new(BadgesPath);

    public static readonly IReadOnlyList<Game> Supported = [
        new Game("Pokémon Platinum (U)", "CPUE", 4, new PtLayout(), "Assets/Images/GameIcons/NDS/Platinum_icon.png", "Assets/Images/Badges/DPPt"),
    ];
}
