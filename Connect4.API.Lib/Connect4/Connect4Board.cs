using Connect4.API.Lib.Board;
using Connect4.API.Lib.GamePlay;

namespace Connect4.API.Lib.Connect4;

public class Connect4Board(int columns, int rows, int totalDiscsInRowToWin)
    : BaseGameBoard<Connect4MoveInfo>(columns, rows, totalDiscsInRowToWin)
{
    private const int InvalidRowColumn = -1;

    public override BoardCell DropDisc(Connect4MoveInfo moveInfo, Player player)
    {
        var nextRow = GetNextAvailableRow(moveInfo.Column);

        if (nextRow == InvalidRowColumn)
        {
            throw new Exception("Position is not available");
        }

        Cells[moveInfo.Column, nextRow] = player;
        
        return new BoardCell(moveInfo.Column, nextRow);
    }

    private int GetNextAvailableRow(int column)
    {
        for (var row = GetRowLength() - 1; row >= 0; row--)
        {
            if (IsPositionAvailable(column, row))
            {
                return row;
            }
        }

        return InvalidRowColumn;
    }
}