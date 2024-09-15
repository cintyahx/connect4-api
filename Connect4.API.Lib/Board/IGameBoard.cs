namespace Connect4.API.Lib.Board;

public interface IGameBoard<in TMoveInfo> 
    where TMoveInfo : BaseMoveInfo
{
    BoardCell DropDisc(TMoveInfo moveInfo, Player player);

    string GetDiscColorAtCell(int column, int row);
    
    bool HasPlayerWon(Player player, BoardCell lastPlayedCell);

    public bool IsFull();

    public IEnumerable<int> ColumnIndices();

    public IEnumerable<int> RowIndices();
    
    public bool IsColumnFull(int column);

    public IEnumerable<BoardCell> GetAvailableCells();
}