using Avalonia.Media.Imaging;
using SilphScope.Models.Games.StaticData.Enums;
using System;
using System.IO;

namespace SilphScope.Models.Core.Sprites
{
    public class SpriteStorageManager
    {
        public static SpriteStorageManager Current { get; } = new();

        private const string CacheDir = ".cache";
        private readonly string _fullCacheDirPath;

        private SpriteStorageManager()
        {
            if (Environment.ProcessPath == null)
            {
                throw new ArgumentException("Could not find executable's path.");
            }

            _fullCacheDirPath = Path.Combine(Path.GetDirectoryName(Environment.ProcessPath!)!, CacheDir);
            _ = Directory.CreateDirectory(_fullCacheDirPath);
        }

        public bool Load(Species species, out Bitmap? sprite)
        {
            string path = GetPathForSprite(species);

            if (!File.Exists(path))
            {
                sprite = default;
                return false;
            }

            sprite = new Bitmap(path);
            return true;
        }

        public void Save(Species species, Bitmap sprite)
        {
            string path = GetPathForSprite(species);
            sprite.Save(path);
        }

        private string GetPathForSprite(Species species)
        {
            return Path.Combine(_fullCacheDirPath, $"{(int)species}.png");
        }
    }
}
