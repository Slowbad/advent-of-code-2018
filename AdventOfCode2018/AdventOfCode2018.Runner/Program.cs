using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace AdventOfCode2018.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Day 1 Part 1 Solution");
            Write(new Day1Solution().Part1(GetInput(1)).ToString());
            Write("Day 1 Part 2 Solution");
            Write(new Day1Solution().Part2(GetInput(1)).ToString());
            Write("Day 3 Part 1 Solution");
            Write(new Day3Solution.Part1().Solve(GetInput(3).Split("\n", StringSplitOptions.RemoveEmptyEntries)).ToString());
        }

        private static string GetInput(int dayNum)
        {
            return File.ReadAllText(Path.Combine("Input", $"day{dayNum}.txt"));
        }

        private static void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}