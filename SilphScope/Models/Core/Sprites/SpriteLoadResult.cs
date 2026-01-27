using Avalonia.Media.Imaging;
using System;

namespace SilphScope.Models.Core.Sprites
{
    public class SpriteLoadResult
    {
        public readonly Bitmap? Sprite;
        public readonly Exception? Error;

        public SpriteLoadResult(Bitmap? sprite, Exception? error)
        {
            Sprite = sprite;
            Error = error;
        }
    }
}
