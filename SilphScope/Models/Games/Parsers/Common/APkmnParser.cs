using SilphScope.Models.Core;
using SilphScope.Models.Games.State.Common;
using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData.Enums;
using System;
using System.Collections.Generic;

namespace SilphScope.Models.Games.Parsers.Common
{
    public abstract class APkmnParser
    {
        public abstract List<Pokemon> ParseBoxes(SilphContext context);
        public abstract List<Pokemon> ParseParty(SilphContext context);
        public abstract Pokemon Parse(ReadOnlySpan<byte> pkmnData);
        protected abstract Move[] ParseMoves(ReadOnlySpan<byte> blockB);

        public virtual Level GetLevel(ushort species, uint experience)
        {
            GrowthRate growRate = (GrowthRate)StaticData.SpeciesData.GrowRate[(int)species];

            ReadOnlySpan<uint> expTable = growRate switch
            {
                GrowthRate.MediumFast => StaticData.ExpCurve.MediumFast,
                GrowthRate.Erratic => StaticData.ExpCurve.Erratic,
                GrowthRate.Fluctuating => StaticData.ExpCurve.MediumFast,
                GrowthRate.MediumSlow => StaticData.ExpCurve.MediumFast,
                GrowthRate.Fast => StaticData.ExpCurve.MediumFast,
                GrowthRate.Slow => StaticData.ExpCurve.MediumFast,
                _ => throw new ArgumentException("Invalid growth rate")
            };

            int level = expTable.BinarySearch(experience);
            if (level >= 0)
            {
                level += 1;
                return new((byte)level, level >= 100 ? 0 : expTable[level]);
            }
            return new((byte)(~level - 1), expTable[~level]);
        }
    }
}
