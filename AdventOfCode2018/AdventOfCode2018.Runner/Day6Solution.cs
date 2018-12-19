using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Runner
{
    public class Day6Solution
    {
        public int gridSize = 400;

        public int SolvePart1(IEnumerable<string> inputs)
        {
            var coords = Parse(inputs);
            var grid = CreateGridWithCoordinates(gridSize, coords);
            return DetermineLargestNonInfiniteArea(grid, gridSize, coords.Count);
        }

        public int SolvePart2(IEnumerable<string> inputs)
        {
            var coords = Parse(inputs);
            var grid = CreateSafeGrid(gridSize, 10000, coords);
            return (from bool val in grid select val).Count(b => b);
        }
        
        public List<Coordinate> Parse(IEnumerable<string> inputs)
        {
            var coordinates = new List<Coordinate>();
            int id = 1;
            foreach (var input in inputs)
            {
                var parts = input.Split(", ");
                coordinates.Add(new Coordinate(id, int.Parse(parts[0]), int.Parse(parts[1])));
                id++;
            }

            return coordinates;
        }

        public class Coordinate
        {
            public int Id { get; }
            public int X { get; }
            public int Y { get; }

            public Coordinate(int id, int x, int y)
            {
                Id = id;
                X = x;
                Y = y;
            }
        }

        public int[,] CreateGridWithCoordinates(int gridSize, List<Coordinate> coordinates)
        {
            int[,] grid = new int[gridSize, gridSize];
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    grid[y, x] = ClosestCoordinate(x, y, coordinates);
                }
            }
            return grid;
        }

        private int ClosestCoordinate(int x, int y, List<Coordinate> coordinates)
        {
            bool tie = false;
            int closestId = 0;
            int smallestDistance = 1001;
            foreach (var coordinate in coordinates)
            {
                var distance = Distance(x, y, coordinate.X, coordinate.Y);
                if (distance < smallestDistance)
                {
                    closestId = coordinate.Id;
                    smallestDistance = distance;
                    tie = false;
                }
                else if (distance == smallestDistance)
                {
                    tie = true;
                }
            }

            return tie ? 0 : closestId;
        }

        private int Distance(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        public int DetermineLargestNonInfiniteArea(int[,] grid, int gridSize, int numberOfCoordinates)
        {
            int[] counts = new int[numberOfCoordinates + 1];
            var coordsToIgnore = DetermineIgnorableCoordinates(grid, gridSize);
            for (int y = 1; y < gridSize-1; y++)
            {
                for (int x = 1; x < gridSize-1; x++)
                {
                    counts[grid[y, x]] += 1;
                }
            }

            return counts.Where((_, id) => !coordsToIgnore.Contains(id)).Max();
        }

        private static HashSet<int> DetermineIgnorableCoordinates(int[,] grid, int gridSize)
        {
            HashSet<int> coordsToIgnore = new HashSet<int>();
            coordsToIgnore.Add(0);
            for (int x = 0; x < gridSize; x++)
            {
                var coordId = grid[0, x];
                if (!coordsToIgnore.Contains(coordId))
                {
                    coordsToIgnore.Add(coordId);
                }
            }

            for (int x = 0; x < gridSize; x++)
            {
                var coordId = grid[gridSize - 1, x];
                if (!coordsToIgnore.Contains(coordId))
                {
                    coordsToIgnore.Add(coordId);
                }
            }

            for (int y = 1; y < gridSize - 1; y++)
            {
                var coordId = grid[y, 0];
                if (!coordsToIgnore.Contains(coordId))
                {
                    coordsToIgnore.Add(coordId);
                }

                coordId = grid[y, gridSize - 1];
                if (!coordsToIgnore.Contains(coordId))
                {
                    coordsToIgnore.Add(coordId);
                }
            }

            return coordsToIgnore;
        }

        public bool[,] CreateSafeGrid(int gridSize, int safeDistance, List<Coordinate> coordinates)
        {
            bool[,] grid = new bool[gridSize, gridSize];
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    grid[y, x] = IsCoordinateSafe(x, y, coordinates, safeDistance);
                }
            }
            return grid;
        }

        private bool IsCoordinateSafe(int x, int y, List<Coordinate> coordinates, int safeDistance)
        {
            return coordinates.Sum(c => Distance(x, y, c.X, c.Y)) < safeDistance;
        }
    }
}