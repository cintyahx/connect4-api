using Connect4.API.Lib.Board;
using Connect4.API.Lib.GamePlay;

namespace Connect4.API.Lib.TicTacToe;

public class TicTacToeBoard(int columns, int rows, int totalDiscsInRowToWin)
    : BaseGameBoard<TicTacToeMoveInfo>(columns, rows, totalDiscsInRowToWin)
{
    public override BoardCell DropDisc(TicTacToeMoveInfo moveInfo, Player player)
    {
        if(!IsPositionAvailable(moveInfo.Column, moveInfo.Row))
            throw new Exception("Position is not available");
        
        Cells[moveInfo.Column, moveInfo.Row] = player;
        
        return new BoardCell(moveInfo.Column, moveInfo.Row);
    }
}