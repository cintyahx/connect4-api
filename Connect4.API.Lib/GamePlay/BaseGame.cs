using Connect4.API.Lib.Board;

namespace Connect4.API.Lib.GamePlay;

public abstract class BaseGame<TMoveInfo, TBaseGameBoard, TGameStrategy>
    : IGame<TMoveInfo, TBaseGameBoard>
    where TMoveInfo : BaseMoveInfo
    where TBaseGameBoard : BaseGameBoard<TMoveInfo>
    where TGameStrategy : GameStrategy<TMoveInfo>
{
    private readonly Player _playerOne;
   
    private readonly Player _playerTwo;

    private Player? _winner;
    
    private readonly TGameStrategy _strategy;

    private bool _isOverGame;

    private Player _currentPlayer;

    private readonly TBaseGameBoard _board;

    protected BaseGame(Player playerOne, Player playerTwo, TBaseGameBoard board, TGameStrategy strategy)
    {
        _board = board;
        _playerOne = playerOne;
        _playerTwo = playerTwo;
        _strategy = strategy;
        
        var sortPlayer = new Random().Next(1, 3);
        _currentPlayer = sortPlayer == 1 ? _playerOne : _playerTwo;

        if (!_currentPlayer.IsComputer) return;

        var moveInfo = _strategy.Play(_currentPlayer, _playerOne, _board);
        DropDisc(moveInfo);
    }

    public bool IsOver()
    {
        return _isOverGame;
    }

    public void DropDisc(TMoveInfo moveInfo)
    {
        if (_isOverGame)
        {
            return;
        }

        var boardCell = _board.DropDisc(moveInfo, _currentPlayer);
        
        if (_board.HasPlayerWon(_currentPlayer, boardCell))
        {
            _winner = _currentPlayer;
            _isOverGame = true;
        }
        else if (_board.IsFull())
        {
            _isOverGame = true;
        }
        else
        {
            SwitchPlayer();
        }
    }

    public TBaseGameBoard GetBoard()
    {
        return _board;
    }

    public Player GetCurrentPlayer()
    {
        return _currentPlayer;
    }

    public Player? GetWinner()
    {
        return _winner;
    }

    private void SwitchPlayer()
    {
        _currentPlayer = _currentPlayer == _playerTwo ? _playerOne : _playerTwo;

        if (!_currentPlayer.IsComputer) return;
        
        var moveInfo = _strategy.Play(_currentPlayer, GetOpponent(), _board);
        DropDisc(moveInfo);
    }
    
    private Player GetOpponent()
    {
        return _currentPlayer == _playerTwo ? _playerOne : _playerTwo;
    }
}