using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Sorting.ExchangeSorts.Tests
{
    [TestClass()]
    public class OddEvenSortTests
    {
        // TODO: All the Sorting Algorithm Tests are the same, look into using a parameter to pass the sorting Algorithm to use
        [TestMethod()]
        public void OddEvenSortTest()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            OddEvenSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "CocktailSort did not sort correctly");
        }

        [TestMethod()]
        public void OddEvenSort_List_Test()
        {
            var actual = new List<double> { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            var expected = new List<double> { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            OddEvenSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "CocktailSort<T> did not sort correctly");
        }

        [TestMethod()]
        public void OddEvenSort_String_Test()
        {
            var actual = new List<string> { "cccc", "abcd", "bbbb", "dddd", "bb12", "DDDD", "eEeE", "1234" };
            var expected = new List<string> { "1234", "abcd", "bb12", "bbbb", "cccc", "dddd", "DDDD", "eEeE" };
            OddEvenSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "CocktailSort<T> did not sort correctly");
        }

        [TestMethod()]
        public void OddEvenSort_CustomComparer_Test()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { 12, 10, 7, 6, 5, 5, 4, 2, 1, 0, -4, -24 };
            Comparison<int> descending = ((x, y) => y > x ? 1 : y < x ? -1 : 0);
            OddEvenSort.Sort(actual, Comparer<int>.Create(descending));

            CollectionAssert.AreEqual(expected, actual, "CocktailSort<T> did not sort descending");
        }
    }
}
