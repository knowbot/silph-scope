using System;
using System.IO;
using Avalonia.Media.Imaging;

namespace SilphScope.Models.Core.Sprites;

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

    public bool Load(SpriteIdentifier identifier, out Bitmap? sprite)
    {
        string path = GetPathForSprite(identifier);

        if (!File.Exists(path))
        {
            sprite = default;
            return false;
        }

        sprite = new Bitmap(path);
        return true;
    }

    public void Save(SpriteIdentifier identifier, Bitmap sprite)
    {
        string path = GetPathForSprite(identifier);
        sprite.Save(path);
    }

    private string GetPathForSprite(SpriteIdentifier identifier)
    {
        return Path.Combine(_fullCacheDirPath, $"{(int)identifier.Species}_{identifier.Form}_{identifier.Gender}_{identifier.Shiny}.png");
    }
}
