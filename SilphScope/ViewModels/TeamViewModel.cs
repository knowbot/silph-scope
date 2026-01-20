using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;
using System.Collections.ObjectModel;

namespace SilphScope.ViewModels
{
    public partial class TeamViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<PokemonViewModel> _Members = [];

        [ObservableProperty]
        private PokemonViewModel? _Selected;

        public TeamViewModel()
        { }

        internal void UpdateGameState(Pokemon[] team)
        {
            // First ever update. Insert 6 empty party slots.
            if (Members.Count == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    Members.Add(new PokemonViewModel());
                }
            }

            // Update the team members.
            for (int i = 0; i < team.Length && i < Members.Count; i++)
            {
                Members[i].UpdateGameState(team[i]);
            }

            // Extra empty members.
            for (int i = team.Length; i < Members.Count; i++)
            {
                Members[i].UpdateGameState(null);
            }
        }
    }
}
