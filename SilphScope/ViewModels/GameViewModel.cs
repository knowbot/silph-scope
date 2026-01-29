using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games;

namespace SilphScope.ViewModels
{
    public partial class GameViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _productId;
        [ObservableProperty]
        private Bitmap _icon;
        public Game Game;

        public GameViewModel(Game game)
        {
            Game = game;
            Name = game.Name;
            ProductId = game.ProductId;
            Icon = new Bitmap(AssetLoader.Open(game.IconPath.ToAvaresUri()));
        }
    }
}
