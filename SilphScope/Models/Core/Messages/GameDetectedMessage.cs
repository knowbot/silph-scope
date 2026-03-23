using SilphScope.Models.Games;

namespace SilphScope.Models.Core.Messages;

public class GameDetectedMessage(Game game) : SilphServiceMessage
{
    public readonly Game TargetGame = game;
}
