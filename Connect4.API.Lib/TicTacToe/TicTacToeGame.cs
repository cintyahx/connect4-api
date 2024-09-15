using Connect4.API.Lib.GamePlay;

namespace Connect4.API.Lib.TicTacToe;

public class TicTacToeGame(Player playerOne, Player playerTwo)
    : BaseGame<TicTacToeMoveInfo, TicTacToeBoard, TicTacToeStrategy>(
        playerOne, 
        playerTwo, 
        new TicTacToeBoard(3, 3, 3),
        new TicTacToeStrategy());