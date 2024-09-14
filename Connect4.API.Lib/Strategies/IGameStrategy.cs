namespace Connect4.API.Lib.Strategies;

public interface IGameStrategy
{
    (int, int) Play(Player currentPlayer, Player opponentPlayer);
}