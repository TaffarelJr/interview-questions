using System;
using System.Linq;

namespace InterviewQuestions.CSharp.AdvancedTicTacToe
{
    /// <summary>
    /// Encapsulates the logic for a game of Tic-Tac-Toe.
    /// </summary>
    public class TicTacToe
    {
        /// <summary>
        /// The minimum size allowed for the game board.
        /// </summary>
        public const int MinimumGameBoardSize = 2;

        /// <summary>
        /// The integer representing Player 1.
        /// </summary>
        public const int Player1 = 1;

        /// <summary>
        /// The integer representing Player 2.
        /// </summary>
        public const int Player2 = 2;

        private readonly int[][] _board;
        private readonly int _maxIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicTacToe"/> class.
        /// </summary>
        /// <param name="n">Indicates the dimensions for the game board. <i>(n×n)</i></param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="n"/> is less than <see cref="MinimumGameBoardSize"/>.</exception>
        public TicTacToe(int n)
        {
            if (n < MinimumGameBoardSize)
                throw new ArgumentOutOfRangeException(nameof(n));

            _board = new int[n][];
            for (var i = 0; i < n; i++)
            {
                _board[i] = new int[n];
            }

            _maxIndex = n - 1;
            Size = n;
            MaxPieces = n * n;
        }

        /// <summary>
        /// Gets the size of the Tic-Tac-Toe board.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Gets the maximum number of pieces that can be placed on the game board.
        /// </summary>
        public int MaxPieces { get; }

        /// <summary>
        /// Gets the last player who placed a piece on the game board.
        /// </summary>
        public int LastPlayer { get; private set; }

        /// <summary>
        /// Gets the number of pieces that have been placed in the current game.
        /// </summary>
        public int PiecesPlaced { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the game is over.
        /// </summary>
        public bool GameOver { get; private set; }

        /// <summary>
        /// Gets the winner of the game.
        /// </summary>
        public int Winner { get; private set; }

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
        /// -or- The specified coordinates are already taken.
        /// -or- The game has already been completed.</exception>
        public int PlacePiece(int row, int col, int player)
        {
            if (row < 1 || row > Size)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (col < 1 || col > Size)
                throw new ArgumentOutOfRangeException(nameof(col));
            if (player != Player1 && player != Player2)
                throw new ArgumentOutOfRangeException(nameof(player));

            if (GameOver)
                throw new InvalidOperationException("The game is already over.");
            if (player == LastPlayer)
                throw new InvalidOperationException("Player cannot move twice in a row.");
            if (_board[--row][--col] != 0) // Adjust the coordinates for zero-based indexes
                throw new InvalidOperationException($"A piece already exists at these coordinates.");

            // If everything looks good, place the piece
            _board[row][col] = player;
            LastPlayer = player;
            PiecesPlaced++;

            // Check for a possible winner
            if (RowWin(row, player)
                || ColumnWin(col, player)
                || (row == col && MainDiagonalWin(player))
                || (row == _maxIndex - col && OppositeDiagonalWin(player)))
                    Winner = player;

            // Check if the game is over
            if (Winner > 0 || PiecesPlaced == MaxPieces)
                GameOver = true;

            return Winner;
        }

        private bool RowWin(int row, int player) =>
            Enumerable.Range(0, Size)
                .Select(col => _board[row][col])
                .All(p => p == player);

        private bool ColumnWin(int col, int player) =>
            Enumerable.Range(0, Size)
                .Select(row => _board[row][col])
                .All(p => p == player);

        private bool MainDiagonalWin(int player) =>
            Enumerable.Range(0, Size)
                .Select(i => _board[i][i])
                .All(p => p == player);

        private bool OppositeDiagonalWin(int player) =>
            Enumerable.Range(0, Size)
                .Select(i => _board[i][_maxIndex - i])
                .All(p => p == player);
    }
}
