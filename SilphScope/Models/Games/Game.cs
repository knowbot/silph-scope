using SilphScope.Models.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilphScope.Models.Games
{
    public record Game(string Name, string ProductId, GenEnum Generation, IGameOffsets Offsets)
    {
        public string Name = Name;
        public string ProductId = ProductId;
        public GenEnum Generation = Generation;
        public IGameOffsets Offsets = Offsets;
    }
}
