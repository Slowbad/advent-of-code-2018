using System;
using System.Linq;

namespace AdventOfCode2018.Runner
{
    public class Day1Solution
    {
        public int Solve(string input)
        {
            var numbers = input.Trim().Split("\n");
            return numbers.Select(int.Parse).Sum();
        }
    }
}