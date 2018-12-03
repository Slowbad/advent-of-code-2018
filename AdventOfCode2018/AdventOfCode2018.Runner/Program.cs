using System;
using System.IO;
using System.Threading.Tasks.Dataflow;

namespace AdventOfCode2018.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Day 1 Part 1 Solution");
            Write(new Day1Solution().Solve(GetInput(1,1)).ToString());
        }

        private static string GetInput(int dayNum, int partNum)
        {
            return File.ReadAllText(Path.Combine("Input", $"day{dayNum}_part{partNum}.txt"));
        }

        private static void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}