using SilphScope.Models.Core;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.Parsers.Common;
using SilphScope.Models.Games.State.Common;
using System;
using System.Collections.Generic;

namespace SilphScope.Models.Games.Parsers.Gen4
{
    public class Gen4PartyParser : IPartyParser
    {
        public List<Pokemon> ParseParty(SilphContext context)
        {
            Gen4PkmnParser pkmnParser = new();
            ReadOnlySpan<byte> data = context.Data;
            IMemoryLayout layout = context.Game.Layout;
            byte partyCount = data.Read<byte>(layout.PartyCount);
            Pokemon[] party = new Pokemon[partyCount];
            for (int i = 0; i < partyCount; i++)
            {
                int pkmnAddr = layout.Party + (i * pkmnParser.GetPartyPkmnSize());
                party[i] = pkmnParser.Parse(data[pkmnAddr..]);
            }
            return [.. party];
        }
    }
}
