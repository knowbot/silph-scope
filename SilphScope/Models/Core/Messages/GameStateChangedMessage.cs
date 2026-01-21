using SilphScope.Models.Games.State;

namespace SilphScope.Models.Core.Messages
{
    public class GameStateChangedMessage(GameState newGameState) : SilphServiceMessage
    {
        public readonly GameState NewGameState = newGameState;
    }
}
