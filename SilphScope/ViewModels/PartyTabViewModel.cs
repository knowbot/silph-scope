using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.ViewModels
{
    public partial class PartyTabViewModel : ViewModelBase
    {
        [ObservableProperty]
        private PartyViewModel _party = new();

        public PartyTabViewModel()
        {

        }

        public void UpdateGameState(Pkmn[] party)
        {
            Party.UpdateGameState(party);
        }
    }
}
