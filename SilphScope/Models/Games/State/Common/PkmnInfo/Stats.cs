using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common.PkmnInfo
{
    public record Stats
    {
        private readonly int[] _stats = new int[6];
        public int this[int index] => _stats[index];
        public int this[Stat stat] => _stats[(int)stat];

        public Stats(params int[] stats)
        {
            _stats = [.. stats];
        }
    }
}
