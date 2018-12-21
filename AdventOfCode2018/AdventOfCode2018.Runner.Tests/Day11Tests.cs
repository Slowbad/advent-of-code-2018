using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day11Tests
    {
        [Theory]
        [InlineData(3, 5, 8, 4)]
        [InlineData(122, 79, 57, -5)]
        [InlineData(217, 196, 39, 0)]
        [InlineData(101, 153, 71, 4)]
        public void CalculatesPowerLevel(int x, int y, int serialNumber, int expected)
        {
            var subject = new Day11Solution();

            int result = subject.PowerLevel(x, y, serialNumber);

            result.Should().Be(expected);
        }

        [Fact]
        public void SolvesPart1()
        {
            var subject = new Day11Solution();

            (int, int) result = subject.SolvePart1(18);

            result.Should().Be((33, 45));
        }

        [Theory]
        [InlineData(18, 90, 269, 16)]
        [InlineData(42, 232, 251, 12)]
        public void SolvesPart2(int serial, int x, int y, int size)
        {
            var subject = new Day11Solution();

            (int, int, int) result = subject.SolvePart2(serial);

            result.Should().Be((x, y, size));
        }
    }
}