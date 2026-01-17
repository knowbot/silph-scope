using SilphScope.Models.Core;
using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.Parsers.Gen4.Text;
using SilphScope.Models.Games.State.Common;
using System;

namespace SilphScope.Models.Games.Parsers.Common
{
    public class TrainerParser : AParser
    {
        public static Trainer Parse(SilphContext context)
        {
            ReadOnlySpan<byte> data = context.Data;
            IMemoryLayout layout = context.Game.Layout;
            string name = Gen4Decoder.Decode(data.Slice(layout.TrainerName, 16));
            ushort trainerId = ReadAt<ushort>(data, layout.TrainerID);
            uint money = ReadAt<uint>(data, layout.Money);
            bool gender = ReadAt<byte>(data, layout.Gender) != 0;
            byte badges = ReadAt<byte>(data, layout.Badges);
            return new Trainer(name, trainerId, money, gender, badges);
        }
    }
}
