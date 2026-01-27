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
        private const int MessageDurationMs = 5000;

        [ObservableProperty]
        private ObservableCollection<string> _Messages = [];

        public LogViewModel()
        {
            SilphLogger.Message += SilphScopeLogger_Message;
        }

        private void SilphScopeLogger_Message(object sender, string message)
        {
            Messages.Add(message);

            // Delay and then come back to main thread to remove message.
            Task.Delay(MessageDurationMs).ContinueWith(_ => Dispatcher.UIThread.Post(() => RemoveMessage(message)));
        }

        private void RemoveMessage(string message)
        {
            Messages.RemoveAt(Messages.IndexOf(message));
        }

        private bool isDisposed;

        public void Dispose()
        {
            if (isDisposed)
            {
                return;
            }

            SilphLogger.Message -= SilphScopeLogger_Message;

            isDisposed = true;
        }
    }
}
