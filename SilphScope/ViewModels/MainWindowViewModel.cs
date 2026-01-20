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
        _service = new SilphServiceViewModel();
        Log = new();
        TeamTab = new();
        BoxTab = new();
        SettingsTab = new(Service);
        // TeamTab.UpdateData(game.Team);
        // BoxTab.UpdateData(game.Boxes);
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