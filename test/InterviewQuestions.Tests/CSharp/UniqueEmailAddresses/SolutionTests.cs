using System;
using FluentAssertions;
using Xunit;

namespace InterviewQuestions.CSharp.UniqueEmailAddresses
{
    public class SolutionTests
    {
        [Fact]
        public void NumberOfUniqueEmailAddresses_ShouldThrowException_WhenListIsNull()
        {
            // Arrange
            var subject = new Solution();

            // Act
            Action action = () =>
                _ = subject.NumberOfUniqueEmailAddresses(emails: null);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void NumberOfUniqueEmailAddresses_ShouldIgnoreInvalidEmailAddresses()
        {
            // Arrange
            var emails = new[]
            {
                null,
                "",
                "   ",
                "contains a@space",
                "too@many@ats",
                "invalid^character@inlocalpart",
                "invalidcharacter@in^domainpart",
            };

            var subject = new Solution();

            // Act
            var result = subject.NumberOfUniqueEmailAddresses(emails);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void NumberOfUniqueEmailAddresses_ShouldFlattenLocalPart()
        {
            // Arrange
            var emails = new[]
            {
                "team1@somewhere.com",
                "team.1+bob@somewhere.com",
                "team1+jill+bob@somewhere.com",
            };

            var subject = new Solution();

            // Act
            var result = subject.NumberOfUniqueEmailAddresses(emails);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public void NumberOfUniqueEmailAddresses_ShouldDifferentiateDomainPart()
        {
            // Arrange
            var emails = new[]
            {
                "team2@somewhere.com",
                "team2@some.where.com",
            };

            var subject = new Solution();

            // Act
            var result = subject.NumberOfUniqueEmailAddresses(emails);

            // Assert
            result.Should().Be(2);
        }
    }
}
