using Connect4.API.Lib;
using Connect4.API.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace Connect4.API.WebAPI.Controllers;

public class GameController : ApiController
{
    private static Game _game;
    
    [HttpPost]
    public IActionResult CreateGame([FromBody] PlayersDto players)
    {
        var playerOne = new Player(players.PlayerOne.Name, players.PlayerOne.Color);
        var playerTwo = new Player(players.PlayerTwo.Name, players.PlayerTwo.Color);
        _game = new Game(playerOne, playerTwo);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetBoard()
    {
        var board = new List<DiscDto>();

        for (var row = 0; row < _game.GetBoard().GetRowLength(); row++)
        {
            for (var column = 0; column < _game.GetBoard().GetColumnLength(); column++)
            {
                var color = _game.GetBoard().GetDiscColorAtCell(column, row);
                board.Add(new DiscDto(color, column, row));
            }
        }

        return Ok(new Response(board));
    }

    [HttpGet]
    [Route("current-player")]
    public IActionResult GetCurrentPlayer()                
    {
        var result = _game.GetCurrentPlayer();
        return Ok(new Response(result));
    }
   
    [HttpGet]
    [Route("winner")]
    public  IActionResult GetWinner()
    {
        var result = _game.GetWinner();
        return Ok(new Response(result));
    }
   
    [HttpGet]
    [Route("is-over")]
    public IActionResult GetIsOver()
    {
        var result = _game.IsOver();
        return Ok(new Response(result));
    }
   
    [HttpPost]
    [Route("drop-disc")]
    public IActionResult DropDisc([FromBody] int column)
    {
       _game.DropDisc(column);
       return Ok();
    }
  
}