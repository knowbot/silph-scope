using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games;

namespace SilphScope.ViewModels
{
    public partial class GameViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _Name;
        [ObservableProperty]
        private string _ProductId;
        [ObservableProperty]
        private Bitmap _Icon;
        public readonly Game Game;

        public GameViewModel(Game game)
        {
            Game = game;
            Name = game.Name;
            ProductId = game.ProductId;
            Icon = new Bitmap(AssetLoader.Open(game.Icon));
        }
    }
}
