using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models;
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
            SilphScopeLogger.Message += SilphScopeLogger_Message;
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

            SilphScopeLogger.Message -= SilphScopeLogger_Message;

            isDisposed = true;
        }
    }
}
