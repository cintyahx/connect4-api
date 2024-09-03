using Connect4.API.Lib.Board;

namespace Connect4.API.Lib;

public interface IGame
{
    IGameBoard GetBoard();

    Player GetCurrentPlayer();

    Player GetWinner();

    bool IsOver();

    void DropDisc(int column);
}