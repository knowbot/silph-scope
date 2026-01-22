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
                GrowthRate.Fluctuating => StaticData.ExpCurve.Fluctuating,
                GrowthRate.MediumSlow => StaticData.ExpCurve.MediumSlow,
                GrowthRate.Fast => StaticData.ExpCurve.Fast,
                GrowthRate.Slow => StaticData.ExpCurve.Slow,
                _ => throw new ParserException("Invalid growth rate")
            };
            if (experience >= expTable[99]) return new(100, expTable[99]);
            int level = expTable.BinarySearch(experience);
            level = level < 0 ? ~level : level + 1;
            return new((byte)level, expTable[level]);
        }
    }
}
