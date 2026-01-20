using Avalonia.Media.Imaging;
using SilphScope.Models.Games.Data.Enums;
using System.Collections.Generic;

namespace SilphScope.Models.Core.Sprites
{
	/// <summary>
	/// Class to simplify indexing sprites locally. It just wraps a dictionary.
	/// </summary>
	public class SpriteCache
	{
		private Dictionary<SpriteFlags, Dictionary<Species, Bitmap>> _map = new();

		public Bitmap this[Species species, SpriteFlags flags]
		{
			get
			{
				return _map[flags][species];
			}
			set
			{
				if (!_map.TryGetValue(flags, out Dictionary<Species, Bitmap>? submap))
				{
					submap = new Dictionary<Species, Bitmap>();
					_map[flags] = submap;
				}
				submap[species] = value;
			}
		}
	}
}
