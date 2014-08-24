using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Sorting.ExchangeSorts.Tests
{
    [TestClass()]
    public class BogoSortTests
    {
        [TestMethod()]
        public void BogoSort_SingleElement_Test()
        {
            // One element list, is always considered Sorted
            int[] actual = new int[] { 12 };
            int[] expected = new int[] { 12 };
            BogoSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "BogoSort did not sort correctly");
        }

        [TestMethod()]
        public void BogoSortTest()
        {
            // 2 Element maximum otherwise this could take very long
            int[] actual = new int[] { 2, 1 };
            int[] expected = new int[] { 1, 2 };
            BogoSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual, "BogoSort did not sort correctly");
        }

    }
}
