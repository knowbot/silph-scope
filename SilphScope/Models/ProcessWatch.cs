using SilphScope.Models.Games;
using SilphScope.Models.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace SilphScope.Models
{
    public class ProcessWatch : TracingDisposable
    {
        public delegate void ProcessWatchMessageHandler(ProcessWatch sender, string message);
        public event ProcessWatchMessageHandler? OnMessage;

        private Lock locker = new();
        private Thread thread;
        private bool shouldStop;

        private bool initialized;
        private Process target;

        public ProcessWatch(Process process)
        {
            target = process;
            thread = new Thread(ThreadLoop) { IsBackground = true };
            thread.Start();
        }

        private void ThreadLoop()
        {
            while (!ShouldStop())
            {
                // First iteration: check process' info.
                if (!initialized)
                {
                    ProcessMemory<WindowsMemoryAccess> reader = new(target);
                    Game game = Game.Supported[0];
                    List<nint> aobRes = reader.PatternScanAll(game.Layout.AnchorString);

                    if (aobRes.Count == 0)
                    {
                        OnMessage?.Invoke(this, "No matches found.");
                    }

                    foreach (nint res in aobRes)
                    {
                        OnMessage?.Invoke(this, "Found match at: 0x" + res.ToString("X"));
                        nint baseAddr = res - game.Layout.Anchor;
                        nint savePtr = BitConverter.ToInt32(reader.ReadMemory(baseAddr + game.Layout.SavePointer, 4));
                        if (savePtr != 0)
                        {
                            OnMessage?.Invoke(this, "Save data address found at: 0x" + savePtr.ToString("X"));
                        }
                    }

                    initialized = true;
                }
            }
        }

        protected bool ShouldStop()
        {
            lock (locker)
            {
                return shouldStop;
            }
        }

        protected override void Dispose(bool disposing)
        {
            lock (locker)
            {
                shouldStop = true;
            }
            thread.Join();
            base.Dispose(disposing);
        }
    }
}
