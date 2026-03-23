using System.Collections.ObjectModel;
using SilphScope.Models.Games.State.Common.PkmnInfo;

namespace SilphScope.ViewModels;

public partial class MoveSetViewModel : ViewModelBase
{
    public ObservableCollection<MoveViewModel> Moves { get; } = new();

    public MoveSetViewModel() { }

    public void UpdateGameState(MoveSet? moves)
    {
        if (moves == null)
        {
            foreach (MoveViewModel move in Moves)
            {
                move.UpdateGameState(null);
            }
            return;
        }

        // Keep the appropriate number of moves.
        while (Moves.Count < moves.Count)
        {
            Moves.Add(new());
        }
        while (Moves.Count > moves.Count)
        {
            Moves.RemoveAt(Moves.Count - 1);
        }

        // Update each move.
        for (int i = 0; i < moves.Count; i++)
        {
            Moves[i].UpdateGameState(moves[i]);
        }
    }
}
