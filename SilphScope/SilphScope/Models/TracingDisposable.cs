using System;
using System.Diagnostics;

namespace SilphScope.Models
{
    /// <summary>
    /// Quick and dirty class to help track missing Dispose statements.
    /// </summary>
    public class TracingDisposable : IDisposable
    {
        private bool isDisposed;

        protected virtual void Dispose(bool disposing)
        {

        }

        public void Dispose()
        {
            if (isDisposed)
            {
                return;
            }

            Dispose(true);

            isDisposed = true;
        }

        ~TracingDisposable()
        {
            if (!isDisposed)
            {
                // Missing dispose statement!
                Dispose(false);
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }
        }
    }
}
