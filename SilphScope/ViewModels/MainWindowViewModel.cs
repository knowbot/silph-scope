using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core;
using SilphScope.Models.Games;
using System;
using System.Collections.Generic;
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
            // No process to attach to / game to scan for.
            if (SelectedProcess == null || SelectedGame == null)
            {
                IsAttached = false;
                return;
            }
            Service = new SilphService(SelectedProcess.Process, SelectedGame.Game); // TODO: replace with dropdown game selection
            Service.OnMessage += Watch_OnMessage;
        }
        else
        {
            if (Service != null)
            {
                Service.Dispose();
                Service.OnMessage -= Watch_OnMessage;
                Service = null;
            }
        }
    }

    [ObservableProperty]
    private ObservableCollection<ProcessViewModel> _Processes = [];

    [ObservableProperty]
    private ProcessViewModel? _SelectedProcess;


    public List<GameViewModel> SupportedGames { get; private set; }

    [ObservableProperty]
    private GameViewModel? _SelectedGame;

    [ObservableProperty]
    private SilphService? _service;

    public void RefreshProcesses()
    {
        List<Process> newProcesses = Process.GetProcesses()
            .Where(x => !string.IsNullOrEmpty(x.MainWindowTitle))
            .ToList();
        HashSet<int> newPids = newProcesses.Select(p => p.Id).ToHashSet();
        HashSet<int> currPids = Processes.Select(p => p.Pid).ToHashSet();

        for (int i = Processes.Count - 1; i >= 0; i--)
        {
            if (!newPids.Contains(Processes[i].Pid))
            {
                Processes.RemoveAt(i);
            }
        }

        foreach (Process process in newProcesses)
        {
            if (!currPids.Contains(process.Id))
            {
                Processes.Add(new ProcessViewModel(process));
            }
        }

        if (SelectedProcess == null && Processes.Count > 0)
        {
            SelectedProcess = Processes.FirstOrDefault();
        }
    }

    partial void OnSelectedProcessChanged(ProcessViewModel? value)
    {
        IsAttached = false;
    }

    partial void OnSelectedGameChanged(GameViewModel? value)
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
        SupportedGames = new(Game.Supported.Select(g => new GameViewModel(g)));

        // TODO: remove fake data.

        // TeamTab.UpdateData(game.Team);
        // BoxTab.UpdateData(game.Boxes);
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