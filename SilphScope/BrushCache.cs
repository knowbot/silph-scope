using System.Collections.Generic;
using Avalonia.Media;

namespace SilphScope;

public class BrushCache
{
    private readonly Dictionary<Color, IBrush> _brushes = new();

    public BrushCache() { }

    public IBrush Get(Color color)
    {
        if (!_brushes.TryGetValue(color, out IBrush? brush))
        {
            brush = new SolidColorBrush(color);
            _brushes[color] = brush;
        }
        return brush;
    }
}
