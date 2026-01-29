using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.ViewModels
{
    public partial class PartyTabViewModel : ViewModelBase
    {
        [ObservableProperty]
        private PartyViewModel _party = new();
        [ObservableProperty]
        private TrainerViewModel _trainer = new();

        public PartyTabViewModel()
        {
        }

        public void UpdateGameState(Pkmn[] party, Trainer trainer)
        {
            Party.UpdateGameState(party);
            Trainer.UpdateGameState(trainer);
        }

        public void SetCurrentGame(Game game)
        {
            Trainer.SetCurrentGame(game);
        }
    }
}
