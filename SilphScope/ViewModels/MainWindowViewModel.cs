using Avalonia.Threading;
using SilphScope.Models.Games;
using SilphScope.Models.Games.State;

namespace SilphScope.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public LogViewModel Log { get; }

    public PartyTabViewModel PartyTab { get; }

    public BoxTabViewModel BoxTab { get; }

    public SettingsTabViewModel SettingsTab { get; }

    public SilphServiceViewModel Service { get; }

    public MainWindowViewModel()
    {
        Log = new();
        PartyTab = new();
        BoxTab = new();

        // Initialize service and settings tab (which references service).
        Service = new SilphServiceViewModel();
        Service.GameStateUpdated += OnGameStateUpdated;
        Service.GameDetected += OnGameDetected;
        SettingsTab = new(Service);
    }

    private void OnGameStateUpdated(SilphServiceViewModel sender, FrameData state)
    {
        Dispatcher.UIThread.Post(() => UpdateGameState(state));
    }

    private void OnGameDetected(SilphServiceViewModel sender, Game game)
    {
        Dispatcher.UIThread.Post(() => SetCurrentGame(game));
    }

    private void UpdateGameState(FrameData state)
    {
        // Update (each tab will optimize its own operations).
        PartyTab.UpdateGameState(state.Party, state.Trainer);
        BoxTab.UpdateGameState(state.Boxes);
    }

    private void SetCurrentGame(Game game)
    {
        PartyTab.SetCurrentGame(game);
    }
}