using Connect4.API.Lib.GamePlay;

namespace Connect4.API.Lib.Connect4;

public class Connect4Game(Player playerOne, Player playerTwo)
    : BaseGame<Connect4MoveInfo, Connect4Board, Connect4Strategy>(
        playerOne, 
        playerTwo, 
        new Connect4Board(7, 6, 4),
        new Connect4Strategy());