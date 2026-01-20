using SilphScope.Models.Games.State;

namespace SilphScope.Models.Core.Messages
{
    public class GameStateUpdateMessage : SilphServiceMessage
    {
        public readonly GameState NewState;

        public GameStateUpdateMessage(GameState newState)
        {
            NewState = newState;
        }
    }
}
