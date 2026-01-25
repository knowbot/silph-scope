using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common.PkmnInfo
{
    public record IVs
    {
        private readonly int[] _ivs = new int[6];
        public int this[int index] => _ivs[index];
        public int this[Stat stat] => _ivs[(int)stat];


        public IVs(params int[] ivs)
        {
            _ivs = [.. ivs];
        }

        public bool IsValid()
        {
            return !((uint)_ivs[0] > 31 | (uint)_ivs[1] > 31 | (uint)_ivs[2] > 31 | (uint)_ivs[3] > 31 | (uint)_ivs[4] > 31 | (uint)_ivs[5] > 31);
        }
    }
}
