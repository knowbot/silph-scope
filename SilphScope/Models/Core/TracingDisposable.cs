using System;
using System.Diagnostics;

namespace SilphScope.Models.Core;

/// <summary>
/// Quick and dirty class to help track missing Dispose statements.
/// </summary>
public class TracingDisposable : IDisposable
{
    public bool IsDisposed { get; private set; }

    protected virtual void Dispose(bool disposing)
    {

    }

    public void Dispose()
    {
        if (IsDisposed)
        {
            return;
        }
        GC.SuppressFinalize(this);
        Dispose(true);
        IsDisposed = true;
    }

    ~TracingDisposable()
    {
        if (!IsDisposed)
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
