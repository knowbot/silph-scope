using Avalonia;
using Avalonia.Media.Imaging;
using SilphScope.Models.Games.StaticData.Enums;
using System;
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
			_thread = new Thread(ThreadLoop) { IsBackground = true, Name = GetType().Name };
			_thread.Start();
		}

		private void ThreadLoop()
		{
			while (_requests.Wait(out SpriteLoadRequest? request))
			{
				// Try loading from disk.
				if (!SpriteStorageManager.Current.Load(request!.Species, out Bitmap? sprite))
				{
					// Not on disk. Download.
					// TODO: delegate to dedicated class.
					try
					{
						using (HttpClient client = new HttpClient())
						{
							string url = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{(int)request!.Species}.png";
							using (HttpResponseMessage response = client.GetAsync(url).Result)
							using (Stream stream = response.Content.ReadAsStreamAsync().Result)
							{
								sprite = new Bitmap(stream);
							}
						}
					}
					catch (Exception)
					{
						// There was some issue.
						sprite = default;
					}

					// Save it to disk for later use.
					if (sprite != null)
					{
						SpriteStorageManager.Current.Save(request!.Species, sprite);
					}
				}

				// Set default sprite.
				// TODO: proper default sprite.
				if (sprite == null)
				{
					sprite = new WriteableBitmap(new PixelSize(1, 1), Vector.Zero);
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
