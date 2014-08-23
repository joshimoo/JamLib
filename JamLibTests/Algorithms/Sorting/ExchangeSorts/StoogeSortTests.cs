using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Sorting.ExchangeSorts.Tests
{
    [TestClass()]
    public class StoogeSortTests
    {
        [TestMethod()]
        public void StoogeSortTest()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            StoogeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "StoogeSort did not sort correctly");
        }

        [TestMethod()]
        public void StoogeSort_Generic_Test()
        {
            float[] actual = new float[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            float[] expected = new float[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            StoogeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "StoogeSort<T> did not sort correctly");
        }

        [TestMethod()]
        public void StoogeSort_List_Test()
        {
            var actual = new List<double> { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            var expected = new List<double> { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            StoogeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "StoogeSort<T> did not sort correctly");
        }

        [TestMethod()]
        public void StoogeSort_CustomComparer_Test()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { 12, 10, 7, 6, 5, 5, 4, 2, 1, 0, -4, -24 };
            Comparison<int> descending = ((x, y) => y > x ? 1 : y < x ? -1 : 0);
            StoogeSort.Sort(actual, Comparer<int>.Create(descending));

            CollectionAssert.AreEqual(expected, actual, "StoogeSort<T> did not sort descending");
        }
    }
}
