using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;
using System.Collections.ObjectModel;

namespace SilphScope.ViewModels
{
    public partial class BoxesViewModel : ViewModelBase
    {
        [ObservableProperty]
        private readonly ObservableCollection<BoxViewModel> _boxes = [];

        [ObservableProperty]
        private readonly BoxViewModel? _selected;

        public BoxesViewModel()
        {
        }

        internal void UpdateGameState(Box[] boxes)
        {
            // Keep the appropriate number of boxes.
            while (Boxes.Count < boxes.Length)
            {
                Boxes.Add(new());
            }
            while (Boxes.Count > boxes.Length)
            {
                Boxes.RemoveAt(Boxes.Count - 1);
            }

            // Update each box.
            for (int i = 0; i < boxes.Length; i++)
            {
                Boxes[i].UpdateGameState(boxes[i]);
            }
        }
    }
}
