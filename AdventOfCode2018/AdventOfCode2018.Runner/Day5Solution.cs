using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Runner
{
    public class Day5Solution
    {
        private readonly Dictionary<char, char> opposite;

        public Day5Solution()
        {
            opposite = new Dictionary<char, char>();
            for (int i = 65; i <= 90; i++)
            {
                opposite[(char) i] = (char) (i + 32);
                opposite[(char) (i + 32)] = (char) i;
            }
        }

        public (string result, bool changesMade) RemoveReactions(string polymer)
        {
            bool changesMade = false;
            var sb = new StringBuilder();

            for (int i = 0; i < polymer.Length - 1; i++)
            {
                if (opposite[polymer[i]] == polymer[i + 1])
                {
                    i++;
                    changesMade = true;
                    continue;
                }

                sb.Append(polymer[i]);
            }

            if (opposite[polymer[polymer.Length - 1]] != polymer[polymer.Length - 2])
            {
                sb.Append(polymer[polymer.Length - 1]);
            }

            return (sb.ToString(), changesMade);
        }

        public int SolvePart1(string input)
        {
            (string currentPolymer, bool changesMade) info = (input, false);

            do
            {
                info = RemoveReactions(info.currentPolymer);
            } while (info.changesMade);

            return info.currentPolymer.Length;
        }

        public int SolvePart2(string input)
        {
            var shortest = input.Length;
            for (int c = 65; c <= 90; c++)
            {
                var duh = input.Replace(((char) c).ToString(), "").Replace(((char) (c + 32)).ToString(), "");
                var result = FullyReact(duh);
                if (result < shortest)
                {
                    shortest = result;
                }
            }

            return shortest;
        }

        private int FullyReact(string input)
        {
            (string currentPolymer, bool changesMade) info = (input, false);

            do
            {
                info = RemoveReactions(info.currentPolymer);
            } while (info.changesMade);

            return info.currentPolymer.Length;
        }
    }
}