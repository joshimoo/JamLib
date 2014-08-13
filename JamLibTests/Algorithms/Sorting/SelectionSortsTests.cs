﻿using System.Collections.Generic;
using JamLib.Algorithms.Sorting.SelectionSorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Sorting.Tests
{
    [TestClass()]
    public class SelectionSortsTests
    {
        [TestMethod()]
        public void SelectionSortTest()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            SelectionSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "SelectionSort did not sort correctly");
        }

        [TestMethod()]
        public void SelectionSort_List_Test()
        {
            var actual = new List<double> { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            var expected = new List<double> { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            SelectionSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "BubbleSort<T> did not sort correctly");
        }
    }
}
