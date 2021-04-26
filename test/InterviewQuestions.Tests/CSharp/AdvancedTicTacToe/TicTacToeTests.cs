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
    }
}
