using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData.Enums;
using System;

namespace SilphScope.Models.Games.Parsers.Common
{
    public class StatCalc
    {
        public static Stats GetStats(Species species, IVs ivs, EVs evs, int level, Nature nature)
        {
            int[] stats = new int[6];
            stats[0] = HPFormula(StaticData.SpeciesData.BaseStats[(int)species * 6], ivs[0], evs[0], level);
            int incStat = (int)nature / 5;
            int decStat = (int)nature % 5;
            Span<float> natMults = stackalloc float[5] { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
            if (incStat != decStat)
            {
                natMults[incStat] = 1.1f;
                natMults[decStat] = 0.9f;
            }
            for (int i = 1; i < stats.Length; i++)
            {
                stats[i] = StatFormula(StaticData.SpeciesData.BaseStats[((int)species * 6) + i], ivs[i], evs[i], level, natMults[i - 1]);
            }
            return new Stats(stats);
        }

        public static int HPFormula(int baseHP, int iv, int ev, int level)
        {
            return (((2 * baseHP) + iv + (ev / 4)) * level / 100) + level + 10;
        }

        public static int StatFormula(int baseStat, int iv, int ev, int level, float natMult)
        {
            return (int)(((((2 * baseStat) + iv + (ev / 4)) * level / 100) + 5) * natMult);
        }
    }
}
