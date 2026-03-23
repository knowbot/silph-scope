using System;
using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Games.Parsers.Common;

public class StatsCalc
{
    private static readonly int[] s_natureStatsLookup = [0, 1, 4, 2, 3, 5, 6, 9, 7, 8, 20, 21, 24, 22, 23, 10, 11, 14, 12, 13, 15, 16, 17, 18, 19];

    public static Stats GetStats(Species species, IVs ivs, EVs evs, int level, Nature nature)
    {
        ushort[] stats = new ushort[6];

        // Hp. Notice special case for Shedinja.
        stats[0] = species == Species.Shedinja ? (ushort)1 : HPFormula(StaticData.SpeciesData.BaseStats[(int)species * 6], ivs[0], evs[0], level);

        // Account for nature.
        int natureIndex = s_natureStatsLookup[(int)nature];

        int incStat = natureIndex / 5;
        int decStat = natureIndex % 5;
        Span<float> natMults = [1.0f, 1.0f, 1.0f, 1.0f, 1.0f];
        if (incStat != decStat)
        {
            natMults[incStat] = 1.1f;
            natMults[decStat] = 0.9f;
        }

        // Compute stats.
        for (int i = 1; i < stats.Length; i++)
        {
            stats[i] = StatFormula(StaticData.SpeciesData.BaseStats[((int)species * 6) + i], ivs[i], evs[i], level, natMults[i - 1]);
        }
        return new Stats(stats);
    }

    public static ushort HPFormula(int baseHP, int iv, int ev, int level)
    {
        return (ushort)((((2 * baseHP) + iv + (ev / 4)) * level / 100) + level + 10);
    }

    public static ushort StatFormula(int baseStat, int iv, int ev, int level, float natMult)
    {
        return (ushort)(((((2 * baseStat) + iv + (ev / 4)) * level / 100) + 5) * natMult);
    }
}
