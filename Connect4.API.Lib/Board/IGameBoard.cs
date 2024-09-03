namespace Connect4.API.Lib.Board;

public interface IGameBoard
{
    
    int GetColumnLength();

    int GetRowLength();

    IEnumerable<int> ColumnIndices();

    IEnumerable<int> RowIndices();

    bool IsFull();

    bool IsColumnFull(int column);

    int DropDisc(int column, Player player);

    string GetDiscColorAtCell(int column, int row);

    int GetColumnToWin(Player player);

    bool CanPlayerWin(Player player, int column);

    bool HasPlayerWon(Player player, BoardCell lastPlayedCell);
}