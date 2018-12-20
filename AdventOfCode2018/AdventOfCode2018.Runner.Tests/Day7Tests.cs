using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day7Tests
    {
        [Fact]
        public void ParsesInput()
        {
            var subject = new Day7Solution();
            
            var result = subject.Parse(new List<string>
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin.",
            });

            result.Should().BeEquivalentTo(new Dictionary<string, List<string>>
            {
                {"C", new List<string>()},
                {"A", new List<string>{"C"}},
                {"B", new List<string>{"A"}},
                {"D", new List<string>{"A"}},
                {"F", new List<string>{"C"}},
                {"E", new List<string>{"B", "D", "F"}},
            });
        }

        [Fact]
        public void GeneratesBuildOrder()
        {
            var subject = new Day7Solution();

            var result = subject.SolvePart1(new Dictionary<string, List<string>>
            {
                {"C", new List<string>()},
                {"A", new List<string>{"C"}},
                {"B", new List<string>{"A"}},
                {"D", new List<string>{"A"}},
                {"F", new List<string>{"C"}},
                {"E", new List<string>{"B", "D", "F"}},
            });

            result.Should().Be("CABDFE");
        }

        [Fact]
        public void DeterminesBuildTime()
        {
            var subject = new Day7Solution();

            int result = subject.SolvePart2(2, 0, new Dictionary<string, List<string>>
            {
                {"C", new List<string>()},
                {"A", new List<string> {"C"}},
                {"B", new List<string> {"A"}},
                {"D", new List<string> {"A"}},
                {"F", new List<string> {"C"}},
                {"E", new List<string> {"B", "D", "F"}},
            });

            result.Should().Be(15);
        }
    }
}