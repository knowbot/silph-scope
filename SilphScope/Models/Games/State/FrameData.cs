using SilphScope.Models.Games.State.Common;

namespace SilphScope.Models.Games.State
{
    public record FrameData(Trainer Trainer, Pokemon[] Team, Box[] Boxes);
}
