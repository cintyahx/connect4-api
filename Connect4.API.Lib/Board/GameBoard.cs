namespace Connect4.API.Lib.Board;

public abstract class BaseGameBoard<TMoveInfo>(int columns, int rows, int totalDiscsInRowToWin)
    : IGameBoard<TMoveInfo> where TMoveInfo : BaseMoveInfo
{
    protected readonly Player[,] Cells = new Player[columns, rows];

    public virtual BoardCell DropDisc(TMoveInfo moveInfo, Player player)
    {
        throw new NotImplementedException();
    }

    public string GetDiscColorAtCell(int column, int row)
    {
        var player = Cells[column, row];
        return player?.Color;
    }

    public bool HasPlayerWon(Player player, BoardCell lastPlayedCell)
    {
        return CheckWinningPossibility(player, lastPlayedCell);
    }
    public bool IsFull()
    {
        return RowIndices().
            All(row => ColumnIndices().
                All(colum => Cells[colum, row] != null));
    }
    
    public IEnumerable<int> ColumnIndices()
    {
        for (var c = 0; c < GetColumnLength(); c++)
        {
            yield return c;
        }
    }

    public IEnumerable<int> RowIndices()
    {
        for (var r = 0; r < GetRowLength(); r++)
        {
            yield return r;
        }
    }
    
    public bool IsColumnFull(int column)
    {
        return RowIndices().All(r => Cells[column, r] != null);
    }
    
    protected bool IsPositionAvailable(int column, int row)
    {
        return IsValidCell(column, row) && Cells[column, row] is null;
    }
    
    private bool CheckWinningPossibility(Player player, BoardCell cellToCheckFrom)
    {
        if (!IsValidCell(cellToCheckFrom))
        {
            return false;
        }

        return CheckHorizontally(player, cellToCheckFrom)
               || CheckVertically(player, cellToCheckFrom)
               || CheckPositiveDiagonal(player, cellToCheckFrom)
               || CheckNegativeDiagonal(player, cellToCheckFrom);
    }

    private bool CheckHorizontally(Player player, BoardCell currentCell)
    {
        for (var startColumn = currentCell.Column - 3; startColumn <= currentCell.Column; startColumn++)
        {
            var startCell = new BoardCell(startColumn, currentCell.Row);
            var canConnect = CanConnect(player, currentCell, startCell, BoardNavigationHelper.GetNextCellOnRight);

            if (canConnect)
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckVertically(Player player, BoardCell currentCell)
    {
        var canConnect = CanConnect(player, currentCell, currentCell, BoardNavigationHelper.GetNextCellBelow);

        return canConnect;
    }

    private bool CheckPositiveDiagonal(Player player, BoardCell currentCell)
    {
        for (var startDistance = 3; startDistance >= 0; startDistance--)
        {
            var startCell = new BoardCell(
                currentCell.Column - startDistance,
                currentCell.Row + startDistance
                );
            
            var canConnect = CanConnect(player, currentCell, startCell,
                BoardNavigationHelper.GetNextCellOnRightCornerAbove);

            if (canConnect)
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckNegativeDiagonal(Player player, BoardCell currentCell)
    {
        for (var startDistance = 3; startDistance >= 0; startDistance--)
        {
            var startCell = new BoardCell(currentCell.Column - startDistance, currentCell.Row - startDistance);
            var canConnect = CanConnect(player, currentCell, startCell,
                BoardNavigationHelper.GetNextCellOnRightCornerBelow);

            if (canConnect)
            {
                return true;
            }
        }

        return false;
    }

    private bool CanConnect(Player player, BoardCell currentCell, BoardCell startCell,
        Func<BoardCell, BoardCell> getNextCellFunc)
    {
        var cellToCheck = startCell;
        var cellToBePlayedNext = IsAlreadyPlayed(currentCell) ? null : currentCell;

        var count = 0;

        for (var i = 0; i < totalDiscsInRowToWin; i++)
        {
            if (!IsValidCell(cellToCheck.Column, cellToCheck.Row))
            {
                return false;
            }

            if (!cellToCheck.Equals(cellToBePlayedNext) &&
                GetDiscColorAtCell(cellToCheck.Column, cellToCheck.Row) != player.Color)
            {
                return false;
            }

            count++;
            cellToCheck = getNextCellFunc(cellToCheck);
        }

        return count == totalDiscsInRowToWin;
    }

    private bool IsAlreadyPlayed(BoardCell cell)
    {
        return IsValidCell(cell) && Cells[cell.Column, cell.Row] != null;
    }


    private bool IsValidCell(BoardCell cell)
    {
        return IsValidCell(cell.Column, cell.Row);
    }

    private bool IsValidCell(int column, int row)
    {
        return column >= 0 && column < GetColumnLength()
                           && row >= 0 && row < GetRowLength();
    }

    public int GetColumnLength()
    {
        return Cells.GetLength(0);
    }

    public int GetRowLength()
    {
        return Cells.GetLength(1);
    }
    
    public IEnumerable<BoardCell> GetAvailableCells()
    {
        var availableCells = new List<BoardCell>();
        foreach (var column in ColumnIndices())
        {
            availableCells.AddRange(from row in RowIndices() 
                where Cells[column, row] is null 
                select new BoardCell(column, row));
        }

        return availableCells;
    }
}