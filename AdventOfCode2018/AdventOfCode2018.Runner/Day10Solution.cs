using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Runner
{
    public class Day10Solution
    {
        public List<Point> Parse(IEnumerable<string> inputs)
        {
            var points = new List<Point>();
            foreach (var input in inputs)
            {
                var parts = input
                    .Split(new[] {"position=<", ", ", "> velocity=<", ">"}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                points.Add(new Point(parts[0], parts[1], parts[2], parts[3]));
            }
            return points;
        }

        public class Point
        {
            public int X { get; private set; }
            public int Y { get; private set; }
            public int Vx { get; }
            public int Vy { get; }

            public Point(int x, int y, int vx, int vy)
            {
                X = x;
                Y = y;
                Vx = vx;
                Vy = vy;
            }

            public void Advance()
            {
                X += Vx;
                Y += Vy;
            }

            public void Reverse()
            {
                X -= Vx;
                Y -= Vy;
            }
        }

        public List<Point> Points { get; set; }

        public void Advance()
        {
            foreach (var point in Points)
            {
                point.Advance();
            }
        }

        public void Reverse()
        {
            foreach (var point in Points)
            {
                point.Reverse();
            }
        }

        public string Map()
        {
            (int minX, int maxX, int minY, int maxY) = BoundingBox();
            var pointsDict = Points.GroupBy(p => (p.X, p.Y)).ToDictionary(g => g.Key);
            var sb = new StringBuilder();
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    if (pointsDict.TryGetValue((x, y), out var ignored))
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }

                if (y != maxY)
                {
                    sb.Append("\r\n");
                }
            }
            return sb.ToString();
        }

        public (int minX, int maxX, int minY, int maxY) BoundingBox()
        {
            var xs = Points.Select(p => p.X).ToArray();
            var ys = Points.Select(p => p.Y).ToArray();
            int minX = xs.Min();
            int maxX = xs.Max();
            int minY = ys.Min();
            int maxY = ys.Max();
            return (minX, maxX, minY, maxY);
        }

        public string SolvePart1(IEnumerable<string> inputs)
        {
            Points = Parse(inputs);
            (int minX, int maxX, int minY, int maxY) lastBox;
            var currentBox = BoundingBox();
            do
            {
                lastBox = currentBox;
                Advance();
                currentBox = BoundingBox();
            } while (currentBox.maxX - currentBox.minX < lastBox.maxX - lastBox.minX || currentBox.maxY - currentBox.minY < lastBox.maxY - lastBox.minY);
            Reverse();
            return Map();
        }
        
        public int SolvePart2(IEnumerable<string> inputs)
        {
            Points = Parse(inputs);
            int iterations = 0;
            (int minX, int maxX, int minY, int maxY) lastBox;
            var currentBox = BoundingBox();
            do
            {
                lastBox = currentBox;
                Advance();
                currentBox = BoundingBox();
                iterations++;
            } while (currentBox.maxX - currentBox.minX < lastBox.maxX - lastBox.minX || currentBox.maxY - currentBox.minY < lastBox.maxY - lastBox.minY);
            Reverse();
            iterations--;
            return iterations;
        }

        private int BoundingBoxSize()
        {
            var box = BoundingBox();
            return box.maxX - box.minX * box.maxY - box.minY;
        }
    }
}