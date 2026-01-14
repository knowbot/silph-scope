using SilphScope.Models.Games.MemoryLayouts;
using System.Collections.Generic;

namespace SilphScope.Models.Games
{
    public class GameLibrary
    {
        public static List<Game> SupportedGames = new()
        {
            new Game("Pokémon Platinum (U)", "CPUE", GenEnum.GEN_4, new PlatinumLayout()),
        };
    }
}
