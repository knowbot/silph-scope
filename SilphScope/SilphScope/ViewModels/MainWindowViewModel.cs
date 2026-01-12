using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace SilphScope.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    #region ShowMore

    [ObservableProperty]
    private bool _ShowMore = false;

    partial void OnShowMoreChanged(bool value)
    {
        RefreshProcesses();
    }

    #endregion

    #region Processes

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

        MemoryManager<WindowsMemoryAccess> manager = new MemoryManager<WindowsMemoryAccess>(value.Process);
        var patterns = manager.FindPatternAll([0x5b, 0x53, 0x44, 0x4b, 0x2b, 0x4e, 0x49, 0x4e, 0x54, 0x45, 0x4e, 0x44, 0x4f, 0x3a, 0x42, 0x41, 0x43, 0x4b, 0x55, 0x50]).ToList();
    }

    #endregion Processes

    public MainWindowViewModel()
    {
        RefreshProcesses();
    }

    static void PrintMatches(List<nint> matches, int expected)
    {
        Debug.WriteLine($"Count: {matches.Count}");
        foreach (var m in matches)
        {
            Debug.WriteLine($"Found at: {m} - {(m == expected ? "PASS" : "FAIL")}");
        }
    }
}