using SilphScope.Models.Memory;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace SilphScope.Models
{
    public class ProcessWatch : TracingDisposable
    {
        public delegate void ProcessWatchMessageHandler(ProcessWatch sender, string message);
        public event ProcessWatchMessageHandler? OnMessage;

        private object locker = new object();
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
                    ProcessMemory<WindowsMemoryAccess> reader = new ProcessMemory<WindowsMemoryAccess>(target);
                    List<nint> aobRes = reader.PatternScanAll("5B 53 44 4B 2B 4E 49 4E 54 45 4E 44 4F 3A 42 41 43 4B 55 50");

                    if (aobRes.Count == 0)
                    {
                        OnMessage?.Invoke(this, "No matches found.");
                    }

                    foreach (nint res in aobRes)
                    {
                        OnMessage?.Invoke(this, "Found match at: " + res.ToString("X"));
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
