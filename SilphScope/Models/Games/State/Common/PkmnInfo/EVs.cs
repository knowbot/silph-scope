using SilphScope.Models.Games.StaticData.Enums;
using System;

namespace SilphScope.Models.Games.State.Common.PkmnInfo
{
    public readonly record struct EVs
    {
        private readonly ushort[] _evs;
        public ushort this[int index] => _evs[index];
        public ushort this[Stat stat] => _evs[(int)stat];

        public EVs(params ushort[] evs)
        {
            if (evs.Length != 6) throw new ArgumentException("Incorrect amount of EVs");
            _evs = [.. evs];
        }

        public bool IsValid()
        {
            if (_evs.Length != 6) return false;
            if (_evs[0] + _evs[1] + _evs[2] + _evs[3] + _evs[4] + _evs[5] > 510) return false;
            return !((uint)_evs[0] > 252 | (uint)_evs[1] > 252 | (uint)_evs[2] > 252 | (uint)_evs[3] > 252 | (uint)_evs[4] > 252 | (uint)_evs[5] > 252);
        }
    }
}
