using System;
using FluentAssertions;
using Xunit;

namespace InterviewQuestions.CSharp.AdvancedTicTacToe
{
    public class TicTacToeTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Constructor_ShouldThrowException_WhenBoardSizeIsInvalid(
            int boardSize)
        {
            // Act
            Action action = () => _ = new TicTacToe(boardSize);

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(2, 3)]
        [InlineData(3, 0)]
        [InlineData(3, 4)]
        [InlineData(4, 0)]
        [InlineData(4, 5)]
        public void PlacePiece_ShouldValidateRow(int boardSize, int row)
        {
            // Arrange
            var subject = new TicTacToe(boardSize);

            // Act
            Action action = () => _ = subject.PlacePiece(row, 1, TicTacToe.Player1);

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(2, 3)]
        [InlineData(3, 0)]
        [InlineData(3, 4)]
        [InlineData(4, 0)]
        [InlineData(4, 5)]
        public void PlacePiece_ShouldValidateColumn(int boardSize, int col)
        {
            // Arrange
            var subject = new TicTacToe(boardSize);

            // Act
            Action action = () => _ = subject.PlacePiece(1, col, TicTacToe.Player1);

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(TicTacToe.Player2, TicTacToe.Player1)]
        public void PlacePiece_ShouldValidatePlayer(
            int startingPlayer,
            int otherPlayer)
        {
            // Arrange
            var subject = new TicTacToe(3);

            // These will help the tests be more concise
            static void OutOfRange(Action move) =>
                move.Should().Throw<ArgumentOutOfRangeException>();
            static void Invalid(Action move) =>
                move.Should().Throw<InvalidOperationException>();

            // Act 1 ('starting' player must be valid)
            OutOfRange(() => _ = subject.PlacePiece(1, 1, 0));
            OutOfRange(() => _ = subject.PlacePiece(1, 1, 3));
            subject.PlacePiece(1, 1, startingPlayer).Should().Be(0);

            // Act 2 (next player must be 'other' player)
            OutOfRange(() => _ = subject.PlacePiece(2, 2, 0));
            OutOfRange(() => _ = subject.PlacePiece(2, 2, 3));
            Invalid(() => _ = subject.PlacePiece(2, 2, startingPlayer));
            subject.PlacePiece(2, 2, otherPlayer).Should().Be(0);

            // Act 3 (next player must be 'starting' player again)
            OutOfRange(() => _ = subject.PlacePiece(3, 3, 0));
            OutOfRange(() => _ = subject.PlacePiece(3, 3, 3));
            Invalid(() => _ = subject.PlacePiece(3, 3, otherPlayer));
            subject.PlacePiece(3, 3, startingPlayer).Should().Be(0);
        }

