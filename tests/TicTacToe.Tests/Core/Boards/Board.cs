using TicTacToe.Core.Boards;

namespace TicTacToe.Tests.Core.Boards;

public class BoardTests
{
    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(1, 1, true)]
    [InlineData(2, 2, true)]
    [InlineData(3, 3, false)]
    [InlineData(0, 3, false)]
    [InlineData(3, 0, false)]
    [InlineData(5, 5050555, false)]
    [InlineData(1, -1, false)]
    public void TestIsMoveValidWhenIsInvalid(int x, int y, bool expected)
    {
        var board = Board.Create(3);
        Assert.Equal(expected, board.IsMoveValid(x, y));
    }
    
    [Fact]
    public void TestIsFullWhenAllCellsAreEmpty()
    {
        var board = Board.Create(3);
        Assert.False(board.IsFull());
    }
}