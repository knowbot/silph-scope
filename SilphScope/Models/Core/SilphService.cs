using SilphScope.Models.Games;
using SilphScope.Models.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SilphScope.Models.Core
{
    public class SilphService : TracingDisposable
    {
        public delegate void ProcessWatchMessageHandler(SilphService sender, string message);
        public event ProcessWatchMessageHandler? OnMessage;

        private readonly Lock locker = new();
        private readonly Thread thread;
        private bool shouldStop;

        private bool initialized;
        private readonly Process target;
        private readonly ProcessMemory processMemory;
        private SilphContext? context;

        public SilphService(Process process)
        {
            target = process;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                processMemory = new ProcessMemory(process, new WindowsMemoryAccess());
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                processMemory = new ProcessMemory(process, new LinuxMemoryAccess());
            }
            else
            {
                throw new PlatformNotSupportedException("SilphScope does not support the current OS.");
            }

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
                    // Move initialization code to dedicated method

                    Game game = Game.Supported[0]; // Get game
                    List<nint> candidateAddresses = processMemory.PatternScanAll(game.Layout.AnchorString); // Find memory signature

                    if (candidateAddresses.Count == 0)
                    {
                        OnMessage?.Invoke(this, "No matches found.");
                    }

                    foreach (nint res in candidateAddresses)
                    {
                        OnMessage?.Invoke(this, "Found match at: 0x" + res.ToString("X"));
                        nint baseAddr = res - game.Layout.Anchor;
                        // Verify candidate address is good
                        nint savePtr = BitConverter.ToInt32(processMemory.Read(baseAddr + game.Layout.SavePointer, 4));
                        if (savePtr != 0)
                        {
                            OnMessage?.Invoke(this, "Save data address found at: 0x" + savePtr.ToString("X"));
                            context = new SilphContext(game, baseAddr); // Make context
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
