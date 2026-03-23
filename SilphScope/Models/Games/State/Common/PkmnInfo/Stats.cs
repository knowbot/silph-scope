using System;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.State.Common.PkmnInfo;

public readonly record struct Stats
{
    private readonly ushort[] _stats = new ushort[6];
    public ushort this[int index] => _stats[index];
    public ushort this[Stat stat] => _stats[(int)stat];

    public Stats(params ushort[] stats)
    {
        if (stats.Length != 6)
            throw new ArgumentException("Incorrect amount of stats");
        _stats = [.. stats];
    }
}
