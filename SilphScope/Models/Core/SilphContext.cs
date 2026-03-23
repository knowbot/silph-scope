using SilphScope.Models.Games;

namespace SilphScope.Models.Core;

public class SilphContext
{
    public Game Game { get; }
    public nint SaveAddr { get; }
    public byte[] Data { get; }

    public SilphContext(Game game, nint saveAddr, byte[] data)
    {
        Game = game;
        SaveAddr = saveAddr;
        Data = data;
    }
}
