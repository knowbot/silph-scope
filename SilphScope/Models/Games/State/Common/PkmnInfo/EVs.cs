using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common.PkmnInfo
{
    public record EVs
    {
        private readonly int[] _evs;
        public int this[int index] => _evs[index];
        public int this[Stat stat] => _evs[(int)stat];

        public EVs(params int[] evs)
        {
            _evs = [.. evs];
        }

        public bool IsValid()
        {
            if (_evs[0] + _evs[1] + _evs[2] + _evs[3] + _evs[4] + _evs[5] > 510) return false;
            return !((uint)_evs[0] > 252 | (uint)_evs[1] > 252 | (uint)_evs[2] > 252 | (uint)_evs[3] > 252 | (uint)_evs[4] > 252 | (uint)_evs[5] > 252);
        }
    }
}
