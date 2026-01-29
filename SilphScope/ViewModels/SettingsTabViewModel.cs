using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core;
using SilphScope.Models.Games;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace SilphScope.ViewModels
{
    public partial class SettingsTabViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isSelectingProcess = false;
        [ObservableProperty]
        private ObservableCollection<ProcessViewModel> _processes = [];
        public SilphServiceViewModel Service { get; set; }
        public List<GameViewModel> SupportedGames { get; private set; }

        partial void OnIsSelectingProcessChanged(bool value)
        {
            if (value)
            {
                RefreshProcesses();
            }
        }

        public void RefreshProcesses()
        {
            List<Process> newProcesses = Process.GetProcesses().ToList();
            HashSet<int> newPids = newProcesses.Select(p => p.Id).ToHashSet();
            HashSet<int> currPids = Processes.Select(p => p.PId).ToHashSet();

            for (int i = Processes.Count - 1; i >= 0; i--)
            {
                if (!newPids.Contains(Processes[i].PId))
                {
                    Processes.RemoveAt(i);
                }
            }

            foreach (Process process in newProcesses)
            {
                if (!currPids.Contains(process.Id) && process.ProcessName.Contains("desmume", System.StringComparison.OrdinalIgnoreCase))
                {
                    Processes.Add(new ProcessViewModel(process));
                }
            }

            if (Service.TargetProcess == null && Processes.Count > 0)
            {
                Service.TargetProcess = Processes.FirstOrDefault();
            }
        }
        public SettingsTabViewModel(SilphServiceViewModel silphService)
        {
            Service = silphService;
            RefreshProcesses();
            SupportedGames = [.. Game.Supported.Select(g => new GameViewModel(g))];
            Service.TargetGame = SupportedGames.FirstOrDefault();
        }
    }
}
