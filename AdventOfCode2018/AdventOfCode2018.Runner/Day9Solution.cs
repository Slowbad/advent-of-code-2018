using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AdventOfCode2018.Runner
{
    public class Day9Solution
    {

        public long SolvePart1(string input)
        {
            var parts = input.Split(new[] {" players; last marble is worth ", " points"}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            return SolvePart1(parts[0], parts[1]);
        }
        
        public long SolvePart2(string input)
        {
            var parts = input.Split(new[] {" players; last marble is worth ", " points"}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            return SolvePart1(parts[0], parts[1] * 100);
        }

        public long SolvePart1(int numPlayers, int lastMarble)
        {
            var scores = new long[numPlayers];
            LinkedList<long> circle = new LinkedList<long>();
            var current = circle.AddFirst(0);
            
            for (int i = 1; i <= lastMarble; i++)
            {
                if (i % 23 == 0)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        current = current.Previous ?? circle.Last;
                    }

                    scores[i % numPlayers] += i + current.Value;
                    var remove = current;
                    current = remove.Next;
                    circle.Remove(remove);
                }
                else
                {
                    current = circle.AddAfter(current.Next ?? circle.First, i);
                }
            }

            return scores.Max();
        }
    }
}