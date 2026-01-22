using SilphScope.Models.Games.State;

namespace SilphScope.Models.Core.Messages
{
    public class GameStateUpdate(FrameData newGameState) : SilphServiceMessage
    {
        public readonly FrameData NewGameState = newGameState;
    }
}
