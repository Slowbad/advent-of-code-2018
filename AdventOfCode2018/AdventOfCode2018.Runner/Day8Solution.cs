using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AdventOfCode2018.Runner
{
    public class Day8Solution
    {
        public int SolvePart1(string input)
        {
            var tree = Parse(input);
            return tree.MetadataTotal();
        }
        
        public Node Parse(string input)
        {
            var values = input.Split(' ').Select(int.Parse).ToArray();
            int position = 0;
            var root = ReadNode(values, ref position);
            return root;
        }

        private Node ReadNode(int[] values, ref int position)
        {
            var node = new Node();
            var numOfChildren = values[position++];
            var numOfMetadata = values[position++];

            for (int i = 0; i < numOfChildren; i++)
            {
                node.Children.Add(ReadNode(values, ref position));
            }

            for (int i = 0; i < numOfMetadata; i++)
            {
                node.Metadata.Add(values[position++]);
            }

            return node;
        }

        public class Node
        {
            public List<Node> Children { get; set; } = new List<Node>();
            public List<int> Metadata { get; set; } = new List<int>();


            public int MetadataTotal()
            {
                return Children.Sum(c => c.MetadataTotal()) + Metadata.Sum();
            }

            public int Value()
            {
                if (Children.Count == 0)
                {
                    return Metadata.Sum();
                }

                int totalValue = 0;
                foreach (var index in Metadata)
                {
                    if (index - 1 < Children.Count)
                    {
                        totalValue += Children[index - 1].Value();
                    }
                }

                return totalValue;
            }
        }

        public int SolvePart2(string input)
        {
            var tree = Parse(input);
            return tree.Value();
        }
    }
}