using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace SilphScope.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IDisposable
{
    [ObservableProperty]
    private ObservableCollection<ProcessViewModel> _Processes = [];

    [ObservableProperty]
    private ProcessViewModel? _SelectedProcess;

    private ProcessWatch? watch;

    private void RefreshProcesses()
    {
        // Filter processes based on MainWindowTitle.
        Processes = new(Process.GetProcesses().Select(x => new ProcessViewModel(x)).Where(x => !string.IsNullOrEmpty(x.MainWindowTitle)));
        SelectedProcess = Processes.FirstOrDefault();
    }

    partial void OnSelectedProcessChanged(ProcessViewModel? value)
    {
        if (watch != null)
        {
            watch.Dispose();
            watch.OnMessage -= Watch_OnMessage;
            watch = null;
        }

        if (value == null)
        {
            return;
        }

        watch = new ProcessWatch(value.Process);
        watch.OnMessage += Watch_OnMessage;
    }

    [ObservableProperty]
    private LogViewModel _Log = new LogViewModel();

    public MainWindowViewModel()
    {
        RefreshProcesses();
    }

    private void Watch_OnMessage(ProcessWatch sender, string message)
    {
        SilphScopeLogger.Log(message);
    }

    private bool isDisposed;

    public void Dispose()
    {
        if (isDisposed)
        {
            return;
        }

        Log.Dispose();

        isDisposed = true;
    }
}