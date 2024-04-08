using TicTacToe.Core.Cells;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.Boards;

public readonly record struct Coordinates(int X, int Y);
public sealed class Board
{
    private int _moveCount;
    private readonly Cell[,] _cells;
    private readonly int _size;
    public Player? CheckWinner() => throw new System.NotImplementedException();

    public bool IsFull()
    {
        foreach (var cell in _cells)
        {
            if (cell.IsEmpty())
            {
                return false;
            }
        }
        return true;
    }
    
    private Board(Cell[,] cells)
    {
        _cells = cells;
        _moveCount = 0;
        _size = cells.GetLength(0);
    }
    
    public void NextMove(Coordinates coordinates, Cell cell)
    {
        ArgumentNullException.ThrowIfNull(coordinates);
        ArgumentNullException.ThrowIfNull(cell);
        
        if (!IsMoveValid(coordinates))
        {
            throw new ArgumentOutOfRangeException(nameof(coordinates), "Invalid move");
        }

        _moveCount += 1;
        _cells[coordinates.X, coordinates.Y] = cell;
    }

    public bool IsMoveValid(Coordinates coordinates)
    {
        ArgumentNullException.ThrowIfNull(coordinates);
        if (coordinates.X < 0 || coordinates.Y < 0)
        {
            return false;
        }
        return coordinates.X < _size && coordinates.Y < _size && _cells[coordinates.X, coordinates.Y].IsEmpty();
    }


    public static Board Create(int n = 3)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(n);
#pragma warning disable CA1814
        var cells = new Cell[n, n];
#pragma warning restore CA1814
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                cells[i, j] = EmptyCell.Instance;
            }
        }
        return new Board(cells);
    }
}