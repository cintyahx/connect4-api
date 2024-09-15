using Connect4.API.Lib.Board;
using Connect4.API.Lib.GamePlay;

namespace Connect4.API.Lib.Connect4;

public class Connect4Strategy : GameStrategy<Connect4MoveInfo>
{
    public override Connect4MoveInfo Play(
        Player currentPlayer, 
        Player opponentPlayer, 
        IGameBoard<Connect4MoveInfo> board)
    {
        var availableColumns = board.ColumnIndices()
            .Where(column => !board.IsColumnFull(column)).ToList();

        var random = new Random();
        var index = random.Next(0, availableColumns.Count);

        return  new Connect4MoveInfo(availableColumns[index]);
    }
}