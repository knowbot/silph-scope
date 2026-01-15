using SilphScope.Models.Games.State.Pkmn;

namespace SilphScope.Models.Games.State
{
    public record GameState(Trainer Trainer, Pokemon[] Team, Box[] Boxes);
}
