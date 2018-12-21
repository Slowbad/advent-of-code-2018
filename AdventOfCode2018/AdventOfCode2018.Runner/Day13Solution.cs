using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;

namespace AdventOfCode2018.Runner
{
    public class Day13Solution
    {
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<char[]> Map { get; set; }

        public string SolvePart1(string input, IProgress<string> progress = null)
        {
            Parse(input);
            while (!AnyCrashed())
            {
                Tick();
            }
            
            progress?.Report("What?");
            progress?.Report(RenderMap());

            return Carts
                .GroupBy(c => (c.X, c.Y))
                .OrderByDescending(g => g.Count())
                .First()
                .Key
                .ToString();
        }

        private string RenderMap()
        {
            var otherMap = new List<char[]>();
            foreach (var arr in Map)
            {
                otherMap.Add((char[])arr.Clone());
            }

            foreach (var group in Carts.GroupBy(c => (c.X, c.Y)))
            {
                if(group.Count() > 1)
                {
                    otherMap[group.Key.Item2][group.Key.Item1] = 'X';
                }
                else
                {
                    otherMap[group.Key.Item2][group.Key.Item1] = CartToSymbol(group.First());
                }
            }

            return string.Join("\n", otherMap.Select(arr => string.Join("", arr)));
        }

        private char CartToSymbol(Cart cart)
        {
            switch (cart.Direction)
            {
                case Direction.Up:
                    return '^';
                case Direction.Down:
                    return 'v';
                case Direction.Left:
                    return '<';
                case Direction.Right:
                    return '>';
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool AnyCrashed()
        {
            return Carts.GroupBy(c => (c.X, c.Y)).Any(g => g.Count() > 1);
        }

        public void Parse(string input)
        {
            Map = input.Split(new[] {"\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.ToCharArray()).ToList();
            for (int y = 0; y < Map.Count; y++)
            {
                for (int x = 0; x < Map[0].Length; x++)
                {
                    char symbol = Map[y][x];
                    if (new[] {'^', 'v', '<', '>'}.Contains(symbol))
                    {
                        Map[y][x] = CartToLine(symbol);
                        Carts.Add(new Cart
                        {
                            X = x,
                            Y = y,
                            Direction = SymbolToDirection(symbol)
                        });
                    }
                }
            }
        }

        private char CartToLine(char symbol)
        {
            switch (symbol)
            {
                case '^':
                    return '|';
                case 'v':
                    return '|';
                case '<':
                    return '-';
                case '>':
                    return '-';
                default:
                    throw new ArgumentOutOfRangeException(nameof(symbol));
            }
        }

        private Direction SymbolToDirection(char symbol)
        {
            switch (symbol)
            {
                case '^':
                    return Direction.Up;
                case 'v':
                    return Direction.Down;
                case '<':
                    return Direction.Left;
                case '>':
                    return Direction.Right;
            }

            throw new Exception("Invalid Symbol");
        }

        public void Tick()
        {
            foreach (var cart in Carts.OrderBy(c => (c.Y, c.X)))
            {
                char symbol = LookAhead(cart);
                switch (cart.Direction)
                {
                    case Direction.Up:
                        cart.Y--;
                        switch (symbol)
                        {
                            case '\\':
                                cart.Direction = Direction.Left;
                                break;
                            case '/':
                                cart.Direction = Direction.Right;
                                break;
                            case '+':
                                IntersectionTurn(cart);
                                break;
                        }
                        break;
                    case Direction.Down:
                        cart.Y++;
                        switch (symbol)
                        {
                            case '\\':
                                cart.Direction = Direction.Right;
                                break;
                            case '/':
                                cart.Direction = Direction.Left;
                                break;
                            case '+':
                                IntersectionTurn(cart);
                                break;
                        }
                        break;
                    case Direction.Left:
                        cart.X--;
                        switch (symbol)
                        {
                            case '\\':
                                cart.Direction = Direction.Up;
                                break;
                            case '/':
                                cart.Direction = Direction.Down;
                                break;
                            case '+':
                                IntersectionTurn(cart);
                                break;
                        }
                        break;
                    case Direction.Right:
                        cart.X++;
                        switch (symbol)
                        {
                            case '\\':
                                cart.Direction = Direction.Down;
                                break;
                            case '/':
                                cart.Direction = Direction.Up;
                                break;
                            case '+':
                                IntersectionTurn(cart);
                                break;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void IntersectionTurn(Cart cart)
        {
            switch (cart.NextTurn)
            {
                case NextTurn.Left:
                    cart.NextTurn = NextTurn.Straight;
                    switch (cart.Direction)
                    {
                        case Direction.Up:
                            cart.Direction = Direction.Left;
                            break;
                        case Direction.Down:
                            cart.Direction = Direction.Right;
                            break;
                        case Direction.Left:
                            cart.Direction = Direction.Down;
                            break;
                        case Direction.Right:
                            cart.Direction = Direction.Up;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case NextTurn.Straight:
                    cart.NextTurn = NextTurn.Right;
                    break;
                case NextTurn.Right:
                    cart.NextTurn = NextTurn.Left;
                    switch (cart.Direction)
                    {
                        case Direction.Up:
                            cart.Direction = Direction.Right;
                            break;
                        case Direction.Down:
                            cart.Direction = Direction.Left;
                            break;
                        case Direction.Left:
                            cart.Direction = Direction.Down;
                            break;
                        case Direction.Right:
                            cart.Direction = Direction.Up;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private char LookAhead(Cart cart)
        {
            switch (cart.Direction)
            {
                case Direction.Up:
                    return Map[cart.Y - 1][cart.X];
                case Direction.Down:
                    return Map[cart.Y + 1][cart.X];
                case Direction.Left:
                    return Map[cart.Y][cart.X - 1];
                case Direction.Right:
                    return Map[cart.Y][cart.X + 1];
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class Cart
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public NextTurn NextTurn { get; set; }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum NextTurn
    {
        Left,
        Straight,
        Right
    }
}