using SilphScope.Models.Core;
using SilphScope.Models.Games.MemoryLayouts;
using SilphScope.Models.Games.Parsers.Gen4.Text;
using SilphScope.Models.Games.State.Common;
using System;
using System.Runtime.InteropServices;

namespace SilphScope.Models.Games.Parsers.Common
{
    public class TrainerParser
    {
        public static Trainer Parse(SilphContext context)
        {
            byte[] buffer = context.Data;
            IMemoryLayout layout = context.Game.Layout;
            string name = Gen4Decoder.Decode(buffer.AsSpan(layout.TrainerName, 16));
            ushort trainerId = MemoryMarshal.Read<ushort>(buffer.AsSpan(layout.TrainerID));
            uint money = MemoryMarshal.Read<uint>(buffer.AsSpan(layout.Money));
            bool gender = MemoryMarshal.Read<bool>(buffer.AsSpan(layout.Gender));
            byte badges = MemoryMarshal.Read<byte>(buffer.AsSpan(layout.Badges));
            return new Trainer(name, trainerId, money, gender, badges);
        }
    }
}
