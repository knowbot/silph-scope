using SilphScope.Models.Core;
using SilphScope.Models.Games.Data;
using SilphScope.Models.Games.Data.Enums;
using SilphScope.Models.Games.State.Common;
using System;
using System.Collections.Generic;

namespace SilphScope.Models.Games.Parsers.Common
{
    public abstract class APkmnParser
    {
        public abstract List<Pokemon> ParseBoxes(SilphContext context);
        public abstract List<Pokemon> ParseParty(SilphContext context);
        protected abstract Pokemon Parse(ReadOnlySpan<byte> pkmnData);

        protected virtual byte GetLevel(Species species, uint experience)
        {
            GrowthRate growRate = (GrowthRate)GameData.GrowRates[(int)species];
            int level = 0;
            switch (growRate)
            {
                // TODO: fill out cases
                case GrowthRate.MediumFast:
                    level = GameData.ExpMediumFast.BinarySearch(experience);
                    break;
                case GrowthRate.Erratic:
                    level = GameData.ExpErratic.BinarySearch(experience);
                    break;
                case GrowthRate.Fluctuating:
                    break;
                case GrowthRate.MediumSlow:
                    break;
                case GrowthRate.Fast:
                    break;
                case GrowthRate.Slow:
                    break;
                default:
                    break;
            }
            return level < 0 ? (byte)~level : (byte)(level + 1);
        }
    }
}
