using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day14Tests
    {
        [Theory]
        [InlineData(9, "5158916779")]
        [InlineData(5, "0124515891")]
        [InlineData(18, "9251071085")]
        [InlineData(2018, "5941429882")]
        public void Part1Examples(int iterations, string expectedScores)
        {
            var subject = new Day14Solution();

            var result = subject.SolvePart1(iterations);

            result.Should().Be(expectedScores);
        }
        
        [Theory]
        [InlineData("51589", 9)]
        [InlineData("01245", 5)]
        [InlineData("92510", 18)]
        [InlineData("59414", 2018)]
        public void Part2Examples(string desiredScore, int expectedIterationsToFind)
        {
            var subject = new Day14Solution();

            var result = subject.SolvePart2(desiredScore);

            result.Should().Be(expectedIterationsToFind);
        }
    }
}