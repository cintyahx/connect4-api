using Connect4.API.Lib.Board;

namespace Connect4.API.Lib.Connect4;

public class Connect4MoveInfo(int column) : BaseMoveInfo
{
    public int Column { get; set; } = column;
}