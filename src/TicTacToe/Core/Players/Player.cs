using TicTacToe.Core.Boards;
using TicTacToe.Core.Cells;

namespace TicTacToe.Core.Players;

public interface IControlInterface
{
    Coordinates NextMove(Board board);
}

public abstract class Player
{
    public abstract Board Move(Board board);
}

public sealed class HumanPlayer : Player
{
    private readonly IControlInterface _controlInterface;
    private readonly Cell _cell;
    
    public HumanPlayer(IControlInterface controlInterface, Cell cell)
    {
        _controlInterface = controlInterface;
        _cell = cell;
    }
    
    public override Board Move(Board board)
    {
        var coordinates = _controlInterface.NextMove(board);
        if (board.IsMoveValid(coordinates))
        {
            board.NextMove(coordinates, _cell);
            return board;
        }
        else
        {
            throw new InvalidOperationException("Invalid move");
        }
    }
}

public sealed class ComputerPlayer : Player
{
    private readonly List<Coordinates> _myMoves = [];
    private readonly Cell _cell;

    public ComputerPlayer(Cell cell)
    {
        _cell = cell;
    }

    public override Board Move(Board board)
    {
        for (int i = 0; i < board.Size; i++)
        {
            for (int j = 0; j < board.Size; j++)
            {
                var coordinates = new Coordinates(i, j);
                if (_myMoves.Contains(coordinates))
                {
                    continue;
                }       
                if (board.IsMoveValid(coordinates))
                {
                    _myMoves.Add(coordinates);
                    board.NextMove(coordinates,_cell);
                    return board;
                }
            }
        }
        throw new InvalidOperationException("No valid moves left");
    }
}