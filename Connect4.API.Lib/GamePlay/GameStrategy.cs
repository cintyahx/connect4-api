using Connect4.API.Lib.Board;

namespace Connect4.API.Lib.GamePlay;

public abstract class GameStrategy<TMoveInfo> where TMoveInfo : BaseMoveInfo
{
    public abstract TMoveInfo Play(Player currentPlayer, Player opponentPlayer,  IGameBoard<TMoveInfo> board);
}