using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JamLib.Algorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Sorting.Tests
{
    [TestClass()]
    public class InsertionSortsTests
    {
        [TestMethod()]
        public void InsertionSortTest()
        {
            // NOTE: Using InsertionSort() directly instead of as an extension method since, it's more expressive.
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            InsertionSorts.InsertionSort(actual);

            CollectionAssert.AreEqual(expected, actual, "InsertionSort did not sort correctly");
            // CollectionAssert.AreEqual
            // Enumerable.SequenceEqual 
        }

        [TestMethod()]
        public void InsertionSort_List_Test()
        {
            var actual = new List<double> { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            var expected = new List<double> { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            InsertionSorts.InsertionSort(actual);

            CollectionAssert.AreEqual(expected, actual, "InsertionSort<T> did not sort correctly");
        }

        [TestMethod()]
        public void InsertionSort_Interval_Test()
        {
            // TODO: Add Negative Numbers as well as twice the same number to the testcases
            int[] actual = new int[] { 62, 83, 18, 53, 7, 17, 95, 86, 47, 69, 25, 28 };
            int[] interval5 = new int[] { 17, 28, 18, 47, 7, 25, 83, 86, 53, 69, 62, 95 };
            int[] interval3 = new int[] { 17, 7, 18, 47, 28, 25, 69, 62, 53, 83, 86, 95 };
            int[] interval1 = new int[] { 7, 17, 18, 25, 28, 47, 53, 62, 69, 83, 86, 95 };

            InsertionSorts.InsertionSort(actual, 5);
            CollectionAssert.AreEqual(interval5, actual, "InsertionSort with Interval 5 did not sort correctly");

            InsertionSorts.InsertionSort(actual, 3);
            CollectionAssert.AreEqual(interval3, actual, "InsertionSort with Interval 3 did not sort correctly");

            InsertionSorts.InsertionSort(actual, 1);
            CollectionAssert.AreEqual(interval1, actual, "InsertionSort with Interval 1 did not sort correctly");
        }

        [TestMethod()]
        public void ShellSortTest()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            InsertionSorts.ShellSort(actual);

            CollectionAssert.AreEqual(expected, actual, "ShellSort did not sort correctly");
        }

        [TestMethod()]
        public void ShellSort_List_Test()
        {
            var actual = new List<double> { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            var expected = new List<double> { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            InsertionSorts.ShellSort(actual);

            CollectionAssert.AreEqual(expected, actual, "ShellSort<T> did not sort correctly");
        }
    }
}
