using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Searching.Tests
{
    [TestClass()]
    public class LinearSearchTests
    {
        [TestMethod()]
        public void LinearSearchTest()
        {
            var data = new int[] { -1, 0, 1, 4, 5, 7, 88, 90, 111, 160, 250 };
            int actualIndex = LinearSearch.Search(data, 90);
            int expectedIndex = 7;

            Assert.AreEqual(expectedIndex, actualIndex, "Linear search did not provide the correct index");
        }

        [TestMethod()]
        public void LinearSearchReverseTest()
        {
            var data = new int[] { -1, 0, 1, 4, 5, 7, 88, 90, 111, 160, 250 };
            int actualIndex = LinearSearch.ReverseSearch(data, 90);
            int expectedIndex = 7;

            Assert.AreEqual(expectedIndex, actualIndex, "Reverse Linear search did not provide the correct index");
        }

        [TestMethod()]
        public void LinearSearch_CustomComparer_Test()
        {
            // Replaced this example with one that uses StringComparer: http://msdn.microsoft.com/en-us/library/system.stringcomparer%28v=vs.110%29.aspx
            var data = new string[] { "abc", "notme", "FiNdMe", "last", "or", "not" };
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            int actualIndex = LinearSearch.Search(data, "findme", comparer);
            int expectedIndex = 2;

            Assert.AreEqual(expectedIndex, actualIndex, "Linear search did not provide the correct index with a custom comparer");
        }

    }
}
