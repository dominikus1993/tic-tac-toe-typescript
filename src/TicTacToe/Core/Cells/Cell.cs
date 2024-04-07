namespace TicTacToe.Core.Cells;



public abstract class Cell
{
    public abstract string Display();
    
    public abstract bool IsEmpty();
}

public sealed class EmptyCell : Cell
{
    private EmptyCell()
    {
        
    }

    public static readonly Cell Instance = new EmptyCell();

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
    private XCell()
    {
        
    }
    public override string Display()
    {
        return "X";
    }

    public override bool IsEmpty()
    {
        return false;
    }

    public static readonly Cell Instance = new XCell();
}

public sealed class OCell : Cell
{
    private OCell()
    {
        
    }
    public override string Display()
    {
        return "O";
    }
    
    public static readonly Cell Instance = new OCell();
    
    public override bool IsEmpty()
    {
        return false;
    }
}