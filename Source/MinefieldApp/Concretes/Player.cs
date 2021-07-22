using MinefieldApp.Interfaces;
using System;

namespace MinefieldApp.Concretes
{
    public class Player : IPlayer
    {
        IBoard _board;
        private int _movesTaken = 0;
        private int _maxLives;
        private int _livesRemaining;

        public Player(IBoard board, int lives = 3)
        {
            _board = board;
            _livesRemaining = lives;
            _maxLives = lives;
        }

        public void MoveUp()
        {
            if (_board.ShiftTileUp())
            {
                Move();
            }
        }

        public void MoveDown()
        {
            if (_board.ShiftTileDown())
            {
                Move();
            }
        }

        public void MoveLeft()
        {
            if (_board.ShiftTileLeft())
            {
                Move();
            }
        }

        public void MoveRight()
        {
            if (_board.ShiftTileRight())
            {
                Move();
            }
        }

        private void Move()
        {
            _movesTaken++;
            Console.WriteLine($" Score (Moves taken): {_movesTaken}");
            _board.GetMineProximity();
            _board.GetActiveTile().Activate(this);

            if (!Finished())
            {
                Console.WriteLine($" Lives left: {_livesRemaining}");
            }

            if (_livesRemaining == 0)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(" ***GAME OVER!***");
                Console.WriteLine(" Press Enter to play again, or Escape to exit");
            }
        }

        public void ReduceLives(int numOfLives)
        {
            _livesRemaining -= numOfLives;
        }

        public int GetMovesTaken()
        {
            return _movesTaken;
        }

        public int GetLivesLeft()
        {
            return _livesRemaining;
        }

        public bool Alive()
        {
            return _livesRemaining > 0 ? true : false;
        }

        public void Reset()
        {
            _livesRemaining = _maxLives;
            _movesTaken = 0;
        }

        public bool Finished()
        {
            return _board.GetActiveTile() == _board.GetFinishedTile();
        }
    }
}