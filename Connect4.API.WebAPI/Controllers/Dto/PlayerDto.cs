namespace Connect4.API.WebAPI.Controllers;

public class PlayerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
        
    public string Color { get; set; }
        
    public bool IsComputerPlayer { get; set; }
}