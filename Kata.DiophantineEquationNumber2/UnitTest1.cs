using Xunit;
using System;

namespace Kata.DiophantineEquationNumber2
{
    // https://www.codewars.com/kata/57877d09ba5c4b0574000146

    public class DEquations
    {
        private static bool IsMatchingPair(int x, int y, ulong n)
        {
            var sum = Math.Pow(x, 2) + Math.Pow(y, 3);
            return sum == n;
        }

        public static int Solve (ulong n)
        {
            var matchingPairCount = 0;
            var largestY = (int)Math.Floor(Math.Cbrt(n));

            for (var y = largestY; y >= 0; y--)
            {
                for (var x = y - 1; x >= 0; x--)
                {
                    Console.WriteLine($"({x}, {y})");
                    if (IsMatchingPair(x, y, n))
                    {
                        matchingPairCount++;
                        Console.WriteLine($"Matched");
                        break;
                    }
                }
            }

            var largestX = (int)Math.Floor(Math.Sqrt(n));

            for (var x = largestX; x > largestY; x--)
            {
                for (var y = largestY; y >= 0; y--)
                {
                    Console.WriteLine($"({x}, {y})");
                    if (IsMatchingPair(x, y, n)) 
                    {
                        matchingPairCount++;
                        Console.WriteLine($"Matched");
                        break;
                    }
                }                
            }

            return matchingPairCount;
        }
    }

    public class UnitTest1
    {
        [Theory]
        [InlineData (9, 2)]
        [InlineData(27, 1)]
        [InlineData(10000000000000000000, 1)]
        [InlineData(0, 0)]
        public void ReturnsTotalNumberOfNumberPairs (ulong n, int expectedResult)
        {
            Console.WriteLine($"n == {n}");
            Assert.Equal (expectedResult, DEquations.Solve (n));
        }
    }
}