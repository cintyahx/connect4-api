namespace Connect4.API.WebAPI.Controllers;

public class BoardDto
{
    public PlayersDto Players { get; set; }
    
    public List<DiscDto> Discs { get; set; }
    
    public PlayerDto CurrentPlayer { get; set; }
    
    public PlayerDto Winner { get; set; }
    
    public bool IsOver { get; set; }
}