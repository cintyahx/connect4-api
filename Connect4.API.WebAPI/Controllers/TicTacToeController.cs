using Connect4.API.Lib.GamePlay;
using Connect4.API.Lib.TicTacToe;
using Connect4.API.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace Connect4.API.WebAPI.Controllers;

public class TicTacToeController : ApiController
{
    private static TicTacToeGame _game;
    
    [HttpPost]
    public IActionResult CreateGame([FromBody] PlayersDto players)
    {
        var playerOne = new Player()
        {
            Id = players.PlayerOne.Id,
            Name = players.PlayerOne.Name,
            Color = players.PlayerOne.Color, 
            IsComputerPlayer = players.PlayerOne.IsComputerPlayer,
        };
        
        var playerTwo = new Player()
        {
            Id = players.PlayerTwo.Id,
            Name = players.PlayerTwo.Name,
            Color = players.PlayerTwo.Color, 
            IsComputerPlayer = players.PlayerTwo.IsComputerPlayer,
        };
        
        _game = new TicTacToeGame(playerOne, playerTwo);
        
        var boardDto = BoardUtility.GetBoardDto<TicTacToeMoveInfo, TicTacToeBoard, TicTacToeStrategy>(_game);
        
        return Ok(new Response(boardDto));
    }

    [HttpGet]
    public IActionResult GetBoard()
    {
        var boardDto = BoardUtility.GetBoardDto<TicTacToeMoveInfo, TicTacToeBoard, TicTacToeStrategy>(_game);
        return Ok(new Response(boardDto));
    }

    [HttpGet]
    [Route("current-player")]
    public IActionResult GetCurrentPlayer()                
    {
        var result = BoardUtility.GetPlayerDto(_game.GetCurrentPlayer());
        return Ok(new Response(result));
    }
   
    [HttpGet]
    [Route("winner")]
    public  IActionResult GetWinner()
    {
        var result = BoardUtility.GetPlayerDto(_game.GetWinner());
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
    public IActionResult DropDisc([FromBody] int column, int row)
    {
        _game.DropDisc(new TicTacToeMoveInfo(column,row));
       return Ok();
    }
}