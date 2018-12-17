using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day3
    {
        public class Part1
        {
            [Fact]
            public void ParsesAndWorks()
            {
                var subject = new Day3Solution.Part1();
                subject.Solve(new List<string>
                {
                    "#1 @ 1,3: 4x4",
                    "#2 @ 3,1: 4x4",
                }).Should().Be(4);
            }
            
            [Fact]
            public void Works()
            {
                var subject = new Day3Solution.Part1();
                subject.Solve(new List<Day3Solution.Claim>
                {
                    new Day3Solution.Claim()
                    {
                        Id = 1,
                        Left = 1,
                        Top = 3,
                        Width = 4,
                        Height = 4
                    },
                    new Day3Solution.Claim()
                    {
                        Id = 2,
                        Left = 3,
                        Top = 1,
                        Width = 4,
                        Height = 4
                    }
                }).Should().Be(4);
            }


            [Fact]
            public void MakesTheGrid()
            {
                var subject = new Day3Solution.Part1();
                subject.gridSize = 2;
                subject.MakeGrid(new List<Day3Solution.Claim>
                {
                    new Day3Solution.Claim()
                    {
                        Id = 1,
                        Left = 1,
                        Top = 0,
                        Width = 1,
                        Height = 1
                    },
                    new Day3Solution.Claim()
                    {
                        Id = 2,
                        Left = 1,
                        Top = 0,
                        Width = 1,
                        Height = 1
                    },
                    new Day3Solution.Claim()
                    {
                        Id = 3,
                        Left = 0,
                        Top = 1,
                        Width = 1,
                        Height = 1
                    }
                }).Should().BeEquivalentTo(new List<int>[,]
                {
                    {new List<int>(), new List<int>{1, 2}},
                    {new List<int>{3}, new List<int>()},
                });
            }
        }

        public class Part2
        {
            [Fact]
            public void FindEmpty()
            {
                var subject = new Day3Solution.Part2();
                subject.Solve(new List<Day3Solution.Claim>
                {
                    new Day3Solution.Claim()
                    {
                        Id = 1,
                        Left = 1,
                        Top = 0,
                        Width = 1,
                        Height = 1
                    },
                    new Day3Solution.Claim()
                    {
                        Id = 2,
                        Left = 1,
                        Top = 0,
                        Width = 1,
                        Height = 1
                    },
                    new Day3Solution.Claim()
                    {
                        Id = 3,
                        Left = 0,
                        Top = 1,
                        Width = 1,
                        Height = 1
                    }
                }).Should().Be(3);
            }
        }
    }
}