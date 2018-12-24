using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Runner
{
    public class Day14Solution
    {

        public int SolvePart2(string targetScores)
        {
            List<int> desiredScores = targetScores.Select(c => int.Parse(c.ToString())).ToList();
            List<int> recipes = new List<int> {3, 7};
            int elf1 = 0;
            int elf2 = 1;
            bool notFound = true;
            int index = 0;
            int positionToCheck = 0;
            while (notFound)
            {
                var elf1Score = recipes[elf1];
                var elf2Score = recipes[elf2];
                var newScore =  elf1Score + elf2Score;
                if (newScore >= 10)
                {
                    recipes.Add(newScore / 10);
                    recipes.Add(newScore % 10);
                }
                else
                {
                    recipes.Add(newScore);
                }

                elf1 = (elf1 + elf1Score + 1) % recipes.Count;
                elf2 = (elf2 + elf2Score + 1) % recipes.Count;

                while (index + positionToCheck < recipes.Count)
                {
                    if (desiredScores[positionToCheck] == recipes[index + positionToCheck])
                    {
                        if (positionToCheck == desiredScores.Count - 1)
                        {
                            notFound = false;
                            break;
                        }

                        positionToCheck++;
                    }
                    else
                    {
                        positionToCheck = 0;
                        index++;
                    }
                }
            }

            return string.Join("", recipes).IndexOf(targetScores, StringComparison.Ordinal);
        }

        public bool ThingInThing(List<int> recipes, List<int> targets)
        {
//            var c = recipes.Count;
//            var lc = targets.Count;
//            int starting = -1;
//            if (recipes[c - 1] == targets[lc - 1])
//            {
//                starting = c - 1;
//            }
//            else if (recipes[c - 2] == targets[lc - 1])
//            {
//                starting = c - 2;
//            }
//
//            if (starting == -1)
//            {
//                return false;
//            }
            var stuff = recipes.TakeLast(targets.Count + 2).ToList();
            for (int i = 0; i + targets.Count - 1 < stuff.Count; i++)
            {
                if (stuff.Skip(i).Take(targets.Count).SequenceEqual(targets))
                    return true;
            }

            return false;
        }
        
        public string SolvePart1(int iterations)
        {
            List<int> recipes = new List<int> {3, 7};
            int elf1 = 0;
            int elf2 = 1;
            while (recipes.Count < iterations + 10)
            {
                var elf1Score = recipes[elf1];
                var elf2Score = recipes[elf2];
                var newScore =  elf1Score + elf2Score;
                if (newScore >= 10)
                {
                    recipes.Add(newScore / 10);
                    recipes.Add(newScore % 10);
                }
                else
                {
                    recipes.Add(newScore);
                }

                var e1Move = elf1 + elf1Score + 1;
                while (e1Move >= recipes.Count)
                {
                    e1Move -= recipes.Count;
                }
                elf1 = e1Move;
                
                var e2Move = elf2 + elf2Score + 1;
                while (e2Move >= recipes.Count)
                {
                    e2Move -= recipes.Count;
                }
                elf2 = e2Move;
            }

            return string.Join("", recipes.Skip(iterations).Take(10));
        }
        
        public string SolvePart1(string input)
        {
            int times = int.Parse(input);
            return SolvePart1(times);
        }
    }
}