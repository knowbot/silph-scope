using System;
using System.Net.Http;

namespace SilphScope.Models.Core.Sprites
{
    public class SpriteCloudManager
    {
        public void Foo()
        {
            HttpClient client = new();
            client.BaseAddress = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png");

            // Add an Accept header for JSON format.
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                string dataObjects = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }
}
