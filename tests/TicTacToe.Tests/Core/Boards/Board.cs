using TicTacToe.Core.Boards;
using TicTacToe.Core.Cells;

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
        var coordinates = new Coordinates(x, y);
        Assert.Equal(expected, board.IsMoveValid(coordinates));
    }
    
    [Fact]
    public void TestIsMoveValidWhenFieldIsNotEmpty()
    {
        var coordinates = new Coordinates(0, 0);
        var board = Board.Create(3);
        board.NextMove(coordinates, XCell.Instance);
        var subject = board.IsMoveValid(coordinates);
        Assert.False(subject);
    }
    
    [Fact]
    public void TestIsFullWhenAllCellsAreEmpty()
    {
        var board = Board.Create(3);
        Assert.False(board.IsFull());
    }
    
    [Fact]
    public void TestIsFullWhenSomeCellsAreEmpty()
    {
        var board = Board.Create(3);
        board.NextMove(new Coordinates(0, 0), XCell.Instance);
        Assert.False(board.IsFull());
    }
    
    [Fact]
    public void TestIsFullWhenAllCellsAreNotEmpty()
    {
        const int n = 3;
        var board = Board.Create(n);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                board.NextMove(new Coordinates(i, j), XCell.Instance);
            }
        }
        Assert.True(board.IsFull());
    }
}