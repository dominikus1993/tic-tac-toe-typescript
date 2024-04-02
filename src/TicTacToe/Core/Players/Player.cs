using TicTacToe.Core.Boards;

namespace TicTacToe.Core.Players;

public abstract class Player
{
    public abstract Board Move(Board board);
}

public sealed class HumanPlayer : Player
{
    public override Board Move(Board board)
    {
        throw new System.NotImplementedException();
    }
}

public sealed class ComputerPlayer : Player
{
    public override Board Move(Board board)
    {
        throw new System.NotImplementedException();
    }
}