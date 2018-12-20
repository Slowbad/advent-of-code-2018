using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day8Tests
    {
        [Fact]
        public void Parse()
        {
            var subject = new Day8Solution();

            Day8Solution.Node result = subject.Parse("2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2");

            result.Should().BeEquivalentTo(new Day8Solution.Node
            {
                Children = new List<Day8Solution.Node>
                {
                    new Day8Solution.Node()
                    {
                        Metadata = new List<int>{10, 11, 12}
                    },
                    new Day8Solution.Node
                    {
                        Children = new List<Day8Solution.Node>
                        {
                            new Day8Solution.Node()
                            {
                                Metadata = new List<int>{99}
                            }
                        },
                        Metadata = new List<int>{2}
                    }
                },
                Metadata = new List<int>{1, 1, 2}
            });
        }

        [Fact]
        public void SumOfAllMetadata()
        {
            var tree = new Day8Solution.Node
            {
                Children = new List<Day8Solution.Node>
                {
                    new Day8Solution.Node()
                    {
                        Metadata = new List<int> {10, 11, 12}
                    },
                    new Day8Solution.Node
                    {
                        Children = new List<Day8Solution.Node>
                        {
                            new Day8Solution.Node()
                            {
                                Metadata = new List<int> {99}
                            }
                        },
                        Metadata = new List<int> {2}
                    }
                },
                Metadata = new List<int> {1, 1, 2}
            };

            tree.MetadataTotal().Should().Be(138);
        }

        [Fact]
        public void SumOfNodeValues()
        {
            var tree = new Day8Solution.Node
            {
                Children = new List<Day8Solution.Node>
                {
                    new Day8Solution.Node()
                    {
                        Metadata = new List<int> {10, 11, 12}
                    },
                    new Day8Solution.Node
                    {
                        Children = new List<Day8Solution.Node>
                        {
                            new Day8Solution.Node()
                            {
                                Metadata = new List<int> {99}
                            }
                        },
                        Metadata = new List<int> {2}
                    }
                },
                Metadata = new List<int> {1, 1, 2}
            };

            tree.Value().Should().Be(66);
        }
    }
}