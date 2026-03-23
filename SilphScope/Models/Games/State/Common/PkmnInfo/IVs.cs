using System;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common.PkmnInfo;

public readonly record struct IVs
{
    private readonly byte[] _ivs;
    public byte this[int index] => _ivs[index];
    public byte this[Stat stat] => _ivs[(int)stat];

    public IVs(params byte[] ivs)
    {
        if (ivs.Length != 6)
            throw new ArgumentException("Incorrect amount of IVs");
        _ivs = [.. ivs];
    }

    public bool IsValid()
    {
        return _ivs.Length == 6 && !((uint)_ivs[0] > 31 | (uint)_ivs[1] > 31 | (uint)_ivs[2] > 31 | (uint)_ivs[3] > 31 | (uint)_ivs[4] > 31 | (uint)_ivs[5] > 31);
    }
}
