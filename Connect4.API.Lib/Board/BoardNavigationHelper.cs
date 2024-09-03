namespace Connect4.API.Lib.Board;

public class BoardNavigationHelper
{
    public static BoardCell GetNextCellOnRight(BoardCell currentCell)
    {
        return new BoardCell(currentCell.Column + 1, currentCell.Row);
    }

    public static BoardCell GetNextCellBelow(BoardCell currentCell)
    {
        return new BoardCell(currentCell.Column, currentCell.Row + 1);
    }

    public static BoardCell GetNextCellOnRightCornerAbove(BoardCell currentCell)
    {
        return new BoardCell(currentCell.Column + 1, currentCell.Row - 1);
    }

    public static BoardCell GetNextCellOnRightCornerBelow(BoardCell currentCell)
    {
        return new BoardCell(currentCell.Column + 1, currentCell.Row + 1);
    }
}