using Avalonia.Media.Imaging;
using SilphScope.Models.Games.StaticData.Enums;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;

namespace SilphScope.Models.Core.Sprites
{
    public class SpriteCloudManager
    {
        private Dictionary<SpriteIdentifier, string> urlCache = new();
        private Dictionary<string, Bitmap> spriteCache = new();

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
            if (urlCache.TryGetValue(identifier, out url))
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
            urlCache[identifier] = url;
            return true;
        }

        private bool GetSpriteFromUrl(string url, out Bitmap? sprite)
        {
            // Have we already downloaded this url?
            if (spriteCache.TryGetValue(url, out sprite))
            {
                return true;
            }

            // Download the bitmap and cache it.
            if (DownloadBitmap(url, out sprite))
            {
                spriteCache[url] = sprite!;
                return true;
            }

            return false;
        }

        private static bool DownloadJson(string url, out JsonNode? json)
        {
            using HttpClient client = new();
            using HttpResponseMessage response = client.GetAsync(url).Result;

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
            using HttpClient client = new();
            using HttpResponseMessage response = client.GetAsync(url).Result;

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
}
