using SilphScope.Models.Games;

namespace SilphScope.Models.Core
{
    public class SilphContext(Game game)
    {
        public Game Game = game;
        public byte[] Buffer = new byte[game.Layout.MemorySize];
    }
}
