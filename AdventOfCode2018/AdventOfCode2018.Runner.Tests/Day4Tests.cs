using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day4Tests
    {
        [Fact]
        public void Parser()
        {
            var subject = new Day4Solution();
            subject.Parse(new List<string>
            {
                "[1518-11-01 00:25] wakes up",
                "[1518-11-01 00:00] Guard #10 begins shift",
                "[1518-11-01 00:05] falls asleep",
            }).Should().BeInAscendingOrder(
                x => x.Timestamp,
                "reasons", 
                new Day4Solution.GuardLog()
                {
                    Id = 10,
                    Event = Day4Solution.EventType.BeginShift,
                    Timestamp = new DateTime(1518, 11, 1, 0, 0, 0)
                }, new Day4Solution.GuardLog
                {
                    Event = Day4Solution.EventType.FallsAsleep,
                    Timestamp = new DateTime(1518, 11, 1, 0, 5, 0)
                }, new Day4Solution.GuardLog
                {
                    Event = Day4Solution.EventType.WakesUp,
                    Timestamp = new DateTime(1518, 11, 1, 0, 25, 0)
                });
        }
        
        [Fact]
        public void What()
        {
            var subject = new Day4Solution();
            subject.SolvePart1(new List<Day4Solution.GuardLog>
            {
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.BeginShift,  Timestamp = new DateTime(1518, 11, 1, 0, 0, 0), Id = 10},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 1, 0, 5, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 1, 0, 25, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 1, 0, 30, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 1, 0, 55, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.BeginShift,  Timestamp = new DateTime(1518, 11, 1, 23, 58, 0), Id = 99},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 2, 0, 40, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 2, 0, 50, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.BeginShift,  Timestamp = new DateTime(1518, 11, 3, 0, 5, 0), Id = 10},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 3, 0, 24, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 3, 0, 29, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.BeginShift,  Timestamp = new DateTime(1518, 11, 4, 0, 2, 0), Id = 99},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 4, 0, 36, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 4, 0, 46, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.BeginShift,  Timestamp = new DateTime(1518, 11, 5, 0, 3, 0), Id = 99},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 5, 0, 45, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 5, 0, 55, 0)},
            }).Should().Be(240);
        }

        [Fact]
        public void Huh()
        {
            var subject = new Day4Solution();
            subject.SolvePart2(new List<Day4Solution.GuardLog>
            {
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.BeginShift,  Timestamp = new DateTime(1518, 11, 1, 0, 0, 0), Id = 10},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 1, 0, 5, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 1, 0, 25, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 1, 0, 30, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 1, 0, 55, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.BeginShift,  Timestamp = new DateTime(1518, 11, 1, 23, 58, 0), Id = 99},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 2, 0, 40, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 2, 0, 50, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.BeginShift,  Timestamp = new DateTime(1518, 11, 3, 0, 5, 0), Id = 10},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 3, 0, 24, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 3, 0, 29, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.BeginShift,  Timestamp = new DateTime(1518, 11, 4, 0, 2, 0), Id = 99},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 4, 0, 36, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 4, 0, 46, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.BeginShift,  Timestamp = new DateTime(1518, 11, 5, 0, 3, 0), Id = 99},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.FallsAsleep, Timestamp = new DateTime(1518, 11, 5, 0, 45, 0)},
                new Day4Solution.GuardLog{Event = Day4Solution.EventType.WakesUp,     Timestamp = new DateTime(1518, 11, 5, 0, 55, 0)},
            }).Should().Be(4455);
        }
    }
}