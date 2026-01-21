using SilphScope.Models.Games.State;

namespace SilphScope.Models.Core.Messages
{
    public class GameStateUpdate(GameState newGameState) : SilphServiceMessage
    {
        public readonly GameState NewGameState = newGameState;
    }
}
