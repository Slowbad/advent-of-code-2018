using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Runner
{
    public class Day12Solution
    {
        public long SolvePart1(IEnumerable<string> inputs, long generations, IProgress<string> progress = null)
        {
            var list = inputs.ToList();
            Dictionary<int, char> currentGen = new Dictionary<int, char>();
            Dictionary<string, char> mutations = new Dictionary<string, char>();
            var initialState = list[0].Replace("initial state: ", "").ToCharArray();
            for (int i = 0; i < initialState.Length; i++)
            {
                currentGen[i] = initialState[i];
            }

            int leftMostAlivePlant = currentGen.Where(kv => kv.Value == '#').Min(kv => kv.Key);
            int rightMostAlivePlant = currentGen.Where(kv => kv.Value == '#').Max(kv => kv.Key);

            var mutes = list.Skip(1).Select(s => s.Split(" => ")).OrderBy(sa => sa[0]);
            foreach (var mute in mutes)
            {
                mutations[mute[0]] = mute[1].First();
            }

            int[] recentScores = new int[3];
            for (long i = 0; i < generations; i++)
            {
                if (i % 1_000 == 0)
                {
                    progress?.Report($"Generation {i}");
                }

                var nextGen = new Dictionary<int, char>();
                for (int j = leftMostAlivePlant-2; j < rightMostAlivePlant+2; j++)
                {
                    var key = new []
                    {
                        IsPlantAliveAt(currentGen, j - 2),
                        IsPlantAliveAt(currentGen, j - 1),
                        IsPlantAliveAt(currentGen, j    ),
                        IsPlantAliveAt(currentGen, j + 1),
                        IsPlantAliveAt(currentGen, j + 2),
                    };
                    nextGen[j] = mutations[string.Join("", key)];
                }
                var score = currentGen.Where(kv => kv.Value == '#').Sum(kv => kv.Key);
                var s1 = score - recentScores[0];
                var s2 = recentScores[0] - recentScores[1];
                var s3 = recentScores[1] - recentScores[2];
                if (s1 == s2 && s2 == s3)
                {
                    return score + currentGen.Count(kv => kv.Value == '#') * (generations - i);
                }

                recentScores[2] = recentScores[1];
                recentScores[1] = recentScores[0];
                recentScores[0] = score;
                currentGen = nextGen;
                leftMostAlivePlant = currentGen.Where(kv => kv.Value == '#').Min(kv => kv.Key);
                rightMostAlivePlant = currentGen.Where(kv => kv.Value == '#').Max(kv => kv.Key);
            }

            return currentGen.Where(kv => kv.Value == '#').Sum(kv => kv.Key);
        }

        private char IsPlantAliveAt(Dictionary<int,char> generation, int index)
        {
            const char defaultValue = '.';
            return generation.TryGetValue(index, out var value) ? value : defaultValue;
        }
    }
}