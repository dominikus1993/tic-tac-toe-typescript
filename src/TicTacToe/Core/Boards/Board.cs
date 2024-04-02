using TicTacToe.Core.Cells;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.Boards;


public sealed class Board
{
    private readonly Cell[,] _cells;
    public Player? CheckWinner() => throw new System.NotImplementedException();
    
    public bool IsFull() => throw new System.NotImplementedException();
    
    private Board(Cell[,] cells)
    {
        _cells = cells;
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