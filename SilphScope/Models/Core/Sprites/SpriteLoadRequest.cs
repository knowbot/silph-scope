using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Core.Sprites
{
    public class SpriteLoadRequest
    {
        public readonly SpriteLoadTask Task;
        public readonly SpriteIdentifier Identifier;

        public SpriteLoadRequest(SpriteLoadTask task, SpriteIdentifier identifier)
        {
            Task = task;
            Identifier = identifier;
        }
    }
}
