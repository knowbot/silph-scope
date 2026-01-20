using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core;

namespace SilphScope.ViewModels
{
    public partial class SilphServiceViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _shouldStart = false;

        partial void OnShouldStartChanged(bool value)
        {
            if (value)
            {
                // No process to attach to / game to scan for.
                if (SelectedProcess == null || SelectedGame == null)
                {
                    ShouldStart = false;
                    return;
                }
                Service = new SilphService(SelectedProcess.Process, SelectedGame.Game);
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
        private ProcessViewModel? _selectedProcess;

        [ObservableProperty]
        private GameViewModel? _selectedGame;

        [ObservableProperty]
        private SilphService? _service;
        private static void Watch_OnMessage(SilphService sender, string message)
        {
            SilphLogger.Log(message);
        }

        partial void OnSelectedProcessChanged(ProcessViewModel? value)
        {
            ShouldStart = false;
        }

        partial void OnSelectedGameChanged(GameViewModel? value)
        {
            ShouldStart = false;
        }

    }
}
