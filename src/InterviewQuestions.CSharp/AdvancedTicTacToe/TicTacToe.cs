using System;

namespace InterviewQuestions.CSharp.AdvancedTicTacToe
{
    public class TicTacToe
    {
        public const int MinimumGameBoardSize = 2;
        public const int Player1 = 1;
        public const int Player2 = 2;

        private readonly int[,] _board;
        private readonly int _maxIndex;
        private readonly int _size;

        private int _lastPlayer;

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
            _maxIndex = n - 1;  // Adjust for zero-based indexes
            _size = n;
        }

        /// <summary>
        /// Places a piece on the game board.
        /// </summary>
        /// <param name="row">The row in which to place a piece.</param>
        /// <param name="col">The column in which to place a piece.</param>
        /// <param name="player">The player (1 or 2) placing the piece.</param>
        /// <returns>A value indicating the result of the placement:
        /// <list type="table">
        ///   <listheader>
        ///     <term>Value</term>
        ///     <description>Description</description>
        ///   </listheader>
        ///   <item>
        ///     <term>0</term>
        ///     <description>No winner yet</description>
        ///   </item>
        ///   <item>
        ///     <term>1</term>
        ///     <description>Player 1 won</description>
        ///   </item>
        ///   <item>
        ///     <term>2</term>
        ///     <description>Player 2 won</description>
        ///   </item>
        /// </list></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="row"/> is not valid.
        /// -or- <paramref name="col"/> is not valid.
        /// -or- <paramref name="player"/> is not valid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="player"/> is attempting to move twice in a row.
        /// -or- The specified coordinates are already taken.</exception>
        public int PlacePiece(int row, int col, int player)
        {
            // Adjust coordinates for zero-based indexes
            if (--row < 0)
                throw new ArgumentOutOfRangeException(nameof(row), $"Row {row} is less than 1.");
            if (--col < 0)
                throw new ArgumentOutOfRangeException(nameof(col), $"Col {col} is less than 1.");
            if (row > _maxIndex)
                throw new ArgumentOutOfRangeException(nameof(row), $"Row {row} is greater than {_size}.");
            if (col > _maxIndex)
                throw new ArgumentOutOfRangeException(nameof(col), $"Col {col} is greater than {_size}.");

            if (player != Player1 && player != Player2)
                throw new ArgumentOutOfRangeException(nameof(player), $"Player {player} is not recognized.");
            if (player == _lastPlayer)
                throw new InvalidOperationException($"Player {player} is attempting to move twice in a row.");
            _lastPlayer = player;

            if (_board[row, col] != 0)
                throw new InvalidOperationException($"A piece has already been placed at [{row},{col}].");
            _board[row, col] = player;

            // No win yet
            return 0;
        }
    }
}
