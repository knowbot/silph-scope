using SilphScope.Models.Games.Data.Enums;

namespace SilphScope.Models.Games.State.Pkmn
{
    public record Pokemon
    {
        public Species Species { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public Ability Ability { get; set; }
        public MoveSet MoveSet { get; set; }
        public EVs EVs { get; set; }
        public IVs IVs { get; set; }
    }
}
