using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core;
using SilphScope.Models.Core.Messages;
using System.Diagnostics;

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
                if (TargetProcess == null || TargetGame == null)
                {
                    ShouldStart = false;
                    return;
                }
                Service = new SilphService(TargetProcess.Process, TargetGame.Game);
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
        private ProcessViewModel? _targetProcess;

        [ObservableProperty]
        private GameViewModel? _targetGame;

        [ObservableProperty]
        private SilphService? _service;

        private static void Watch_OnMessage(SilphService sender, SilphServiceMessage message)
        {
            if (message is DebugMessage dmessage)
            {
                SilphLogger.Log(dmessage.Message);
            }
            else if (message is GameStateUpdateMessage gmessage)
            {

            }
            else
            {
                Debugger.Break();
                SilphLogger.Log($"Message type not implemented: {message}");
            }
        }

        partial void OnTargetProcessChanged(ProcessViewModel? value)
        {
            ShouldStart = false;
        }

        partial void OnTargetGameChanged(GameViewModel? value)
        {
            ShouldStart = false;
        }

    }
}
