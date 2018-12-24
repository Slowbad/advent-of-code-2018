using System;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2018.Runner.Tests
{
    public class Day13Tests
    {
        private readonly ITestOutputHelper output;

        public Day13Tests(ITestOutputHelper output)
        {
            this.output = output;
        }
        
//        [Fact]
//        public void ParseMap()
//        {
//            var subject = new Day13Solution();
//
//            subject.Parse(@"/-<--\
//v    |
//|    ^
//\-->-/");
//
//            subject.Carts.Should().BeEquivalentTo(
//                new Cart
//            {
//                X = 2,
//                Y = 0,
//                Direction = Direction.Left,
//                NextTurn = NextTurn.Left
//            },
//                new Cart
//            {
//                X = 0,
//                Y = 1,
//                Direction = Direction.Down,
//                NextTurn = NextTurn.Left
//            },
//                new Cart
//            {
//                X = 5,
//                Y = 2,
//                Direction = Direction.Up,
//                NextTurn = NextTurn.Left
//            },
//                new Cart
//            {
//                X = 3,
//                Y = 3,
//                Direction = Direction.Right,
//                NextTurn = NextTurn.Left
//            });
//        }
//        
//        [Fact]
//        public void Forward()
//        {
//            var subject = new Day13Solution();
//            subject.Parse(@"/-<--\
//v    |
//|    ^
//\-->-/");
//            
//            subject.Tick();
//
//            subject.Carts.Should().BeEquivalentTo(
//                new Cart
//            {
//                X = 1,
//                Y = 0,
//                Direction = Direction.Left,
//                NextTurn = NextTurn.Left
//            },
//                new Cart
//            {
//                X = 0,
//                Y = 2,
//                Direction = Direction.Down,
//                NextTurn = NextTurn.Left
//            },
//                new Cart
//            {
//                X = 5,
//                Y = 1,
//                Direction = Direction.Up,
//                NextTurn = NextTurn.Left
//            },
//                new Cart
//            {
//                X = 4,
//                Y = 3,
//                Direction = Direction.Right,
//                NextTurn = NextTurn.Left
//            });
//        }
//
//        [Fact]
//        public void Corners()
//        {
//            var subject = new Day13Solution();
//            subject.Parse(@"/<---\
//|    ^
//v    |
//\--->/");
//
//            subject.Tick();
//            
//            subject.Carts.Should().BeEquivalentTo(
//                new Cart
//            {
//                X = 0,
//                Y = 0,
//                Direction = Direction.Down,
//                NextTurn = NextTurn.Left
//            },
//                new Cart
//            {
//                X = 5,
//                Y = 0,
//                Direction = Direction.Left,
//                NextTurn = NextTurn.Left
//            },
//                new Cart
//            {
//                X = 0,
//                Y = 3,
//                Direction = Direction.Right,
//                NextTurn = NextTurn.Left
//            },
//                new Cart
//            {
//                X = 5,
//                Y = 3,
//                Direction = Direction.Up,
//                NextTurn = NextTurn.Left
//            });
//        }
//        
//        [Fact]
//        public void Intersection()
//        {
//            var subject = new Day13Solution();
//            subject.Parse(@"/-----\   
//|     |   
//|  /--+<-\
//|  |  |  |
//\--+--/  |
//   |     |
//   \-----/");
//
//            subject.Tick();
//            
//            subject.Carts.Should().BeEquivalentTo(
//                new Cart
//            {
//                X = 6,
//                Y = 2,
//                Direction = Direction.Down,
//                NextTurn = NextTurn.Straight
//            });
//        }

        [Fact]
        public void Solve()
        {
            var subject = new Day13Solution();
            
            var result = subject.SolvePart1(@"/->-\        
|   |  /----\
| /-+--+-\  |
| | |  | v  |
\-+-/  \-+--/
  \------/   ");

            result.Should().Be("(7, 3)");
        }
        
        [Fact]
        public void ShouldWork()
        {
            var subject = new Day13Solution();
            var progress = new Progress<string>(s =>
            {
                output.WriteLine(s);
            });
            
            var result = subject.SolvePart1(@"|
v
|
|
|
^
|
", progress);

            result.Should().Be("(0, 3)");
        }
    }
}

















