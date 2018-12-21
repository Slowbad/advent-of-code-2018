using System.Linq;

namespace AdventOfCode2018.Runner
{
    public class Day11Solution
    {
        public int PowerLevel(int x, int y, int gridSerialNumber)
        {
            var rackId = x + 10;
            int i = rackId * y;
            i += gridSerialNumber;
            i *= rackId;
            i /= 100;
            i = i % 10;
            return i - 5;
        }

        public (int, int) SolvePart1(int serialNumber)
        {
            int[,] grid = new int[300,300];
            for (int x = 1; x <= 300; x++)
            {
                for (int y = 1; y <= 300; y++)
                {
                    grid[x-1, y-1] = PowerLevel(x, y, serialNumber);
                }
            }

            int highestTotalPower = -10;
            (int, int) highestPowerCoord = (-1, -1);
            for (int x = 1; x <= 300-2; x++)
            {
                for (int y = 1; y <= 300-2; y++)
                {
                    int totalPower = grid[x - 1, y - 1] + grid[x    , y - 1] + grid[x + 1, y - 1] +
                                     grid[x - 1, y    ] + grid[x    , y    ] + grid[x + 1, y    ] +
                                     grid[x - 1, y + 1] + grid[x    , y + 1] + grid[x + 1, y + 1];
                    if (totalPower > highestTotalPower)
                    {
                        highestTotalPower = totalPower;
                        highestPowerCoord = (x, y);
                    }
                }
            }

            return highestPowerCoord;
        }

        public (int, int, int) SolvePart2(int serialNumber)
        {
            int[,] grid = new int[301,301];
            for (int y = 1; y <= 300; y++)
            {
                for (int x = 1; x <= 300; x++)
                    {
                    int power = PowerLevel(x, y, serialNumber);
                    grid[y, x] = power + grid[y - 1, x] + grid[y, x - 1] - grid[y - 1, x - 1];
                }
            }

            int highestTotalPower = int.MinValue;
            (int, int, int) highestPowerCoord = (-1, -1, -1);
            for (int size = 1; size <= 300; size++)
            {
                for (int y = size; y <= 300; y++)
                {
                    for (int x = size; x <= 300; x++)
                    {
                        var a = grid[y - size, x - size];
                        var b = grid[y - size, x];
                        var c = grid[y, x - size];
                        var d = grid[y, x];
                        var total = d - b - c + a;
                        if (total > highestTotalPower)
                        {
                            highestTotalPower = total;
                            highestPowerCoord = (x - size + 1, y - size + 1, size);
                        }
                    }
                }
            }

            return highestPowerCoord;
        }
    }
}