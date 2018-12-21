using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day10Tests
    {
        [Fact]
        public void ParsesInput()
        {
            var subject = new Day10Solution();

            var result = subject.Parse(new List<string> {"position=< 9, 1> velocity=< 0, 2>"});

            result.Should().BeEquivalentTo(new Day10Solution.Point(9, 1, 0, 2));
        }

        [Fact]
        public void AdvancesPoints()
        {
            var subject = new Day10Solution()
            {
                Points = new List<Day10Solution.Point>
                {
                    new Day10Solution.Point(9, 1, 0, 2),
                    new Day10Solution.Point(7, 0, -1, 0),
                }
            };

            subject.Advance();

            subject.Points
                .Should()
                .BeEquivalentTo(new Day10Solution.Point(9, 3, 0, 2), new Day10Solution.Point(6, 0, -1, 0));
        }
        
        [Fact]
        public void ReversesPoints()
        {
            var subject = new Day10Solution()
            {
                Points = new List<Day10Solution.Point>
                {
                    new Day10Solution.Point(9, 3, 0, 2), new Day10Solution.Point(6, 0, -1, 0)
                }
            };

            subject.Reverse();

            subject.Points
                .Should()
                .BeEquivalentTo(new Day10Solution.Point(9, 1, 0, 2), new Day10Solution.Point(7, 0, -1, 0));
        }
        
        [Fact]
        public void DisplaysPoints()
        {
            var subject = new Day10Solution()
            {
                Points = new List<Day10Solution.Point>
                {
                    new Day10Solution.Point( 9,  1,  0,  2),
                    new Day10Solution.Point( 7,  0, -1,  0),
                    new Day10Solution.Point( 3, -2, -1,  1),
                    new Day10Solution.Point( 6, 10, -2, -1),
                    new Day10Solution.Point( 2, -4,  2,  2),
                    new Day10Solution.Point(-6, 10,  2, -2),
                    new Day10Solution.Point( 1,  8,  1, -1),
                    new Day10Solution.Point( 1,  7,  1,  0),
                    new Day10Solution.Point(-3, 11,  1, -2),
                    new Day10Solution.Point( 7,  6, -1, -1),
                    new Day10Solution.Point(-2,  3,  1,  0),
                    new Day10Solution.Point(-4,  3,  2,  0),
                    new Day10Solution.Point(10, -3, -1,  1),
                    new Day10Solution.Point( 5, 11,  1, -2),
                    new Day10Solution.Point( 4,  7,  0, -1),
                    new Day10Solution.Point( 8, -2,  0,  1),
                    new Day10Solution.Point(15,  0, -2,  0),
                    new Day10Solution.Point( 1,  6,  1,  0),
                    new Day10Solution.Point( 8,  9,  0, -1),
                    new Day10Solution.Point( 3,  3, -1,  1),
                    new Day10Solution.Point( 0,  5,  0, -1),
                    new Day10Solution.Point(-2,  2,  2,  0),
                    new Day10Solution.Point( 5, -2,  1,  2),
                    new Day10Solution.Point( 1,  4,  2,  1),
                    new Day10Solution.Point(-2,  7,  2, -2),
                    new Day10Solution.Point( 3,  6, -1, -1),
                    new Day10Solution.Point( 5,  0,  1,  0),
                    new Day10Solution.Point(-6,  0,  2,  0),
                    new Day10Solution.Point( 5,  9,  1, -2),
                    new Day10Solution.Point(14,  7, -2,  0),
                    new Day10Solution.Point(-3,  6,  2, -1),
                }
            };

            string result = subject.Map();

            var expected = @"........#.............
................#.....
.........#.#..#.......
......................
#..........#.#.......#
...............#......
....#.................
..#.#....#............
.......#..............
......#...............
...#...#.#...#........
....#..#..#.........#.
.......#..............
...........#..#.......
#...........#.........
...#.......#..........";
            result.Split("\n").Should().BeEquivalentTo(expected.Split("\n"));
        }

        [Fact]
        public void SolvesPart1()
        {
            var subject = new Day10Solution();

            var result = subject.SolvePart1(@"position=< 9,  1> velocity=< 0,  2>
position=< 7,  0> velocity=<-1,  0>
position=< 3, -2> velocity=<-1,  1>
position=< 6, 10> velocity=<-2, -1>
position=< 2, -4> velocity=< 2,  2>
position=<-6, 10> velocity=< 2, -2>
position=< 1,  8> velocity=< 1, -1>
position=< 1,  7> velocity=< 1,  0>
position=<-3, 11> velocity=< 1, -2>
position=< 7,  6> velocity=<-1, -1>
position=<-2,  3> velocity=< 1,  0>
position=<-4,  3> velocity=< 2,  0>
position=<10, -3> velocity=<-1,  1>
position=< 5, 11> velocity=< 1, -2>
position=< 4,  7> velocity=< 0, -1>
position=< 8, -2> velocity=< 0,  1>
position=<15,  0> velocity=<-2,  0>
position=< 1,  6> velocity=< 1,  0>
position=< 8,  9> velocity=< 0, -1>
position=< 3,  3> velocity=<-1,  1>
position=< 0,  5> velocity=< 0, -1>
position=<-2,  2> velocity=< 2,  0>
position=< 5, -2> velocity=< 1,  2>
position=< 1,  4> velocity=< 2,  1>
position=<-2,  7> velocity=< 2, -2>
position=< 3,  6> velocity=<-1, -1>
position=< 5,  0> velocity=< 1,  0>
position=<-6,  0> velocity=< 2,  0>
position=< 5,  9> velocity=< 1, -2>
position=<14,  7> velocity=<-2,  0>
position=<-3,  6> velocity=< 2, -1>".Split("\r\n"));

            result.Should().BeEquivalentTo(@"#...#..###
#...#...#.
#...#...#.
#####...#.
#...#...#.
#...#...#.
#...#...#.
#...#..###");
        }
    }
}