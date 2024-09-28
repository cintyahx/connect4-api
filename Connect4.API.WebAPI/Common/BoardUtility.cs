using Connect4.API.Lib.Board;
using Connect4.API.Lib.GamePlay;
using Connect4.API.WebAPI.Controllers;

namespace Connect4.API.WebAPI.Common;

public static class BoardUtility
{
    public static PlayerDto GetPlayerDto(Player? player)
    {
        if (player is null)
        {
            return null;
        }
        
        return new PlayerDto
        {
            Id = player.Id,
            Name = player.Name,
            Color = player.Color,
            IsComputerPlayer = player.IsComputerPlayer
        };
    }
    
    public static BoardDto GetBoardDto<TMoveInfo, TBoard, TStrategy>(BaseGame<TMoveInfo, TBoard, TStrategy> game) 
        where TMoveInfo : BaseMoveInfo where TBoard : BaseGameBoard<TMoveInfo> where TStrategy : GameStrategy<TMoveInfo>
    {
        if (game is null)
        {
            return new BoardDto();
        }
    
        var discs = new List<DiscDto>();

        for (var row = 0; row < game.GetBoard().GetRowLength(); row++)
        {
            for (var column = 0; column < game.GetBoard().GetColumnLength(); column++)
            {
                var color = game.GetBoard().GetDiscColorAtCell(column, row);
                var player = game.GetBoard().GetPlayerMoveAtCell(column, row) ?? 0;
                discs.Add(new DiscDto(color, column, row, player));
            }
        }

        var board = new BoardDto
        {
            Discs = discs,
            IsOver = game.IsOver(),
            Players = new PlayersDto
            {
                PlayerOne = GetPlayerDto(game.GetPlayerOne()),
                PlayerTwo = GetPlayerDto(game.GetPlayerTwo()),
            },
            CurrentPlayer = GetPlayerDto(game.GetCurrentPlayer()),
            Winner = GetPlayerDto(game.GetWinner()),
        };

        return board;
    }
}