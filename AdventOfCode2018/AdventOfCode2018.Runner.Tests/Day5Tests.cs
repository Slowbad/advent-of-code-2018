using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day5Tests
    {
        [Fact]
        public void SinglePass()
        {
            var subject = new Day5Solution();
            subject.RemoveReactions("dabAcCaCBAcCcaDA")
                .Should().BeEquivalentTo(("dabAaCBAcaDA", true));
        }

        [Fact]
        public void SolvePart1()
        {
            var subject = new Day5Solution();
            subject.SolvePart1("dabAcCaCBAcCcaDA")
                .Should().Be(10);
        }
        
        [Fact]
        public void SolvePart2()
        {
            var subject = new Day5Solution();
            subject.SolvePart2("dabAcCaCBAcCcaDA")
                .Should().Be(4);
        }
    }
}