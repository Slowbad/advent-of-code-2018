using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AdventOfCode2018.Runner
{
    public class Day1Solution
    {
        public int Part1(string input)
        {
            var numbers = input.Trim().Split("\n");
            return numbers.Select(int.Parse).Sum();
        }

        public int Part2(string input)
        {
            var lines = input.Trim().Split("\n");
            var numbers = lines.Select(int.Parse);
            HashSet<int> set = new HashSet<int>();
            int frequency = 0;
            set.Add(frequency);
            while (true)
            {
                foreach (var number in numbers)
                {
                    frequency += number;
                    if (set.Contains(frequency))
                    {
                        return frequency;
                    }
                    set.Add(frequency);
                }
            }
        }
    }
}