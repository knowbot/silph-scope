using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;
using System.Collections.ObjectModel;

namespace SilphScope.ViewModels
{
    public partial class BoxViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<PokemonViewModel> _Contents = [];

        [ObservableProperty]
        private PokemonViewModel? _Selected;

        [ObservableProperty]
        private string? _Name;

        public BoxViewModel()
        { }

        internal void UpdateGameState(Box box)
        {
            // Keep the appropriate number of pokemon.
            while (Contents.Count < box.Slots.Length)
            {
                Contents.Add(new());
            }
            while (Contents.Count > box.Slots.Length)
            {
                Contents.RemoveAt(Contents.Count - 1);
            }

            // Update each pokemon.
            for (int i = 0; i < box.Slots.Length; i++)
            {
                Contents[i].UpdateGameState(box.Slots[i]);
            }
        }
    }
}
