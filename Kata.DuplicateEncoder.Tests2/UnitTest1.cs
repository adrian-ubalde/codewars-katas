using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kata.DuplicateEncoder.Tests2
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("a", "(")]
        [InlineData("aa", "))")]
        [InlineData("Aa", "))")]
        [InlineData("abb", "())")]
        [InlineData("122", "())")]
        [InlineData("*))", "())")]
        [InlineData("  ", "))")]
        [InlineData("", "")]
        public void ReturnsEncodedString(string word, string expectedResult)
        {
            Assert.Equal(expectedResult, Kata.DuplicateEncode(word));
        }
    }

    public class Kata
    {
        public static string DuplicateEncode(string word)
        {
            var wordInLowercase = word.ToLowerInvariant();

            var seenCharacterCount = new Dictionary<char, int>();
            foreach(var character in wordInLowercase)
            {
                if (seenCharacterCount.ContainsKey(character))
                    seenCharacterCount[character]++;
                else
                    seenCharacterCount[character] = 1;
            }

            var resultStringBuilder = new StringBuilder();
            foreach (var character in wordInLowercase)
            {
                if (seenCharacterCount[character] > 1)
                    resultStringBuilder.Append(")");
                else
                    resultStringBuilder.Append("(");
            }

            return resultStringBuilder.ToString();
        }
    }
}
