using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Sorting.ExchangeSorts.Tests
{
    [TestClass()]
    public class QuickSort3WayTests
    {
        [TestMethod()]
        public void QuickSort3WayTest()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            QuickSort3Way.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "QuickSort3Way did not sort correctly");
        }

        [TestMethod()]
        public void QuickSort3Way_CustomComparer_Test()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { 12, 10, 7, 6, 5, 5, 4, 2, 1, 0, -4, -24 };
            Comparison<int> descending = ((x, y) => y > x ? 1 : y < x ? -1 : 0);
            QuickSort3Way.Sort(actual, Comparer<int>.Create(descending));

            CollectionAssert.AreEqual(expected, actual, "QuickSort3Way<T> did not sort descending");
        }
    }
}
