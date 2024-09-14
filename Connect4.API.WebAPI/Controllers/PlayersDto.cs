namespace Connect4.API.WebAPI.Controllers
{
    public class PlayersDto
    {
        public PlayerDto PlayerOne { get; set; }
        
        public PlayerDto PlayerTwo { get; set; }
    }

    public class PlayerDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
        
        public bool IsComputerPlayer { get; set; }
    }
}
