using SilphScope.Models.Games.MemoryLayouts;

namespace SilphScope.Models.Games
{
    public record Game(string Name, string ProductId, GenEnum Generation, IMemoryLayout Layout)
    {
        public string Name = Name;
        public string ProductId = ProductId;
        public GenEnum Generation = Generation;
        public IMemoryLayout Layout = Layout;
    }
}
