using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core;
using System;
using System.Collections.ObjectModel;

namespace SilphScope.ViewModels
{
    public partial class LogViewModel : ViewModelBase, IDisposable
    {
        [ObservableProperty]
        private ObservableCollection<string> _Messages = [];

        public LogViewModel()
        {
            SilphLogger.Message += SilphScopeLogger_Message;
        }

        private void SilphScopeLogger_Message(object sender, string message)
        {
            Messages.Add(message);
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
