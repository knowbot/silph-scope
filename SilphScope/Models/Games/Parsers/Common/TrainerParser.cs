using SilphScope.Models.Core;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.Parsers.Gen4.Text;
using SilphScope.Models.Games.State.Common;
using System;

namespace SilphScope.Models.Games.Parsers.Common
{
    public class TrainerParser
    {
        public Trainer Parse(SilphContext context)
        {
            ReadOnlySpan<byte> data = context.Data;
            IMemoryLayout layout = context.Game.Layout;
            string name = Gen4Decoder.Decode(data.Slice(layout.TrainerName, 16));
            ushort trainerId = data.Read<ushort>(layout.TrainerID);
            uint money = data.Read<uint>(layout.Money);
            bool gender = data.Read<byte>(layout.Gender) != 0;
            byte badgeFlags = data.Read<byte>(layout.Badges);
            bool[] badges = new bool[8];
            for (int i = 0; i < badges.Length; i++)
            {
                badges[i] = (badgeFlags & (1 << i)) != 0;
                //if (HasExtraBadges) ExtraBadges[i] = (trainer.ExtraBadges & (1 << i)) != 0;
            }

            return new Trainer(name, trainerId, money, gender, badges);
        }
    }
}
