using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Core.Sprites
{
    public class SpriteLoadRequest
    {
        public readonly SpriteLoadTask Task;
        public readonly Species Species;
        public readonly SpriteFlags Flags;

        public SpriteLoadRequest(SpriteLoadTask task, Species species, SpriteFlags flags)
        {
            Task = task;
            Species = species;
            Flags = flags;
        }
    }
}
