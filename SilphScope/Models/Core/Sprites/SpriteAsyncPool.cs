using Avalonia;
using Avalonia.Media.Imaging;
using SilphScope.Models.Games.StaticData.Enums;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SilphScope.Models.Core.Sprites
{
	/// <summary>
	/// This class allows asynchronously fetching sprites.
	/// </summary>
	public class SpriteAsyncPool : TracingDisposable
	{
		public static SpriteAsyncPool Current { get; } = new();

		private CloseableWaitingQueue<SpriteLoadRequest> _requests = new();
		private Thread _thread;

		private SpriteAsyncPool()
		{
			_thread = new Thread(ThreadLoop) { IsBackground = true };
			_thread.Start();
		}

		private void ThreadLoop()
		{
			while (_requests.Wait(out SpriteLoadRequest? request))
			{
				Bitmap? sprite = new WriteableBitmap(new PixelSize(1, 1), Vector.Zero);

				// Load the sprite.
				// TODO: delegate to dedicated class.
				using (HttpClient client = new HttpClient())
				{
					string url = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{(int)request!.Species}.png";
					using (HttpResponseMessage response = client.GetAsync(url).Result)
					using (Stream stream = response.Content.ReadAsStreamAsync().Result)
					{
						sprite = new Bitmap(stream);
					}
				}

				// Push the result to the task.
				request!.Result.Fill(sprite);
			}
		}

		public Task<SpriteLoadResult> Load(Species species, SpriteFlags flags)
		{
			SpriteLoadResult result = new SpriteLoadResult();
			_requests.Enqueue(new SpriteLoadRequest(result, species, flags));
			return Task.Run(() => { result.Wait(); return result; });
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}
