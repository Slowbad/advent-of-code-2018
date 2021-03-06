using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day9Tests
    {
        [Theory]
        [InlineData(9, 25, 32)]
        [InlineData(10, 1618, 8317)]
        [InlineData(13, 7999, 146373)]
        [InlineData(17, 1104, 2764)]
        [InlineData(21, 6111, 54718)]
        [InlineData(30, 5807, 37305)]
        public void Works(int numPlayers, int lastMarble, int expectedHighScore)
        {
            var subject = new Day9Solution();
            var result = subject.SolvePart1(numPlayers, lastMarble);
            result.Should().Be(expectedHighScore);
        }
    }
}