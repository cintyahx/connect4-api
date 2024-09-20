namespace Connect4.API.WebAPI.Controllers;

public class PlayerDto
{
    public string Name { get; set; }
        
    public string Color { get; set; }
        
    public bool IsComputerPlayer { get; set; }
}