using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core;
using SilphScope.Models.Core.Messages;
using SilphScope.Models.Games;
using SilphScope.Models.Games.State;

namespace SilphScope.ViewModels;

public partial class SilphServiceViewModel : ViewModelBase
{
    public delegate void GameStateUpdatedHandler(SilphServiceViewModel sender, FrameData state);
    public event GameStateUpdatedHandler? GameStateUpdated;
    public delegate void SilphStateChangedHandler(SilphServiceViewModel sender, SilphState state);
    public event SilphStateChangedHandler? SilphStateChanged;
    public delegate void GameDetectedHandler(SilphServiceViewModel sender, Game game);
    public event GameDetectedHandler? GameDetected;

    [ObservableProperty]
    private bool _shouldStart = false;
    [ObservableProperty]
    private ProcessViewModel? _targetProcess;
    [ObservableProperty]
    private GameViewModel? _targetGame;
    [ObservableProperty]
    private SilphService? _service;

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
            Service.OnMessage += OnMessage;
            Service.Start();
        }
        else if (Service.State == SilphState.Stopped)
        {
            Service.Start();
        }
    }

    public void Stop()
    {
        if (Service == null)
            return;
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

    private void OnMessage(SilphService sender, SilphServiceMessage message)
    {
        switch (message)
        {
            case DebugMessage dMessage:
                SilphLogger.Log(dMessage.Message);
                break;
            case SilphStateChangedMessage scMessage:
                SilphLogger.Log($"Service is now: {scMessage.NewState}");
                break;
            case GameStateUpdateMessage guMessage:
                GameStateUpdated?.Invoke(this, guMessage.NewGameState);
                break;
            case GameDetectedMessage gdMessage:
                GameDetected?.Invoke(this, gdMessage.TargetGame);
                break;
            default:
                SilphLogger.Log($"Message type not implemented: {message}");
                break;
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
