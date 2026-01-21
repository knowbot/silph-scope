using SilphScope.Models.Games.State;

namespace SilphScope.Models.Core.Messages
{
    public class GameStateUpdateMessage : SilphServiceMessage
    {
        public readonly GameState NewGameState;

        public GameStateUpdateMessage(GameState newGameState)
        {
            NewGameState = newGameState;
        }
    }
}
