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
        private readonly string _name;

        [ObservableProperty]
        private readonly int _pId;

        [ObservableProperty]
        private readonly string _mainWindowTitle;

        public readonly Process Process;

        public ProcessViewModel(Process process)
        {
            Process = process;
            Name = process.ProcessName;
            PId = process.Id;
            MainWindowTitle = process.MainWindowTitle;
        }
    }
}
