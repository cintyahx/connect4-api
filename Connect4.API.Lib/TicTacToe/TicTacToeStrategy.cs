using Connect4.API.Lib.Board;
using Connect4.API.Lib.GamePlay;

namespace Connect4.API.Lib.TicTacToe;

public class TicTacToeStrategy : GameStrategy<TicTacToeMoveInfo>
{
    public override TicTacToeMoveInfo Play(
        Player currentPlayer, 
        Player opponentPlayer, 
        IGameBoard<TicTacToeMoveInfo> board)
    {
        var availableCells = board.GetAvailableCells().ToList(); 
        
        var random = new Random();
        var index = random.Next(0, availableCells.Count);
        
        return new TicTacToeMoveInfo(availableCells[index].Row, availableCells[index].Column);
    }
}