using SilphScope.Models.Games.State.Pkmn;

namespace SilphScope.Models.Games.State
{
    public record GameState(Trainer trainer, Pokemon[] team, Box[] boxes);
}
