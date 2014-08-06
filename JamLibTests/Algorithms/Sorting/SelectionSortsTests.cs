using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JamLib.Algorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Sorting.Tests
{
    [TestClass()]
    public class SelectionSortsTests
    {
        [TestMethod()]
        public void SelectionSortTest()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 6, 10, 12 };
            int[] result = SelectionSorts.SelectionSort(actual);

            CollectionAssert.AreEqual(expected, result, "SelectionSort did not sort correctly");
        }
    }
}
