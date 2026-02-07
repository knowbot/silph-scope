using Avalonia.Media.Imaging;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace SilphScope.Models.Core.Sprites
{
    public class SpriteCloudManager
    {
        public bool Download(ref readonly SpriteIdentifier identifier, out Bitmap? sprite)
        {
            using HttpClient client = new();
            string url = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{(int)identifier.Species}.png";
            using HttpResponseMessage response = client.GetAsync(url).Result;

            // Sprite does not exist.
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                sprite = default;
                return false;
            }

            // Sprite could not be retrieved.
            if (!response.IsSuccessStatusCode)
            {
                // TODO: throw more appropriate exception.
            }

            using Stream stream = response.Content.ReadAsStreamAsync().Result;
            sprite = new Bitmap(stream);
            return true;
        }
    }
}
