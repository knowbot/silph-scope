using System;
using System.Collections.Generic;
using System.Threading;

namespace SilphScope.Models.Core.Sprites
{
    public class SpriteLoadTask
    {
        private SpriteLoadResult? _Result;
        public SpriteLoadResult Result
        {
            get
            {
                Wait();
                return _Result!;
            }
        }

        private readonly object _locker = new();
        private bool _completed;
        private List<Action> _onCompletedActions = new();

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
                _completed = true;
                _Result = result;
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
}
