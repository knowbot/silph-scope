using Avalonia.Threading;
using SilphScope.Models.Games.State;

namespace SilphScope.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
	public LogViewModel Log { get; }

	public TeamTabViewModel TeamTab { get; }

	public BoxTabViewModel BoxTab { get; }

	public SettingsTabViewModel SettingsTab { get; }
	public SilphServiceViewModel Service => _service;
	private readonly SilphServiceViewModel _service;


	public MainWindowViewModel()
	{
		Log = new();
		TeamTab = new();
		BoxTab = new();

		// Initialize service and settings tab (which references service).
		_service = new SilphServiceViewModel();
		Service.GameStateUpdated += Service_GameStateUpdated;
		SettingsTab = new(Service);
	}

	private void Service_GameStateUpdated(SilphServiceViewModel sender, GameState state)
	{
		Dispatcher.UIThread.Post(() => UpdateGameState(state));
	}

	private void UpdateGameState(GameState state)
	{
		// Update (each tab will optimize its own operations).
		TeamTab.UpdateGameState(state.Team);
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