using TicTacToe.Core.Players;

namespace TicTacToe.Core;

public sealed class Game
{
    private Player _player1;
    private Player _player2;
    
    public Game(Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;
    }
    
    public void Start()
    {
        throw new System.NotImplementedException();
    }
    
    public void Play()
    {
        throw new System.NotImplementedException();
    }
    
    public void End()
    {
        throw new System.NotImplementedException();
    }
}