        [Fact]
        public void PlacePiece_ShouldNotAllowPieceToBeOverwritten()
        {
            // Arrange
            var subject = new TicTacToe(3);

            subject.PlacePiece(1, 1, TicTacToe.Player1).Should().Be(0);

            // Act
            Action action = () => _ = subject.PlacePiece(1, 1, TicTacToe.Player2);

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(2, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(2, TicTacToe.Player2, TicTacToe.Player1)]
        [InlineData(3, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(3, TicTacToe.Player2, TicTacToe.Player1)]
        [InlineData(4, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(4, TicTacToe.Player2, TicTacToe.Player1)]
        public void PlacePiece_ShouldDetectRowWin(
            int boardSize,
            int player1,
            int player2)
        {
            // Arrange
            for (var player1Row = 1; player1Row <= boardSize; player1Row++)
            {
                var player2Row = player1Row == boardSize
                    ? player1Row - 1
                    : player1Row + 1;

                var subject = new TicTacToe(boardSize);
                for (var col = 1; col < boardSize; col++)
                {
                    // Act
                    subject.PlacePiece(player1Row, col, player1).Should().Be(0);
                    subject.PlacePiece(player2Row, col, player2).Should().Be(0);
                }

                // Assert winner
                subject.PlacePiece(player1Row, boardSize, player1).Should().Be(player1);

                // Assert game over
                Action action = () => subject.PlacePiece(player2Row, boardSize, player2);
                action.Should().Throw<InvalidOperationException>();
            }
        }

        [Theory]
        [InlineData(2, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(2, TicTacToe.Player2, TicTacToe.Player1)]
        [InlineData(3, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(3, TicTacToe.Player2, TicTacToe.Player1)]
        [InlineData(4, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(4, TicTacToe.Player2, TicTacToe.Player1)]
        public void PlacePiece_ShouldDetectColumnWin(
            int boardSize,
            int player1,
            int player2)
        {
            // Arrange
            for (var player1Col = 1; player1Col <= boardSize; player1Col++)
            {
                var player2Col = player1Col == boardSize
                    ? player1Col - 1
                    : player1Col + 1;

                var subject = new TicTacToe(boardSize);
                for (var row = 1; row < boardSize; row++)
                {
                    // Act
                    subject.PlacePiece(row, player1Col, player1).Should().Be(0);
                    subject.PlacePiece(row, player2Col, player2).Should().Be(0);
                }

                // Assert winner
                subject.PlacePiece(boardSize, player1Col, player1).Should().Be(player1);

                // Assert game over
                Action action = () => subject.PlacePiece(boardSize, player2Col, player2);
                action.Should().Throw<InvalidOperationException>();
            }
        }

        [Theory]
        [InlineData(2, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(2, TicTacToe.Player2, TicTacToe.Player1)]
        [InlineData(3, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(3, TicTacToe.Player2, TicTacToe.Player1)]
        [InlineData(4, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(4, TicTacToe.Player2, TicTacToe.Player1)]
        public void PlacePiece_ShouldDetectMainDiagonalWin(
            int boardSize,
            int player1,
            int player2)
        {
            // Arrange
            var subject = new TicTacToe(boardSize);
            for (var i = 1; i < boardSize; i++)
            {
                // Act
                subject.PlacePiece(i, i, player1).Should().Be(0);
                subject.PlacePiece(i + 1, i, player2).Should().Be(0);
            }

            // Assert winner
            subject.PlacePiece(boardSize, boardSize, player1).Should().Be(player1);

            // Assert game over
            Action action = () => subject.PlacePiece(boardSize - 1, boardSize, player2);
            action.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(2, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(2, TicTacToe.Player2, TicTacToe.Player1)]
        [InlineData(3, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(3, TicTacToe.Player2, TicTacToe.Player1)]
        [InlineData(4, TicTacToe.Player1, TicTacToe.Player2)]
        [InlineData(4, TicTacToe.Player2, TicTacToe.Player1)]
        public void PlacePiece_ShouldDetectOppositeDiagonalWin(
            int boardSize,
            int player1,
            int player2)
        {
            // Arrange
            var subject = new TicTacToe(boardSize);
            for (var row = 1; row < boardSize; row++)
            {
                var col = boardSize - row + 1;

                // Act
                subject.PlacePiece(row, col, player1).Should().Be(0);
                subject.PlacePiece(row + 1, col, player2).Should().Be(0);
            }

            // Assert winner
            subject.PlacePiece(boardSize, 1, player1).Should().Be(player1);

            // Assert game over
            Action action = () => subject.PlacePiece(boardSize - 1, 1, player2);
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void PlacePiece_ShouldDetectTie()
        {
            // Arrange
            var subject = new TicTacToe(3);

            // Act
            subject.PlacePiece(1, 1, TicTacToe.Player1).Should().Be(0);
            subject.PlacePiece(2, 1, TicTacToe.Player2).Should().Be(0);
            subject.PlacePiece(3, 1, TicTacToe.Player1).Should().Be(0);
            subject.PlacePiece(1, 2, TicTacToe.Player2).Should().Be(0);
            subject.PlacePiece(3, 2, TicTacToe.Player1).Should().Be(0);
            subject.PlacePiece(3, 3, TicTacToe.Player2).Should().Be(0);
            subject.PlacePiece(1, 3, TicTacToe.Player1).Should().Be(0);
            subject.PlacePiece(2, 2, TicTacToe.Player2).Should().Be(0);
            subject.PlacePiece(2, 3, TicTacToe.Player1).Should().Be(0);

            // Assert
            subject.GameOver.Should().BeTrue();
            subject.Winner.Should().Be(0);
        }
    }
}
