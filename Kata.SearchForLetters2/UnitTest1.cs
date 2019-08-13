using System;
using System.Linq;
using Xunit;

namespace Kata.Change.Specifications
{
    public class NonLetterSpecifications
    {
        [Theory]
        [InlineData("1", "00000000000000000000000000")]
        public void IgnoresNumbers(string input, string expectedResult)
        {
            Assert.Equal(expectedResult, Kata.Change(input));
        }

        [Theory]
        [InlineData("*", "00000000000000000000000000")]
        [InlineData("$", "00000000000000000000000000")]
        public void IgnoresNonLettersAndNumbers(string input, string expectedResult)
        {
            Assert.Equal(expectedResult, Kata.Change(input));
        }

        [Fact]
        public void WhenEmptyString_ReturnsAllZeros()
        {
            Assert.Equal("00000000000000000000000000", Kata.Change(""));
        }
    }

    public class LetterSpecifications
    {
        [Theory]
        [InlineData("a", "10000000000000000000000000")]
        public void ForLowerCaseLetter_ReturnsOne(string input, string expectedResult)
        {
            Assert.Equal(expectedResult, Kata.Change(input));
        }


        [Theory]
        [InlineData("A", "10000000000000000000000000")]
        public void ForUpperCaseLetter_ReturnsOne(string input, string expectedResult)
        {
            Assert.Equal(expectedResult, Kata.Change(input));
        }
    }

    public class Kata
    {
        public static string Change(string input)
        {
            var inputAsLowercase = input.ToLowerInvariant();

            return String.Concat(
                Enumerable.Range('a', 26)
                .Select(number => 
                    inputAsLowercase.Contains((char)number) ? '1' : '0'
                )
            );
        }
    }
}
