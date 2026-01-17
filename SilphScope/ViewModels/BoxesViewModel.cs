using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace SilphScope.ViewModels
{
    public partial class BoxesViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<BoxViewModel> _Boxes = new();

        [ObservableProperty]
        private BoxViewModel? _Selected;

        public BoxesViewModel()
        {
            // TODO: remove.
            for (int i = 0; i < 30; i++)
            {
                Boxes.Add(new BoxViewModel() { Name = $"Box {i}" });
            }
        }
    }
}
