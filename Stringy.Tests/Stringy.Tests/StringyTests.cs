using System;
using Xunit;

namespace Stringy.Tests
{
    public class StringyTests
    {
        [Fact]
        public void WhenSizeIsOne_ReturnsOne()
        {
            Assert.Equal("1", Kata.Stringy(1));
        }

        [Fact]
        public void ReturnsAlternatingOnesAndZeros()
        {
            Assert.Equal("10", Kata.Stringy(2));
            Assert.Equal("1010", Kata.Stringy(4));
            Assert.Equal("101010", Kata.Stringy(6));
            Assert.Equal("101010101010", Kata.Stringy(12));
        }

        [Fact]
        public void WhenSizeIsNegative_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Kata.Stringy(-1));
        }

        [Fact]
        public void WhenSizeIsZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Kata.Stringy(0));
        }
    }
}
