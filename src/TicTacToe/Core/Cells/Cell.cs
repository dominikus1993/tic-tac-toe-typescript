namespace TicTacToe.Core.Cells;


public sealed record Coordinate(int Row, int Column);

public abstract class Cell
{
    public abstract string Display();
    
    public abstract bool IsEmpty();
    
    public int CellId => GetCellId(Row, Column);
    
    public static Cell FromCellId(int cellId) => new(cellId / 8, cellId % 8);
    
    public static int GetCellId(Coordinate coordinate) => coordinate.Row * 8 + coordinate.Column;
}

public sealed class EmptyCell : Cell
{
    public override string Display()
    {
        return " ";
    }

    public override bool IsEmpty()
    {
        return true;
    }
}

public sealed class XCell : Cell
{
    public override string Display()
    {
        return "X";
    }

    public override bool IsEmpty()
    {
        return false;
    }
}

public sealed class OCell : Cell
{
    public override string Display()
    {
        return "O";
    }
    
    public override bool IsEmpty()
    {
        return false;
    }
}