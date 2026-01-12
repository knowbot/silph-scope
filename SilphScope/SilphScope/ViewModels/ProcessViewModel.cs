using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace SilphScope.ViewModels
{
    /// <summary>
    /// ViewModel representing a summary of a process' info.
    /// </summary>
    public partial class ProcessViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _Name;

        [ObservableProperty]
        private int _Pid;

        [ObservableProperty]
        private string _MainWindowTitle;

        public readonly Process Process;

        public ProcessViewModel(Process process)
        {
            Process = process;
            Name = process.ProcessName;
            Pid = process.Id;
            MainWindowTitle = process.MainWindowTitle;
        }
    }
}
