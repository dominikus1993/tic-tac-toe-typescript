using TicTacToe.Core.Cells;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.Boards;


public sealed class Board
{
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
        _size = cells.GetLength(0);
    }

    public bool IsMoveValid(int x, int y)
    {
        if (x < 0 || y < 0)
        {
            return false;
        }
        return x < _size && y < _size && _cells[x, y].IsEmpty();
    }


    public static Board Create(int n = 3)
    {
        var cells = new Cell[n, n];
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                cells[i, j] = new EmptyCell();
            }
        }
        return new Board(cells);
    }
}