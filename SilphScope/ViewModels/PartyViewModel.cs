using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;
using System.Collections.ObjectModel;

namespace SilphScope.ViewModels
{
    public partial class PartyViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<PokemonViewModel> _members = [];

        [ObservableProperty]
        private PokemonViewModel? _selected;

        public PartyViewModel()
        { }

        internal void UpdateGameState(Pkmn[] party)
        {
            // First ever update. Insert 6 empty party slots.
            if (Members.Count == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    Members.Add(new PokemonViewModel());
                }
            }

            // Update the party members.
            for (int i = 0; i < party.Length && i < Members.Count; i++)
            {
                Members[i].UpdateGameState(party[i]);
            }

            // Extra empty members.
            for (int i = party.Length; i < Members.Count; i++)
            {
                Members[i].UpdateGameState(null);
            }
        }
    }
}
