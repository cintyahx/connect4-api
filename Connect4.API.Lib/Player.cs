namespace Connect4.API.Lib;

public class Player(string name, string color, bool isComputerPlayer)
{
    public string Name { get; } = name;

    public string Color { get;  } = color;

    public bool IsComputerPlayer { get; } = isComputerPlayer;
}