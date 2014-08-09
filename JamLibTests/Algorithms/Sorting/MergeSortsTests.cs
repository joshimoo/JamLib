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
    public class MergeSortsTests
    {
        [TestMethod()]
        public void MergeSortTest()
        {
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24, 7, 5 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 5, 6, 7, 10, 12 };
            MergeSorts.MergeSort(actual);

            CollectionAssert.AreEqual(expected, actual, "MergeSort did not sort correctly");
        }
    }
}
