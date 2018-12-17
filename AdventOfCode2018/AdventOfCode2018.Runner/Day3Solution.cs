using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Runner
{
    public class Day3Solution
    {
        public class Part1
        {
            public int gridSize = 1000;

            public int Solve(IEnumerable<Claim> claims)
            {
                var grid = MakeGrid(claims);

                int count = 0;
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        if (grid[i, j].Count > 1)
                        {
                            count++;
                        }
                    }
                }

                return count;
            }

            public List<int>[,] MakeGrid(IEnumerable<Claim> claims)
            {
                var t = new List<int>[gridSize, gridSize];
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        t[i, j] = new List<int>();
                    }
                }
                foreach (var claim in claims)
                {
                    for (int x = claim.Left; x < claim.Left + claim.Width; x++)
                    {
                        for (int y = claim.Top; y < claim.Top + claim.Height; y++)
                        {
                            t[y, x].Add(claim.Id);
                        }
                    }
                }

                return t;
            }

            public int Solve(IEnumerable<string> inputs)
            {
                var claims = inputs.Select(s =>
                {
                    var parts = s
                        .Split(new[] {"#", " @ ", ",", ": ", "x"}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                    return new Claim()
                    {
                        Id = parts[0],
                        Left = parts[1],
                        Top = parts[2],
                        Width = parts[3],
                        Height = parts[4]
                    };
                });
                return Solve(claims);
            }
        }

        public class Claim
        {
            public int Id { get; set; }
            public int Left { get; set; }
            public int Top { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public class Part2
        {
            public int Solve(IEnumerable<string> inputs)
            {
                var claims = inputs.Select(s =>
                {
                    var parts = s
                        .Split(new[] {"#", " @ ", ",", ": ", "x"}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                    return new Claim()
                    {
                        Id = parts[0],
                        Left = parts[1],
                        Top = parts[2],
                        Width = parts[3],
                        Height = parts[4]
                    };
                });
                return Solve(claims);
            }
            
            public int Solve(IEnumerable<Claim> claims)
            {
                var c = claims.ToList();
                var grid = new Part1().MakeGrid(c);
                for (int x = 0; x < 1000; x++)
                {
                    for (int y = 0; y < 1000; y++)
                    {
                        var ids = grid[y, x];
                        if (ids.Count > 1)
                        {
                            foreach (var id in ids)
                            {
                                c.Remove(c.Find(claim => claim.Id == id));
                            }
                        }
                    }
                }
                return c[0].Id;
            }
        }
    }
}