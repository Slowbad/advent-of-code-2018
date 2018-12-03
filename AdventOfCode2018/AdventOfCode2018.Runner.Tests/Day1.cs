using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day1
    {
        [Fact]
        public void AddsOneNumber()
        {
            var subject = new Day1Solution();
            subject.Solve("+1").Should().Be(1);
        }
        
        [Fact]
        public void AddsMultipleNumbers()
        {
            var subject = new Day1Solution();
            subject.Solve("+1\n+1").Should().Be(2);
        }
        
        [Fact]
        public void AddsPositiveAndNegativeNumbers()
        {
            var subject = new Day1Solution();
            subject.Solve("+1\n+1\n-1").Should().Be(1);
        }
    }
}