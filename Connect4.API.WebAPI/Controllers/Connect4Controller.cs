using Connect4.API.Lib;
using Connect4.API.Lib.Connect4;
using Connect4.API.Lib.GamePlay;
using Connect4.API.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace Connect4.API.WebAPI.Controllers;

public class Connect4Controller : ApiController
{
    private static Connect4Game _game;
    
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
        _game = new Connect4Game(playerOne, playerTwo);
        
        return Ok(new Response(GetBoardDto()));
    }

    [HttpGet]
    public IActionResult GetBoard()
    {
        return Ok(new Response(GetBoardDto()));
    }

    [HttpGet]
    [Route("current-player")]
    public IActionResult GetCurrentPlayer()                
    {
        var currentPlayer = _game.GetCurrentPlayer();
        var result = new PlayerDto
        {
            Id = currentPlayer.Id,
            Name = currentPlayer.Name,
            Color = currentPlayer.Color,
            IsComputerPlayer = currentPlayer.IsComputerPlayer
        };
        return Ok(new Response(result));
    }
   
    [HttpGet]
    [Route("winner")]
    public  IActionResult GetWinner()
    {
        var winner = _game.GetWinner();
        if (winner == null)
        {
            return Ok(new Response(null));
        }

        var result = new PlayerDto
        {
            Id = winner.Id,
            Name = winner.Name,
            Color = winner.Color,
            IsComputerPlayer = winner.IsComputerPlayer
        };
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
        var connectMoveInfo = new Connect4MoveInfo(column);
        _game.DropDisc(connectMoveInfo);
       return Ok();
    }

    private BoardDto GetBoardDto()
    {
        if (_game is null)
        {
            return new BoardDto();
        }
        
        var disc = new List<DiscDto>();

        for (var row = 0; row < _game.GetBoard().GetRowLength(); row++)
        {
            for (var column = 0; column < _game.GetBoard().GetColumnLength(); column++)
            {
                var color = _game.GetBoard().GetDiscColorAtCell(column, row);
                disc.Add(new DiscDto(color, column, row));
            }
        }
        
        var currentPlayer = _game.GetCurrentPlayer();
        
        var board = new BoardDto
        {
            Discs = disc,
            IsOver = _game.IsOver(),
            Players = new PlayersDto
            {
                PlayerOne = new PlayerDto
                {
                    Id = _game.GetPlayerOne().Id,
                    Name = _game.GetPlayerOne().Name,
                    Color = _game.GetPlayerOne().Color,
                    IsComputerPlayer = _game.GetPlayerOne().IsComputerPlayer
                },
                PlayerTwo = new PlayerDto
                {
                    Id = _game.GetPlayerTwo().Id,
                    Name = _game.GetPlayerTwo().Name,
                    Color = _game.GetPlayerTwo().Color,
                    IsComputerPlayer = _game.GetPlayerTwo().IsComputerPlayer
                },
            },
            CurrentPlayer = new PlayerDto
            {
                Id = currentPlayer.Id,
                Name = currentPlayer.Name,
                Color = currentPlayer.Color,
                IsComputerPlayer = currentPlayer.IsComputerPlayer
            }
        };

        var winner = _game.GetWinner();
        if (winner is not null)
        {
            board.Winner= new PlayerDto
            {
                Id = winner.Id,
                Name = winner.Name,
                Color = winner.Color,
                IsComputerPlayer = winner.IsComputerPlayer
            };
        }

        return board;
    }
}