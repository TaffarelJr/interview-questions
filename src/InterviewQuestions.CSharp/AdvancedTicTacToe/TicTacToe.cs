using System;

namespace InterviewQuestions.CSharp.AdvancedTicTacToe
{
    public class TicTacToe
    {
        public const int MinimumGameBoardSize = 2;

        private readonly int[,] _board;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicTacToe"/> game board.
        /// </summary>
        /// <param name="n">Indicates the dimensions for the game board. <i>(n×n)</i></param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="n"/> is less than <see cref="MinimumGameBoardSize"/>.</exception>
        public TicTacToe(int n)
        {
            if (n < MinimumGameBoardSize)
                throw new ArgumentOutOfRangeException(nameof(n));

            _board = new int[n, n];
        }

        /// <summary>
        /// Place a piece on the game board
        /// </summary>
        /// <param name="row">row to place a piece</param>
        /// <param name="col">column to place a piece</param>
        /// <param name="player">the player (1 or 2) the piece is for</param>
        /// <returns>0 = no winner, 1 = player 1 won, 2 = player 2 won</returns>
        public int PlacePiece(int row, int col, int player)
        {
            return 0;
        }
    }
}
