using Avalonia.Media.Imaging;
using System;
using System.Threading;

namespace SilphScope.Models.Core.Sprites
{
	public class SpriteLoadResult
	{
		public Bitmap? Sprite { get; private set; }

		public Bitmap Result
		{
			get
			{
				Wait();
				// TODO: throw error.
				return Sprite!;
			}
		}

		private object _locker = new();

		public SpriteLoadResult() { }

		internal void Fill(Bitmap sprite)
		{
			lock (_locker)
			{
				if (Sprite != null)
				{
					throw new InvalidOperationException("Double completion of task is not allowed.");
				}
				Sprite = sprite;
				Monitor.PulseAll(_locker);
			}
		}

		internal void Complete(Exception exception)
		{
			// TODO.
		}

		internal void Wait()
		{
			lock (_locker)
			{
				if (Sprite != null)
				{
					return;
				}
				Monitor.Wait(_locker);
			}
		}
	}
}
