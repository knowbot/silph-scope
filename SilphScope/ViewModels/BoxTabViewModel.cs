using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.ViewModels
{
    public partial class BoxTabViewModel : ViewModelBase
    {
        [ObservableProperty]
        private BoxesViewModel _boxes = new();

        internal void UpdateGameState(Box[] boxes)
        {
            Boxes.UpdateGameState(boxes);
        }
    }
}
