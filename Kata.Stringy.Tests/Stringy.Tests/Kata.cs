using System;
using System.Text;

namespace Stringy.Tests
{
    public class Kata
    {
        public static string Stringy(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "must be positive");
            }

            var stringBuilder = new StringBuilder();

            for (var i = 1; i <= size; i++)
            {
                var isEven = i % 2 == 0;
                var nextCharacter = isEven ? "0" : "1";
                stringBuilder.Append(nextCharacter);
            }

            return stringBuilder.ToString();
        }
    }
}