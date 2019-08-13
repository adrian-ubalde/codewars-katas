using System;
using System.Collections.Generic;
using Xunit;

namespace Kata.GarbleSort
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 })]
        [InlineData(new int[] { 5, 6, 3 }, new int[] { 6, 3, 5 })]
        [InlineData(new int[0], new int[0])]
        [InlineData(null, null)]
        public void Test1(int[] numbersToSort, int[] expectedResult)
        {
            Assert.Equal(expectedResult, Kata.GarbleSort(numbersToSort));
        }
    }

    public class Kata
    {
        public static int[] GarbleSort(int[] numbersToSort)
        {
            var newOrderMap = new int[9] { 7, 9, 6, 4, 1, 3, 5, 8, 2 };

            for (var i = 0; i < numbersToSort.Length; i++)
                numbersToSort[i] = Array.IndexOf(newOrderMap, numbersToSort[i]);

            Array.Sort(numbersToSort);

            for (var i = 0; i < numbersToSort.Length; i++)
                numbersToSort[i] = newOrderMap[numbersToSort[i]];

            return numbersToSort;
        }
    }
}
