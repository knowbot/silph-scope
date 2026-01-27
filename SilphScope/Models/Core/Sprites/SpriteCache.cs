using Avalonia.Media.Imaging;
using SilphScope.Models.Games.StaticData.Enums;
using System.Collections.Generic;

namespace SilphScope.Models.Core.Sprites
{
    /// <summary>
    /// Class to simplify indexing sprites locally. It just wraps a dictionary.
    /// </summary>
    public class SpriteCache
    {
        private readonly Dictionary<SpriteFlags, Dictionary<Species, Bitmap>> _map = [];

        public Bitmap this[Species species, SpriteFlags flags]
        {
            get => _map[flags][species];
            set
            {
                if (!_map.TryGetValue(flags, out Dictionary<Species, Bitmap>? submap))
                {
                    submap = [];
                    _map[flags] = submap;
                }
                submap[species] = value;
            }
        }
    }
}
