using Avalonia.Media.Imaging;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core.Sprites;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.ViewModels
{
    public partial class PokemonViewModel : ViewModelBase
    {
        [ObservableProperty]
        private readonly string? _name;

        [ObservableProperty]
        private readonly string? _gender;

        [ObservableProperty]
        private readonly Bitmap? _sprite;

        [ObservableProperty]
        private readonly int _exp;

        [ObservableProperty]
        private readonly int _level;

        [ObservableProperty]
        private readonly int _levelProgress;

        [ObservableProperty]
        private readonly int _levelToNext;

        public int ExpBarLength => LevelProgress + LevelToNext;

        [ObservableProperty]
        private readonly PokeballViewModel? _pokeball;

        public HeldItemViewModel HeldItem { get; } = new();

        public void UpdateGameState(Pkmn? pokemon)
        {
            if (pokemon == null)
            {
                Name = string.Empty;
                return;
            }

            Name = string.IsNullOrEmpty(pokemon.Nickname) ? pokemon.Species.ToString() : pokemon.Nickname;
            Gender = "???";
            Level = pokemon.Level.Current;
            LevelProgress = (int)pokemon.Level.Progress;
            LevelToNext = (int)pokemon.Level.ToNext;
            Exp = (int)pokemon.Exp;
            HeldItem.UpdateGameState(pokemon.HeldItem);

            // Ask for asynchronous sprite loading.
            // When sprite has been loaded, go back to UI thread to update UI.
            SpriteLoadTask task = SpriteAsyncPool.Current.Load(pokemon.Species, SpriteFlags.None);
            task.OnCompleted(() => Dispatcher.UIThread.Post(() => Sprite = task.Result.Sprite));
        }
    }
}
