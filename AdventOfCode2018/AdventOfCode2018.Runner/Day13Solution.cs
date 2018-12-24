using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Runner
{
    // This is so ugly. Not sure why I thought of things this way. 
    public class Day13Solution
    {
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<char[]> Map { get; set; }

        public string SolvePart1(string input, IProgress<string> progress = null)
        {
            Parse(input);
            while (true)
            {
                foreach (var cart in Carts.OrderBy(c => c.Y).ThenBy(c => c.X))
                {
                    var next = cart.GetNextLocation();
                    var crashedCart = Carts.FirstOrDefault(c => c.X == next.x && c.Y == next.y);
                    if (crashedCart != null)
                    {
                        return next.ToString();
                    }
                    
                    char track = LookAhead(cart);
                    switch (cart.Direction)
                    {
                        case Direction.Up:
                            cart.Y--;
                            switch (track)
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
                            switch (track)
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
                            switch (track)
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
                            switch (track)
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
        }
        
        
        public string SolvePart2(string input, IProgress<string> progress = null)
        {
            Parse(input);
            while (true)
            {
                if (Carts.Count(c => !c.Crashed) == 1)
                {
                    var cart = Carts.First(c => !c.Crashed);
                    return (cart.X, cart.Y).ToString();
                }
                
                foreach (var cart in Carts.OrderBy(c => c.Y).ThenBy(c => c.X))
                {
                    if (cart.Crashed)
                    {
                        continue;
                    }
                    
                    var next = cart.GetNextLocation();
                    var otherCart = Carts.FirstOrDefault(c => !c.Crashed && c.X == next.x && c.Y == next.y);
                    if (otherCart != null)
                    {
                        cart.Crashed = true;
                        otherCart.Crashed = true;
                    }
                    
                    char track = LookAhead(cart);
                    switch (cart.Direction)
                    {
                        case Direction.Up:
                            cart.Y--;
                            switch (track)
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
                            switch (track)
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
                            switch (track)
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
                            switch (track)
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
                            cart.Direction = Direction.Up;
                            break;
                        case Direction.Right:
                            cart.Direction = Direction.Down;
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
        public bool Crashed { get; set; }
        

        public (int x, int y) GetNextLocation()
        {
            switch (Direction)
            {
                case Direction.Up:
                    return (X, Y - 1);
                case Direction.Down:
                    return (X, Y + 1);
                case Direction.Left:
                    return (X - 1, Y);
                case Direction.Right:
                    return (X + 1, Y);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
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