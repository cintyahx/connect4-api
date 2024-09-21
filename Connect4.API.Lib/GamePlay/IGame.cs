using Connect4.API.Lib.Board;

namespace Connect4.API.Lib.GamePlay;

public interface IGame<TMoveInfo, TBaseGameBoard> 
    where TMoveInfo : BaseMoveInfo
    where TBaseGameBoard : BaseGameBoard<TMoveInfo>
{
    TBaseGameBoard GetBoard();

    Player GetCurrentPlayer();

    Player? GetWinner();

    bool IsOver();

    void DropDisc(TMoveInfo moveInfo);
    
    Player GetPlayerOne();

    Player GetPlayerTwo();
}