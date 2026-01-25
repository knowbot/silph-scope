using SilphScope.Models.Core;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.Parsers.Common;
using SilphScope.Models.Games.State.Common;
using System;

namespace SilphScope.Models.Games.Parsers.Gen4
{
    public class Gen4PartyParser : IPartyParser
    {
        public Pkmn[] Parse(SilphContext context)
        {
            Gen4PkmnParser pkmnParser = new();
            IMemoryLayout layout = context.Game.Layout;
            ReadOnlySpan<byte> data = context.Data;
            byte partyCount = data.Read<byte>(layout.PartyCount);
            Pkmn[] party = new Pkmn[partyCount];
            for (int i = 0; i < partyCount; i++)
            {
                int pkmnAddr = layout.Party + (i * pkmnParser.GetPartyPkmnSize());
                Pkmn? pkmn = pkmnParser.Parse(data[pkmnAddr..]);
                if (pkmn != null) party[i] = pkmn;
            }
            return party;
        }
    }
}
