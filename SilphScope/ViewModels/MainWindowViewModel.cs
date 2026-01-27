using Avalonia.Threading;
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
        Service.GameStateUpdated += Service_GameStateUpdated;
        SettingsTab = new(Service);
    }

    private void Service_GameStateUpdated(SilphServiceViewModel sender, FrameData state)
    {
        Dispatcher.UIThread.Post(() => UpdateGameState(state));
    }

    private void UpdateGameState(FrameData state)
    {
        // Update (each tab will optimize its own operations).
        PartyTab.UpdateGameState(state.Party);
        BoxTab.UpdateGameState(state.Boxes);
    }

    private bool isDisposed;

    public void Dispose()
    {
        if (isDisposed)
        {
            return;
        }

        Log.Dispose();

        isDisposed = true;
    }
}