using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core;
using SilphScope.Models.Core.Messages;
using SilphScope.Models.Games.State;

namespace SilphScope.ViewModels
{
    public partial class SilphServiceViewModel : ViewModelBase
    {
        public delegate void GameStateUpdateHandler(SilphServiceViewModel sender, GameState state);
        public event GameStateUpdateHandler? GameStateUpdated;
        public delegate void SilphStateChangedHandler(SilphServiceViewModel sender, SilphState state);
        public event SilphStateChangedHandler? SilphStateChanged;

        [ObservableProperty]
        private bool _shouldStart = false;

        public void Start()
        {
            if (TargetProcess == null || TargetGame == null)
            {
                SilphLogger.Log($"Target process or target game are not set.");
                return;
            }
            if (Service == null)
            {
                Service = new SilphService(TargetProcess.Process, TargetGame.Game);
                Service.OnMessage += Watch_OnMessage;
                Service.Start();
            }
            else if (Service.State == SilphState.Stopped)
            {
                Service.Start();
            }
        }

        public void Stop()
        {
            if (Service == null) return;
            Service.Stop();
            Service.Dispose();
            Service = null;
        }

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
                Start();
            }
            else
            {
                Stop();
            }
        }
        [ObservableProperty]
        private ProcessViewModel? _targetProcess;

        [ObservableProperty]
        private GameViewModel? _targetGame;

        [ObservableProperty]
        private SilphService? _service;

        private void Watch_OnMessage(SilphService sender, SilphServiceMessage message)
        {
            if (message is DebugMessage dmessage)
            {
                SilphLogger.Log(dmessage.Message);
            }
            else if (message is GameStateUpdate gmessage)
            {
                GameStateUpdated?.Invoke(this, gmessage.NewGameState);
            }
            else if (message is SilphStateChangedMessage smessage)
            {
                SilphLogger.Log($"Service is now: {smessage.NewState}");
            }
            else
            {
                //Debugger.Break();
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
