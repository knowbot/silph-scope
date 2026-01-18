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
        public static Trainer Parse(SilphContext context)
        {
            ReadOnlySpan<byte> data = context.Data;
            IMemoryLayout layout = context.Game.Layout;
            string name = Gen4Decoder.Decode(data.Slice(layout.TrainerName, 16));
            ushort trainerId = data.Read<ushort>(layout.TrainerID);
            uint money = data.Read<uint>(layout.Money);
            bool gender = data.Read<byte>(layout.Gender) != 0;
            byte badges = data.Read<byte>(layout.Badges);
            return new Trainer(name, trainerId, money, gender, badges);
        }
    }
}
