using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SilphScope.ViewModels
{
    public partial class PokeballViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Bitmap? _sprite;
    }
}
