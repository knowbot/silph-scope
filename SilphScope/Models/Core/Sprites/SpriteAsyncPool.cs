using Avalonia;
using Avalonia.Media.Imaging;
using SilphScope.Models.Games.State.Common;
using SilphScope.Models.Games.StaticData.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;

namespace SilphScope.Models.Core.Sprites
{
    /// <summary>
    /// This class allows asynchronously fetching sprites.
    /// </summary>
    public class SpriteAsyncPool : TracingDisposable
    {
        public static SpriteAsyncPool Current { get; } = new();

        private readonly Dictionary<SpriteIdentifier, Bitmap> _spriteCache = new();
        private readonly CloseableWaitingQueue<SpriteLoadRequest> _requests = new();
        private readonly Thread _thread;
        private readonly SpriteCloudManager _cloud = new();

        private SpriteAsyncPool()
        {
            _thread = new Thread(ThreadLoop) { IsBackground = true, Name = GetType().Name };
            _thread.Start();
        }

        private void ThreadLoop()
        {
            while (_requests.Wait(out SpriteLoadRequest? request))
            {
                try
                {
                    SpriteIdentifier identifier = request!.Identifier;

                    // Try local cache.
                    if (_spriteCache.TryGetValue(identifier, out Bitmap? sprite))
                    {
                        // Found the sprite.
                        request!.Task.Complete(new(sprite, null));
                        continue;
                    }

                    // Try loading from disk.
                    if (SpriteStorageManager.Current.Load(identifier, out sprite))
                    {
                        // Found the sprite. Cache it locally and return it.
                        _spriteCache[identifier] = sprite!;
                        request!.Task.Complete(new(sprite, null));
                        continue;
                    }

                    // Not on disk. Download.
                    if (_cloud.Download(ref identifier, out sprite))
                    {
                        // Save it to disk and locally.
                        SpriteStorageManager.Current.Save(identifier, sprite!);
                        _spriteCache[identifier] = sprite!;
                        request!.Task.Complete(new(sprite, null));
                        continue;
                    }

                    // No sprite found? Return default sprite.
                    // TODO: proper default sprite.
                    if (sprite == null)
                    {
                        // NOTE: this crashes.
                        // sprite = new WriteableBitmap(new PixelSize(1, 1), Vector.Zero);
                    }
                    request!.Task.Complete(new(sprite, null));
                } catch (Exception e)
                {
                    request!.Task.Complete(new(null, e));
                }
            }
        }

        public SpriteLoadTask Load(Pkmn pokemon)
        {
            return Load(new SpriteIdentifier(pokemon.Species, pokemon.Form, pokemon.Gender, pokemon.IsShiny));
        }

        /// <summary>
        /// Load a sprite asynchronously.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public SpriteLoadTask Load(SpriteIdentifier identifier)
        {
            SpriteLoadTask task = new();
            _requests.Enqueue(new SpriteLoadRequest(task, identifier));
            return task;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
