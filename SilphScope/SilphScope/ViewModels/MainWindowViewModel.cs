using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models;
using SilphScope.Models.Memory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Tmds.DBus.Protocol;

namespace SilphScope.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{

    [ObservableProperty]
    private bool _ShowMore = false;

    partial void OnShowMoreChanged(bool value)
    {
        RefreshProcesses();
    }

    [ObservableProperty]
    private ObservableCollection<ProcessViewModel> _Processes = [];

    [ObservableProperty]
    private ProcessViewModel? _SelectedProcess;

    private void RefreshProcesses()
    {
        // Filter processes based on MainWindowTitle.
        Processes = new(Process.GetProcesses().Select(x => new ProcessViewModel(x)).Where(x => !string.IsNullOrEmpty(x.MainWindowTitle) || ShowMore));
        SelectedProcess = Processes.FirstOrDefault();
    }

    partial void OnSelectedProcessChanged(ProcessViewModel? value)
    {
        if (value == null)
        {
            return;
        }

        MemoryReader<WindowsMemoryAccess> reader = new MemoryReader<WindowsMemoryAccess>(value.Process);
        List<nint> aobRes = reader.FindPatternAll("5B 53 44 4B 2B 4E 49 4E 54 45 4E 44 4F 3A 42 41 43 4B 55 50");
        foreach (nint res in aobRes)
        {
            Debug.WriteLine("AOB scan found match at: " + res.ToString("X"));
        }
    }

    public MainWindowViewModel()
    {
        RefreshProcesses();
    }
}