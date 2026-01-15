using CommunityToolkit.Mvvm.ComponentModel;
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
    }
}
