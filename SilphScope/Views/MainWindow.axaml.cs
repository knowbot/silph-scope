using Avalonia.Controls;
using SilphScope.ViewModels;

namespace SilphScope.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnDropDownOpened(object? sender, System.EventArgs e)
    {
        if (DataContext is MainWindowViewModel vm)
        {
            vm.RefreshProcesses();
        }
    }
}