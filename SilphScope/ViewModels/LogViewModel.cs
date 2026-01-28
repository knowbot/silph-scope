using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SilphScope.ViewModels
{
    public partial class LogViewModel : ViewModelBase, IDisposable
    {
        private bool _isDisposed;
        private const int _messageDurationMs = 5000;

        [ObservableProperty]
        private ObservableCollection<string> _messages = [];

        public LogViewModel()
        {
            SilphLogger.Message += SilphScopeLogger_Message;
        }

        private void SilphScopeLogger_Message(object sender, string message)
        {
            Messages.Add(message);

            // Delay and then come back to main thread to remove message.
            Task.Delay(_messageDurationMs).ContinueWith(_ => Dispatcher.UIThread.Post(() => RemoveMessage(message)));
        }

        private void RemoveMessage(string message)
        {
            Messages.RemoveAt(Messages.IndexOf(message));
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            SilphLogger.Message -= SilphScopeLogger_Message;

            _isDisposed = true;
        }
    }
}
