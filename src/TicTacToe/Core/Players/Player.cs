using TicTacToe.Core.Boards;
using TicTacToe.Core.Cells;

namespace TicTacToe.Core.Players;

public interface IControlInterface
{
    Coordinates Move();
}

public abstract class Player
{
    public abstract Board Move(Board board);
}

public sealed class HumanPlayer : Player
{
    private readonly IControlInterface _controlInterface;
    
    public HumanPlayer(IControlInterface controlInterface)
    {
        _controlInterface = controlInterface;
    }
    
    public override Board Move(Board board)
    {
        var coordinates = _controlInterface.Move();
        do
        {
            
        } 
        while (!board.IsMoveValid(coordinates));
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