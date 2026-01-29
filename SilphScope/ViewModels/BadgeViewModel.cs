using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Extensions;

namespace SilphScope.ViewModels
{
    public partial class BadgeViewModel : ViewModelBase
    {
        private readonly Bitmap? _activeImg;
        private readonly Bitmap? _inactiveImg;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DisplayBadge))]
        private bool _isActive;

        public Bitmap? DisplayBadge => IsActive ? _activeImg : _inactiveImg;
        public BadgeViewModel(int index, string path, bool isActive)
        {
            _isActive = isActive;
            string activePath = $"{path}/badge{index}.png";
            _activeImg = new Bitmap(AssetLoader.Open(activePath.ToAvaresUri()));
            string inactivePath = $"{path}/badge{index}i.png";
            _inactiveImg = new Bitmap(AssetLoader.Open(inactivePath.ToAvaresUri()));
        }
    }
}
