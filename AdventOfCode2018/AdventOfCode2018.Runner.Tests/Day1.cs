using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day1
    {
        public class Part1
        {
            [Fact]
            public void AddsOneNumber()
            {
                var subject = new Day1Solution();
                subject.Part1("+1").Should().Be(1);
            }

            [Fact]
            public void AddsMultipleNumbers()
            {
                var subject = new Day1Solution();
                subject.Part1("+1\n+1").Should().Be(2);
            }

            [Fact]
            public void AddsPositiveAndNegativeNumbers()
            {
                var subject = new Day1Solution();
                subject.Part1("+1\n+1\n-1").Should().Be(1);
            }
        }
        
        public class Part2
        {
            [Theory]
            [InlineData("+1\n-1", 0)]
            [InlineData("-6\n+3\n+8\n+5\n-6", 5)]
            public void ItWorks(string input, int expectedResult)
            {
                var subject = new Day1Solution();
                subject.Part2(input).Should().Be(expectedResult);
            }
        }
    }
}