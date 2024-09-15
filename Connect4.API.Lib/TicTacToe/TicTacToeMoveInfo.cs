using Connect4.API.Lib.Board;

namespace Connect4.API.Lib.TicTacToe;

public class TicTacToeMoveInfo(int row, int column) : BaseMoveInfo
{
    public int Row { get; } = row;
    public int Column { get; } = column;
}