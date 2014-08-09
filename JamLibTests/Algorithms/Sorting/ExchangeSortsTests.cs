using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using JamLib.Algorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Sorting.Tests
{
    [TestClass()]
    public class ExchangeSortsTests
    {
        [TestMethod()]
        public void BubbleSortTest()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            ExchangeSorts.BubbleSort(actual);

            CollectionAssert.AreEqual(expected, actual, "BubbleSort did not sort correctly");
        }

        [TestMethod()]
        public void BubbleSort_Generic_Test()
        {
            float[] actual = new float[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            float[] expected = new float[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            ExchangeSorts.BubbleSort(actual);

            CollectionAssert.AreEqual(expected, actual, "BubbleSort<T> did not sort correctly");
        }

        [TestMethod()]
        public void BubbleSort_List_Test()
        {
            var actual = new List<double> { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            var expected = new List<double> { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            ExchangeSorts.BubbleSort(actual);

            CollectionAssert.AreEqual(expected, actual, "BubbleSort<T> did not sort correctly");
        }
    }
}
