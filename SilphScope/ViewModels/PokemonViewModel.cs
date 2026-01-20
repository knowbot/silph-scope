using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.ViewModels
{
    public partial class PokemonViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string? _Name;

        public void UpdateGameState(Pokemon? pokemon)
        {
            if (pokemon == null)
            {
                Name = string.Empty;
                return;
            }

            Name = pokemon.Species.ToString();
        }
    }
}
