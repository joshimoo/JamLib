using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamLib.Algorithms.Sorting.SelectionSorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace JamLib.Algorithms.Sorting.SelectionSorts.Tests
{
    [TestClass()]
    public class HeapSortTests
    {
        [TestMethod()]
        public void HeapSortTest()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            HeapSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "HeapSort did not sort correctly");
        }

        [TestMethod()]
        public void HeapSort_Generic_Test()
        {
            float[] actual = new float[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            float[] expected = new float[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            HeapSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "HeapSort<T> did not sort correctly");
        }

        [TestMethod()]
        public void HeapSort_List_Test()
        {
            var actual = new List<double> { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            var expected = new List<double> { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            HeapSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "HeapSort<T> did not sort correctly");
        }

        [TestMethod()]
        public void HeapSort_CustomComparer_Test()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { 12, 10, 7, 6, 5, 5, 4, 2, 1, 0, -4, -24 };
            Comparison<int> descending = ((x, y) => y > x ? 1 : y < x ? -1 : 0);
            HeapSort.Sort(actual, Comparer<int>.Create(descending));

            CollectionAssert.AreEqual(expected, actual, "HeapSort<T> did not sort descending");
        }
    }
}
