using SilphScope.Models.Games;

namespace SilphScope.Models.Core
{
    public class SilphContext(Game game, nint baseAddress)
    {
        public Game Game = game;
        public nint BaseAddress = baseAddress;
        public byte[] Buffer = new byte[game.Layout.MemorySize];
    }
}
