using CommunityToolkit.Mvvm.ComponentModel;
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
        private string _Name;
    }
}
