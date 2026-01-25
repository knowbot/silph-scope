using SilphScope.Models.Games.State.Common;
using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData.Enums;
using System;

namespace SilphScope.Models.Games.Parsers.Common
{
    public abstract class APkmnParser
    {
        public abstract Pkmn? Parse(ReadOnlySpan<byte> pkmnData);
        protected abstract Move[] ParseMoves(ReadOnlySpan<byte> blockB);
        protected abstract EVs ParseEVs(ReadOnlySpan<byte> block);
        protected abstract IVs ParseIVs(ReadOnlySpan<byte> block);
        public abstract int GetBoxPkmnSize();
        public abstract int GetPartyPkmnSize();
        public virtual Level GetLevel(ushort species, uint experience)
        {
            GrowthRate growRate = (GrowthRate)StaticData.SpeciesData.GrowRate[(int)species];

            ReadOnlySpan<uint> expTable = growRate switch
            {
                GrowthRate.MediumFast => StaticData.ExpCurve.MediumFast,
                GrowthRate.Erratic => StaticData.ExpCurve.Erratic,
                GrowthRate.Fluctuating => StaticData.ExpCurve.Fluctuating,
                GrowthRate.MediumSlow => StaticData.ExpCurve.MediumSlow,
                GrowthRate.Fast => StaticData.ExpCurve.Fast,
                GrowthRate.Slow => StaticData.ExpCurve.Slow,
                _ => throw new ParserException("Invalid growth rate")
            };
            if (experience >= expTable[^1]) return new(100, 0, 0);
            int level = expTable.BinarySearch(experience);
            level = level < 0 ? ~level : level + 1;
            if (level <= 1) return new(1, experience, expTable[0]);
            uint progress = experience - expTable[level - 1];
            uint toNext = expTable[level] - expTable[level - 1];
            return new((byte)(level + 1), progress, toNext);
        }
    }
}
