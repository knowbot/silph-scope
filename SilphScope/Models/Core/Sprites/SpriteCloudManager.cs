using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;
using Avalonia.Media.Imaging;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Core.Sprites;

public class SpriteCloudManager
{
    private static readonly HttpClient s_client = new();
    private readonly Dictionary<SpriteIdentifier, string> _urlCache = new();
    private readonly Dictionary<string, Bitmap> _spriteCache = new();

    public bool Download(ref readonly SpriteIdentifier identifier, out Bitmap? sprite)
    {
        // First get the url for the sprite.
        if (!GetSpriteUrl(in identifier, out string? url))
        {
            sprite = default;
            return false;
        }

        // Then download the sprite.
        if (!GetSpriteFromUrl(url!, out sprite))
        {
            sprite = default;
            return false;
        }

        return true;
    }

    private bool GetSpriteUrl(ref readonly SpriteIdentifier identifier, out string? url)
    {
        // Have we already found the url for this identifier?
        if (_urlCache.TryGetValue(identifier, out url))
        {
            return true;
        }

        // Download pokemon's metadata.
        if (!DownloadJson($"https://pokeapi.co/api/v2/pokemon/{(int)identifier.Species}", out JsonNode? json))
        {
            url = default;
            return false;
        }

        // Find sprite's address.
        string spriteKey = "front_";
        if (identifier.Shiny)
        {
            spriteKey += "shiny_";
        }
        if (identifier.Gender == Gender.Female)
        {
            // Default to other sprite if null (can only happen if female I presume).
            url = json!["sprites"]![spriteKey + "female"]?.GetValue<string>();
            url ??= json!["sprites"]![spriteKey + "default"]!.GetValue<string>();
        }
        else
        {
            url = json!["sprites"]![spriteKey + "default"]!.GetValue<string>();
        }

        // Save to cache before returning.
        _urlCache[identifier] = url;
        return true;
    }

    private bool GetSpriteFromUrl(string url, out Bitmap? sprite)
    {
        // Have we already downloaded this url?
        if (_spriteCache.TryGetValue(url, out sprite))
        {
            return true;
        }

        // Download the bitmap and cache it.
        if (DownloadBitmap(url, out sprite))
        {
            _spriteCache[url] = sprite!;
            return true;
        }

        return false;
    }

    private static bool DownloadJson(string url, out JsonNode? json)
    {
        using HttpResponseMessage response = s_client.GetAsync(url).Result;

        // Page does not exist.
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            json = default;
            return false;
        }

        json = JsonNode.Parse(response.Content.ReadAsStreamAsync().Result);
        return true;
    }

    private static bool DownloadBitmap(string url, out Bitmap? bitmap)
    {
        using HttpResponseMessage response = s_client.GetAsync(url).Result;

        // Page does not exist.
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            bitmap = default;
            return false;
        }

        bitmap = new(response.Content.ReadAsStreamAsync().Result);
        return true;
    }
}
