using SilphScope.Models.Core;
using SilphScope.Models.Games.Data;
using SilphScope.Models.Games.Data.Enums;
using SilphScope.Models.Games.State.Common;
using SilphScope.Models.Games.State.Common.PkmnInfo;
using System;
using System.Collections.Generic;


namespace SilphScope.Models.Games.Parsers.Common
{
    public abstract class APkmnParser
    {
        public abstract List<Pokemon> ParseBoxes(SilphContext context);
        public abstract List<Pokemon> ParseParty(SilphContext context);
        protected abstract Pokemon Parse(ReadOnlySpan<byte> pkmnData);

        protected virtual Level GetLevel(ushort species, uint experience)
        {
            GrowthRate growRate = (GrowthRate)GameData.GrowRates[(int)species];

            ReadOnlySpan<uint> expTable = growRate switch
            {
                GrowthRate.MediumFast => GameData.ExpMediumFast,
                GrowthRate.Erratic => GameData.ExpErratic,
                GrowthRate.Fluctuating => GameData.ExpMediumFast,
                GrowthRate.MediumSlow => GameData.ExpMediumFast,
                GrowthRate.Fast => GameData.ExpMediumFast,
                GrowthRate.Slow => GameData.ExpMediumFast,
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
