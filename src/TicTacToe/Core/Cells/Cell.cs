namespace TicTacToe.Core.Cells;



public abstract class Cell
{
    public abstract string Display();
    
    public abstract bool IsEmpty();
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