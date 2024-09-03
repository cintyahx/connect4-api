namespace Connect4.API.Lib;

public class Player
{
    public Player(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public string Name { get; }

    public string Color { get;  }
}