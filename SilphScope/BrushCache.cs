using Avalonia.Media;
using System.Collections.Generic;

namespace SilphScope
{
	public class BrushCache
	{
		private Dictionary<Color, IBrush> brushes = new();

		public BrushCache() { }

		public IBrush Get(Color color)
		{
			if (!brushes.TryGetValue(color, out IBrush? brush))
			{
				brush = new SolidColorBrush(color);
				brushes[color] = brush;
			}
			return brush;
		}
	}
}
