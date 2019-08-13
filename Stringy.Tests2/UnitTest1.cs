using System;
using Xunit;

namespace Stringy.Tests2
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "10")]
        [InlineData(10, "1010101010")]
        public void Test1(int size, string expectedResult)
        {
            Assert.Equal(expectedResult, Kata.Stringy(size));
        }
    }
}
