using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace AdventOfCode2018.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Progress<string> progress = new Progress<string>(Write);
//            Write("Day 1 Part 1 Solution");
//            Write(new Day1Solution().Part1(GetInput(1)).ToString());
//            Write("Day 1 Part 2 Solution");
//            Write(new Day1Solution().Part2(GetInput(1)).ToString());
//            Write("Day 3 Part 1 Solution");
//            Write(new Day3Solution.Part1().Solve(GetInput(3).Split("\n", StringSplitOptions.RemoveEmptyEntries)).ToString());
//            Write("Day 3 Part 2 Solution");
//            Write(new Day3Solution.Part2().Solve(GetInput(3).Split("\n", StringSplitOptions.RemoveEmptyEntries)).ToString());
//            Write("Day 4 Part 1 Solution");
//            Write(new Day4Solution().SolvePart1(GetInput(4).Split("\n", StringSplitOptions.RemoveEmptyEntries)).ToString());
//            Write("Day 4 Part 2 Solution");
//            Write(new Day4Solution().SolvePart2(GetInput(4).Split("\n", StringSplitOptions.RemoveEmptyEntries)).ToString());
//            Write("Day 5 Part 1 Solution");
//            Write(new Day5Solution().SolvePart1(GetInput(5).Trim()).ToString());
//            Write("Day 5 Part 2 Solution");
//            Write(new Day5Solution().SolvePart2(GetInput(5).Trim()).ToString());
//            Write("Day 6 Part 1 Solution");
//            Write(new Day6Solution().SolvePart1(GetInput(6).Split("\n", StringSplitOptions.RemoveEmptyEntries)).ToString());
//            Write("Day 6 Part 2 Solution");
//            Write(new Day6Solution().SolvePart2(GetInput(6).Split("\n", StringSplitOptions.RemoveEmptyEntries)).ToString());
//            Write("Day 7 Part 1 Solution");
//            Write(new Day7Solution().SolvePart1(GetInput(7).Split("\n", StringSplitOptions.RemoveEmptyEntries)).ToString());
//            Write("Day 7 Part 2 Solution");
//            Write(new Day7Solution().SolvePart2(GetInput(7).Split("\n", StringSplitOptions.RemoveEmptyEntries)).ToString());
//            Write("Day 8 Part 1 Solution");
//            Write(new Day8Solution().SolvePart1(GetInput(8)).ToString());
//            Write("Day 8 Part 2 Solution");
//            Write(new Day8Solution().SolvePart2(GetInput(8)).ToString());
//            Write("Day 9 Part 1 Solution");
//            Write(new Day9Solution().SolvePart1(GetInput(9).Trim()).ToString());
//            Write("Day 9 Part 2 Solution");
//            Write(new Day9Solution().SolvePart2(GetInput(9).Trim()).ToString());
//            Write("Day 10 Part 1 Solution");
//            Write(new Day10Solution().SolvePart1(GetInput(10).Split("\n", StringSplitOptions.RemoveEmptyEntries)));
//            Write("Day 10 Part 2 Solution");
//            Write(new Day10Solution().SolvePart2(GetInput(10).Split("\n", StringSplitOptions.RemoveEmptyEntries)).ToString());
//            Write("Day 11 Part 1 Solution");
//            Write(new Day11Solution().SolvePart1(3031).ToString());
//            Write("Day 11 Part 2 Solution");
//            Write(new Day11Solution().SolvePart2(3031).ToString());
//            Write("Day 12 Part 1 Solution");
//            Write(new Day12Solution().SolvePart1(GetInput(12).Split("\n", StringSplitOptions.RemoveEmptyEntries), 20, progress).ToString());
//            Write("Day 12 Part 2 Solution");
//            Write(new Day12Solution().SolvePart1(GetInput(12).Split("\n", StringSplitOptions.RemoveEmptyEntries), 50_000_000_000, progress).ToString());
//            Write("Day 13 Part 1 Solution");
//            Write(new Day13Solution().SolvePart1(GetInput(13)));
//            Write(new Day13Solution().SolvePart2(GetInput(13)));
            Write("Day 14 Part 1 Solution");
            Write(new Day14Solution().SolvePart1("864801"));
            Write(new Day14Solution().SolvePart2("864801").ToString());
            
            Write("Done");
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