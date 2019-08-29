using System;
using Xunit;

namespace Solution.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "Odd")]
        [InlineData(2, "Even")]
        [InlineData(-1, "Odd")]
        [InlineData(-2, "Even")]
        public void ReturnsOddOrEven(int number, string expectedResult)
        {
            Assert.Equal(expectedResult, SolutionClass.EvenOrOdd(number));
        }

    }
}
