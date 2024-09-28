namespace Connect4.API.Lib.Board;

public class BoardCell
{
    public int Column { get; }

    public int Row { get; }
    public int Player { get; }

    public BoardCell(int column, int row, int player)
    {
        Column = column;
        Row = row;
        Player = player;
    }


    public override bool Equals(object obj)
    {
        var item = obj as BoardCell;

        if (item == null)
        {
            return false;
        }

        return Column == item.Column && Row == item.Row;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (Column * 397) ^ Row;
        }
    }
}