using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day6Tests
    {
        [Fact]
        public void ParsesInput()
        {
            var subject = new Day6Solution();
            subject.Parse(new List<string>
            {
                "1, 1",
                "143, 298"
            }).Should().BeEquivalentTo(
                new Day6Solution.Coordinate(1, 1, 1),
                new Day6Solution.Coordinate(2, 143, 298));
        }

        [Fact]
        public void PutCoordinatesOnGrid()
        {
            var subject = new Day6Solution();
            int gridSize = 10;
            
            var result = subject.CreateGridWithCoordinates(gridSize, new List<Day6Solution.Coordinate>
            {
                new Day6Solution.Coordinate(1, 1, 1),
                new Day6Solution.Coordinate(2, 1, 6),
                new Day6Solution.Coordinate(3, 8, 3),
                new Day6Solution.Coordinate(4, 3, 4),
                new Day6Solution.Coordinate(5, 5, 5),
                new Day6Solution.Coordinate(6, 8, 9),
            });

            result.Should().BeEquivalentTo(new int[,]
            {
                {1, 1, 1, 1, 1, 0, 3, 3, 3, 3},
                {1, 1, 1, 1, 1, 0, 3, 3, 3, 3},
                {1, 1, 1, 4, 4, 5, 3, 3, 3, 3},
                {1, 1, 4, 4, 4, 5, 3, 3, 3, 3},
                {0, 0, 4, 4, 4, 5, 5, 3, 3, 3},
                {2, 2, 0, 4, 5, 5, 5, 5, 3, 3},
                {2, 2, 2, 0, 5, 5, 5, 5, 0, 0},
                {2, 2, 2, 0, 5, 5, 5, 6, 6, 6},
                {2, 2, 2, 0, 5, 5, 6, 6, 6, 6},
                {2, 2, 2, 0, 6, 6, 6, 6, 6, 6},
            });
        }

        [Fact]
        public void DetermineLargestNonInfiniteArea()
        {
            var subject = new Day6Solution();
            var grid = new int[,]
            {
                {1, 1, 1, 1, 1, 0, 3, 3, 3, 3},
                {1, 1, 1, 1, 1, 0, 3, 3, 3, 3},
                {1, 1, 1, 4, 4, 5, 3, 3, 3, 3},
                {1, 1, 4, 4, 4, 5, 3, 3, 3, 3},
                {0, 0, 4, 4, 4, 5, 5, 3, 3, 3},
                {2, 2, 0, 4, 5, 5, 5, 5, 3, 3},
                {2, 2, 2, 0, 5, 5, 5, 5, 0, 0},
                {2, 2, 2, 0, 5, 5, 5, 6, 6, 6},
                {2, 2, 2, 0, 5, 5, 6, 6, 6, 6},
                {2, 2, 2, 0, 6, 6, 6, 6, 6, 6},
            };
            var gridSize = 10;
            var numberOfCoordinates = 6;

            var result = subject.DetermineLargestNonInfiniteArea(grid, gridSize, numberOfCoordinates);

            result.Should().Be(17);
        }

        [Fact]
        public void CreateSafeGrid()
        {
            var subject = new Day6Solution();
            var gridSize = 10;
            var safeDistance = 32;

            var result = subject.CreateSafeGrid(gridSize, safeDistance, new List<Day6Solution.Coordinate>
            {
                new Day6Solution.Coordinate(1, 1, 1),
                new Day6Solution.Coordinate(2, 1, 6),
                new Day6Solution.Coordinate(3, 8, 3),
                new Day6Solution.Coordinate(4, 3, 4),
                new Day6Solution.Coordinate(5, 5, 5),
                new Day6Solution.Coordinate(6, 8, 9),
            });

            result.Should().BeEquivalentTo(new bool[,]
            {
                {false, false, false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false, false, false},
                {false, false, false, true, true, true, false, false, false, false},
                {false, false, true, true, true, true, true, false, false, false},
                {false, false, true, true, true, true, true, false, false, false},
                {false, false, false, true, true, true, false, false, false, false},
                {false, false, false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false, false, false},
            });
        }
    }
}