using System;
using System.Collections.Generic;
using System.Threading;

namespace SilphScope.Models.Core.Sprites;

public class SpriteLoadTask
{
    private SpriteLoadResult? _result;
    public SpriteLoadResult Result
    {
        get
        {
            Wait();
            return _result!;
        }
    }

    private readonly object _locker = new();
    private bool _completed;
    private readonly List<Action> _onCompletedActions = [];

    public SpriteLoadTask() { }

    public void Wait()
    {
        lock (_locker)
        {
            if (!_completed)
            {
                Monitor.Wait(_locker);
            }
        }
    }

    public void Complete(SpriteLoadResult result)
    {
        lock (_locker)
        {
            if (_completed)
            {
                throw new InvalidOperationException("Cannot complete a task twice.");
            }

            _completed = true;
            _result = result;
        }

        foreach (Action action in _onCompletedActions)
        {
            action?.Invoke();
        }

        lock (_locker)
        {
            Monitor.PulseAll(_locker);
        }
    }

    public void OnCompleted(Action action)
    {
        lock (_locker)
        {
            if (_completed)
            {
                action?.Invoke();
            }
            else
            {
                _onCompletedActions.Add(action);
            }
        }
    }
}
