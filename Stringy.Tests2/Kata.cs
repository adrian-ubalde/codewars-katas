using System;
using System.Collections.Generic;
using System.Text;

namespace Stringy.Tests2
{
    public class Kata
    {
        public static string Stringy(int size)
        {
            var resultBuilder = new StringBuilder();
            for (var position = 1; position <= size; position++)
            {
                resultBuilder.Append((position % 2 == 0) ? '0' : '1');
            }

            return resultBuilder.ToString();
        }
    }
}
