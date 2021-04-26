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
    }
}
