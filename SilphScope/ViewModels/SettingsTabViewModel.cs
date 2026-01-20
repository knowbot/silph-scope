using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace SilphScope.ViewModels
{
    public partial class SettingsTabViewModel : ViewModelBase
    {
        public SilphServiceViewModel Service { get; set; }
        [ObservableProperty]
        private ObservableCollection<ProcessViewModel> _Processes = [];
        public List<GameViewModel> SupportedGames { get; private set; }

        [ObservableProperty]
        private bool _isSelectingProcess = false;
        partial void OnIsSelectingProcessChanged(bool value)
        {
            if (value)
            {
                RefreshProcesses();
            }
        }

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

            if (Service.SelectedProcess == null && Processes.Count > 0)
            {
                Service.SelectedProcess = Processes.FirstOrDefault();
            }
        }

        public SettingsTabViewModel(SilphServiceViewModel silphService)
        {
            Service = silphService;
            RefreshProcesses();
            SupportedGames = [.. Game.Supported.Select(g => new GameViewModel(g))];
        }
    }
}
