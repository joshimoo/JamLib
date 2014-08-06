using System;
using System.Collections.Generic;
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
            int[] actual = new int[] { 12, 10, 4, 5, 0, 6, 2, 1, -4, -24 };
            int[] expected = new int[] { -24, -4, 0, 1, 2, 4, 5, 6, 10, 12 };
            int[] result = ExchangeSorts.BubbleSort(actual);

            CollectionAssert.AreEqual(expected, result, "BubbleSort did not sort correctly");
        }
    }
}
