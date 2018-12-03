using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ItWorks()
        {
            (1 + 1).Should().Be(2);
        }
    }
}