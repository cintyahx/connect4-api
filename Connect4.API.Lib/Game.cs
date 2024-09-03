using Connect4.API.Lib.Board;

namespace Connect4.API.Lib;

public class Game : IGame
    {
        private bool _isOver;

        private Player _currentPlayer;

        private readonly Player _playerOne;
        private readonly Player _playerTwo;

        private Player _winner;

        private readonly IGameBoard _board;

        public Game(Player playerOne, Player playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _currentPlayer = _playerOne;
            _board = new GameBoard();
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