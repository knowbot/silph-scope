using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.ViewModels
{
    public partial class TeamTabViewModel : ViewModelBase
    {
        [ObservableProperty]
        private TeamViewModel _Team = new();

        public TeamTabViewModel()
        {

        }

        public void UpdateGameState(Pokemon[] team)
        {
            Team.UpdateGameState(team);
        }
    }
}
