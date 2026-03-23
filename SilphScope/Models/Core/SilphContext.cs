using SilphScope.Models.Games;

namespace SilphScope.Models.Core;

public class SilphContext(Game game, nint saveAddr, byte[] data)
{
    public Game Game = game;
    public nint saveAddr = saveAddr;
    public byte[] Data = data;
}
