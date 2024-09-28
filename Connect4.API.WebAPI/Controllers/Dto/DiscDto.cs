namespace Connect4.API.WebAPI.Controllers;

public class DiscDto(string color, int column, int row, int player)
{
    public string Color { get;  } = color;

    public int Column { get; } = column;

    public int Row { get; } = row;

    public int Player { get; } = player;
}