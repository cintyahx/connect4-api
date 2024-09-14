using Connect4.API.Lib.Board;
using Connect4.API.Lib.Strategies;

namespace Connect4.API.Lib;

public class Game : IGame
    {
        private bool _isOver;

        private Player _currentPlayer;

        private readonly Player _playerOne;
        private readonly Player _playerTwo;

        private Player _winner;

        private readonly IGameBoard _board;
        
        private readonly IGameStrategy _strategy;

        public Game(Player playerOne, Player playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            
            var sortPlayer = new Random().Next(1, 3);
            _currentPlayer = sortPlayer == 1 ? _playerOne : _playerTwo;
           
            _board = new GameBoard();
            _strategy = new EasyLevelStrategy(_board);
            
            if (_currentPlayer.IsComputerPlayer)
            {
                (int playedColumn, int playedRow) = _strategy.Play(_currentPlayer, GetOpponent());
                CheckGameStatus(playedColumn, playedRow);

                SwitchPlayer();
            }
        }

        public IGameBoard GetBoard()
        {
            return _board;
        }

        public bool IsOver()
        {
            return _isOver;
        }
        
        public Player GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public Player GetWinner()
        {
            return _winner;
        }

        public void DropDisc(int column)
        {
            if (_isOver)
            {
                return;
            }

            var droppedRow = _board.DropDisc(column, _currentPlayer);
            if (droppedRow == GameBoard.InvalidRowColumn)
            {
                return;
            }

            CheckGameStatus(column, droppedRow);
            if (_isOver)
            {
                return;
            }

            SwitchPlayer();
        }

        private void SwitchPlayer()
        {
            _currentPlayer = _currentPlayer == _playerTwo ? _playerOne : _playerTwo;
            
            if (_currentPlayer.IsComputerPlayer)
            {
                (int playedColumn, int playedRow) = _strategy.Play(_currentPlayer, GetOpponent());
                CheckGameStatus(playedColumn, playedRow);

                SwitchPlayer();
            }
        }
        
        private Player GetOpponent()
        {
            return _currentPlayer == _playerTwo ? _playerOne : _playerTwo;
        }
        
        private void CheckGameStatus(int column, int row)
        {
            var hasWon = _board.HasPlayerWon(_currentPlayer, new BoardCell(column, row));

            if (hasWon)
            {
                _isOver = true;
                _winner = _currentPlayer;
                return;
            }

            if (_board.IsFull())
            {
                _isOver = true;
            }
        }
    }