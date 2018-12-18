using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace AdventOfCode2018.Runner
{
    public class Day4Solution
    {
        public List<GuardLog> Parse(IEnumerable<string> inputs)
        {
            var logs = new List<GuardLog>();
            foreach (var input in inputs)
            {
                var log = new GuardLog();
                if (input.EndsWith("shift"))
                {
                    var parts = input.Split(new [] {"[", "] Guard #", " begins shift"}, StringSplitOptions.RemoveEmptyEntries);
                    log.Id = Int32.Parse(parts[1]);
                    log.Timestamp = DateTime.Parse(parts[0]);
                    log.Event = EventType.BeginShift;
                }
                else if(input.EndsWith("asleep"))
                {
                    var parts = input.Split(new [] {"[", "] falls asleep"}, StringSplitOptions.RemoveEmptyEntries);
                    log.Timestamp = DateTime.Parse(parts[0]);
                    log.Event = EventType.FallsAsleep;
                }
                else
                {
                    var parts = input.Split(new [] {"[", "] wakes up"}, StringSplitOptions.RemoveEmptyEntries);
                    log.Timestamp = DateTime.Parse(parts[0]);
                    log.Event = EventType.WakesUp;
                }
                logs.Add(log);
            }

            logs.Sort((a, b) => a.Timestamp.CompareTo(b.Timestamp));
            return logs;
        }

        public class GuardLog
        {
            public int Id { get; set; }
            public DateTime Timestamp { get; set; }
            public EventType Event { get; set; }
        }

        public int SolvePart1(IEnumerable<string> inputs)
        {
            return SolvePart1(Parse(inputs));
        }
        
        public int SolvePart1(List<GuardLog> guardLogs)
        {
            List<Shift> shifts = ExtractShifts(guardLogs);
            var guardWithMostSleepTime = shifts
                .GroupBy(x => x.GuardId, x => x, (id, s) => new {GuardId = id, Shifts = s})
                .OrderByDescending(x => x.Shifts.Sum(s => s.TotalSleepTime()))
                .First();
            var result = MostCommonSleepMinute(guardWithMostSleepTime.Shifts);
            return guardWithMostSleepTime.GuardId * result.mostCommonSleepMinute;
        }

        private (int mostCommonSleepMinute, int frequency) MostCommonSleepMinute(IEnumerable<Shift> shifts)
        {
            int[] minutes = new int[60];
            foreach (var shift in shifts)
            {
                for (int minute = 0; minute < 60; minute++)
                {
                    if (shift.AsleepAt(minute))
                        minutes[minute] += 1;
                }
            }

            int maxIndex = -1;
            int maxValue = 0;
            int index = 0;
            foreach (var minute in minutes)
            {
                if (minute > maxValue)
                {
                    maxIndex = index;
                    maxValue = minute;
                }

                index++;
            }

            return (maxIndex, maxValue);
        }

        private List<Shift> ExtractShifts(List<GuardLog> guardLogs)
        {
            var shifts = new List<Shift>();
            Shift currentShift = null;
            int startSleepTime = 0;
            foreach (var log in guardLogs)
            {
                if (log.Event == EventType.BeginShift)
                {
                    if (currentShift != null)
                    {
                        shifts.Add(currentShift);
                    }
                    currentShift = new Shift();
                    currentShift.GuardId = log.Id;
                }
                else if (log.Event == EventType.FallsAsleep)
                {
                    startSleepTime = log.Timestamp.Minute;
                }
                else
                {
                    currentShift.AddSleepTime(startSleepTime, log.Timestamp.Minute);
                }
            }
            return shifts;
        }
        
        public class Shift
        {
            private bool[] isAsleep = new bool[60];
            public int GuardId { get; set; }

            public int TotalSleepTime()
            {
                return isAsleep.Sum(x => x ? 1 : 0);
            }

            public bool AsleepAt(int minute)
            {
                return isAsleep[minute];
            }

            public void AddSleepTime(int startSleepTime, int endSleepTime)
            {
                for (int minute = startSleepTime; minute < endSleepTime; minute++)
                {
                    isAsleep[minute] = true;
                }
            }
        }

        public enum EventType
        {
            BeginShift,
            FallsAsleep,
            WakesUp
        }

        public int SolvePart2(IEnumerable<string> inputs)
        {
            return SolvePart2(Parse(inputs));
        }

        public int SolvePart2(List<GuardLog> guardLogs)
        {
            var shifts = ExtractShifts(guardLogs);
            var guardWithMostFrequentSleepTime = shifts
                .GroupBy(x => x.GuardId, x => x, (id, s) => new {GuardId = id, Shifts = s})
                .Select(x => new {GuardId = x.GuardId, Info = MostCommonSleepMinute(x.Shifts)})
                .OrderByDescending(x => x.Info.frequency)
                .First();
            return guardWithMostFrequentSleepTime.GuardId * guardWithMostFrequentSleepTime.Info.mostCommonSleepMinute;
        }
    }
}