using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.ViewModels;

public partial class BoxesViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<BoxViewModel> _boxes = [new()];

    [ObservableProperty]
    private BoxViewModel? _selected;

    public BoxesViewModel()
    {
        Selected = Boxes.First();
    }

    internal void UpdateGameState(Box[] boxes)
    {
        // Keep the appropriate number of boxes.
        while (Boxes.Count < boxes.Length)
        {
            Boxes.Add(new BoxViewModel());
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

        // Ensure first box is automatically selected.
        if (Selected == null && Boxes.Count > 0)
        {
            Selected = Boxes.First();
        }
    }
}
