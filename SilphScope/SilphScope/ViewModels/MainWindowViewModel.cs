using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models;
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

    #endregion Processes

    public MainWindowViewModel()
    {
        MemoryScanner.ParsePattern("AA");
        RefreshProcesses();
    }
}