using System.Collections.Generic;
using System.Threading;

namespace SilphScope.Models.Core
{
    /// <summary>
    /// Thread-safe queue meant for 1 producer - N consumers scenario.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CloseableWaitingQueue<T> : TracingDisposable
    {
        private readonly object locker = new();
        private readonly Queue<T> queue = new();
        private bool isClosed;

        public void Enqueue(T item)
        {
            lock (locker)
            {
                queue.Enqueue(item);
                Monitor.PulseAll(locker);
            }
        }

        public bool Wait(out T? item)
        {
            lock (locker)
            {
                // Wait for an element to arrive.
                while (queue.Count == 0 && !isClosed)
                {
                    Monitor.Wait(locker);
                }

                // No more elements will arrive.
                if (isClosed)
                {
                    item = default;
                    return false;
                }

                // An element has arrived.
                item = queue.Dequeue();
                return true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            lock (locker)
            {
                isClosed = true;
                Monitor.PulseAll(locker);
            }
            base.Dispose(disposing);
        }
    }
}
