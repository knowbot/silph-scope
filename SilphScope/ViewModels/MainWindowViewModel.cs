using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core;
using SilphScope.Models.Games;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace SilphScope.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IDisposable
{
    [ObservableProperty]
    private bool _IsAttached = false;

    partial void OnIsAttachedChanged(bool value)
    {
        if (value)
        {
            // No process to attach to.
            if (SelectedProcess == null)
            {
                IsAttached = false;
                return;
            }

            service = new SilphService(SelectedProcess.Process, Game.Supported[0]); // TODO: replace with dropdown game selection
            service.OnMessage += Watch_OnMessage;
        }
        else
        {
            if (service != null)
            {
                service.Dispose();
                service.OnMessage -= Watch_OnMessage;
                service = null;
            }
        }
    }

    [ObservableProperty]
    private ObservableCollection<ProcessViewModel> _Processes = [];

    [ObservableProperty]
    private ProcessViewModel? _SelectedProcess;

    private SilphService? service;

    private void RefreshProcesses()
    {
        // Filter processes based on MainWindowTitle.
        Processes = new(Process.GetProcesses().Select(x => new ProcessViewModel(x)).Where(x => !string.IsNullOrEmpty(x.MainWindowTitle)));
        SelectedProcess = Processes.FirstOrDefault();
    }

    partial void OnSelectedProcessChanged(ProcessViewModel? value)
    {
        IsAttached = false;
    }

    [ObservableProperty]
    private LogViewModel _Log = new();

    [ObservableProperty]
    private TeamTabViewModel _TeamTab = new();

    [ObservableProperty]
    private BoxTabViewModel _BoxTab = new();

    public MainWindowViewModel()
    {
        RefreshProcesses();
    }

    private void Watch_OnMessage(SilphService sender, string message)
    {
        SilphLogger.Log(message);
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