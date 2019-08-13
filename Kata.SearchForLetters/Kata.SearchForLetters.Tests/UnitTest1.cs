using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Kata.SearchForLetters.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("a", "10000000000000000000000000")]
        [InlineData("B", "01000000000000000000000000")]
        [InlineData("aB", "11000000000000000000000000")]
        [InlineData("1", "00000000000000000000000000")]
        [InlineData("~", "00000000000000000000000000")]
        [InlineData("a **&  bZ", "11000000000000000000000001")]
        [InlineData("!!a$%&RgTT", "10000010000000000101000000")]
        public void Test1(string input, string expectedResult)
        {
            Assert.Equal(expectedResult, Kata.Change(input));
        }

        [Fact]
        public void Test2()
        {
            var longInput = new StringBuilder();
            for (var i = 0; i < 1000000; i++)
            {
                longInput.Append("a");
            }

            //var longInput = String.Concat(Enumerable.Range('a', 10000).Select(letter => (char)letter));
            //Assert.Equal("11111111111111111111111111", Kata.Change(longInput.ToString()));
            Assert.Equal("10000000000000000000000000", Kata.Change(longInput.ToString()));
        }
    }

    public class Kata
    {
        public static string Change(string input)
        {
            var resultAsChars = new char[26];
            for (var i = 0; i < 26; i++)
            {
                resultAsChars[i] = '0';
            }

            var currentLetter = 'a';
            var letterIndexes = new Dictionary<char, int>(26);
            for (var i = 0; i < 26; i++)
            {
                letterIndexes[currentLetter++] = i;
            }

            foreach (var character in input)
            {
                if (Char.IsLetter(character))
                {
                    var letterIndex = letterIndexes[Char.ToLowerInvariant(character)];
                    resultAsChars[letterIndex] = '1';
                }
            }

            // This has better time-complexity as it's 0(26) i.e. 0(1)
            // instead of 0(n) where n is the number of characters in input.
            // But there are simpler alternatives in Change2, Change3, and Change4
            //var inputInLowerCase = input.ToLowerInvariant();
            //foreach (var entry in letterIndexes)
            //{
            //    resultAsChars[entry.Value] = inputInLowerCase.Contains(entry.Key) ? '1' : '0';
            //}

            var resultStringBuilder = new StringBuilder();
            foreach (var character in resultAsChars)
            {
                resultStringBuilder.Append(character);
            }
            return resultStringBuilder.ToString();
        }

        public static string Change2(string input) =>
            string.Concat("abcdefghijklmnopqrstuvwxyz".Select(c => input.ToLower().Contains(c) ? '1' : '0'));

        public static string Change3(string input) =>
            string.Join("", Enumerable.Range('a', 26).Select(x => input.ToLower().IndexOf((char)x) >= 0 ? 1 : 0));

        public static string Change4(string input) =>
            string.Concat(Enumerable.Range('a', 26).Select(x => input.ToLower().IndexOf((char)x) >= 0 ? 1 : 0));
    }
}
