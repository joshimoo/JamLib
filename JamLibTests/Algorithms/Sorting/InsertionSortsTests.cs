using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 6, 10, 12 };
            int[] result = InsertionSorts.InsertionSort(actual);

            CollectionAssert.AreEqual(expected, result, "InsertionSort did not sort correctly");
            // CollectionAssert.AreEqual
            // Enumerable.SequenceEqual 
        }

        [TestMethod()]
        public void ShellSortTest()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 6, 10, 12 };
            int[] result = InsertionSorts.ShellSort(actual);

            CollectionAssert.AreEqual(expected, result, "ShellSort did not sort correctly");
        }
    }
}
