using CommunityToolkit.Mvvm.ComponentModel;

namespace SilphScope.ViewModels
{
    public partial class BoxTabViewModel : ViewModelBase
    {
        [ObservableProperty]
        private BoxesViewModel _Boxes = new();
    }
}
