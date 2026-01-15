using CommunityToolkit.Mvvm.ComponentModel;

namespace SilphScope.ViewModels
{
    public partial class TeamTabViewModel : ViewModelBase
    {
        [ObservableProperty]
        private TeamViewModel _Team = new();

        public TeamTabViewModel()
        {

        }
    }
}
