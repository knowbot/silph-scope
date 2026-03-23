using System.Collections.Generic;
using System.Threading;

namespace SilphScope.Models.Core;

/// <summary>
/// Thread-safe queue meant for 1 producer - N consumers scenario.
/// </summary>
/// <typeparam name="T"></typeparam>
public class CloseableWaitingQueue<T> : TracingDisposable
{
    private readonly object _locker = new();
    private readonly Queue<T> _queue = new();
    private bool _isClosed;

    public void Enqueue(T item)
    {
        lock (_locker)
        {
            _queue.Enqueue(item);
            Monitor.PulseAll(_locker);
        }
    }

    public bool Wait(out T? item)
    {
        lock (_locker)
        {
            // Wait for an element to arrive.
            while (_queue.Count == 0 && !_isClosed)
            {
                Monitor.Wait(_locker);
            }

            // No more elements will arrive.
            if (_isClosed)
            {
                item = default;
                return false;
            }

            // An element has arrived.
            item = _queue.Dequeue();
            return true;
        }
    }

    protected override void Dispose(bool disposing)
    {
        lock (_locker)
        {
            _isClosed = true;
            Monitor.PulseAll(_locker);
        }
        base.Dispose(disposing);
    }
}
