using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace SilphScope.ViewModels
{
    public partial class BoxesViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<BoxViewModel> _Boxes = new();

        [ObservableProperty]
        private BoxViewModel? _Selected;
    }
}
