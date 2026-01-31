using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.ViewModels
{
    public partial class HeldItemViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private Bitmap? _sprite;

        public HeldItemViewModel() { }

        public void UpdateGameState(ItemName item)
        {
            Name = item.GetDescription();
        }
    }
}
