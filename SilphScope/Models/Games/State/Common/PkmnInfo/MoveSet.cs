using System;

namespace SilphScope.Models.Games.State.Common.PkmnInfo;

public record MoveSet
{
    private readonly Move[] _moves;
    public Move this[int index] => _moves[index];
    public int Count => _moves.Length;

    public MoveSet(params Move[] moves)
    {
        if (moves.Length != 4)
            throw new ArgumentException("Incorrect amount of moves");
        _moves = [.. moves];
    }
}
