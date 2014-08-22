using Microsoft.VisualStudio.TestTools.UnitTesting;
using JamLib.DataStructures.Lists;

namespace JamLib.DataStructures.Lists.Tests
{
    [TestClass()]
    public class IndexedLinkedListTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1 };
            Assert.AreEqual(3, list.Count, "Did not add the items");
            list.Add(1);
            Assert.AreEqual(4, list.Count, "Did not add the item");
        }

        [TestMethod()]
        public void IndexerTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1 };
            int expected = 1;
            int actual = list[0];
            Assert.AreEqual(expected, actual, "Indexer does not work correctly");
        }

        [TestMethod()]
        public void Indexer_SingleElementList_Test()
        {
            var list = new IndexedLinkedList<int> { 1 };
            int expected = 1;
            int actual = list[0];
            Assert.AreEqual(expected, actual, "Indexer does not work correctly");
        }

        [TestMethod()]
        public void Indexer_SetElement_Test()
        {
            var list = new IndexedLinkedList<int> { 1, 2, 3 };
            int expected = 5;
            list[2] = 5;
            int actual = list[2];
            Assert.AreEqual(expected, actual, "Indexer does not work correctly");
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1 };
            list.Remove(0);
            Assert.AreEqual(2, list.Count, "Remove failed, size does not match expected");

            // Dump as array
            var expected = new int[] { 1, -1 };
            var actual = new int[list.Count];
            list.CopyTo(actual, 0);

            CollectionAssert.AreEqual(expected, actual, "Remove failed, The list does not match expected");
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1 };
            list.RemoveAt(1);
            Assert.AreEqual(2, list.Count, "Remove failed, size does not match expected");

            // Dump as array
            var expected = new int[] { 1, -1 };
            var actual = new int[list.Count];
            list.CopyTo(actual, 0);

            CollectionAssert.AreEqual(expected, actual, "Remove failed, The list does not match expected");
        }

        [TestMethod()]
        public void ClearTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1 };
            list.Clear();
            Assert.AreEqual(0, list.Count, "clearing the list failed");
        }

        [TestMethod()]
        public void InsertTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1 };
            list.Insert(1, 22);
            Assert.AreEqual(4, list.Count, "InsertAt failed, size does not match expected");

            // Dump as array
            var expected = new int[] { 1, 22, 0, -1 };
            var actual = new int[list.Count];
            list.CopyTo(actual, 0);

            CollectionAssert.AreEqual(expected, actual, "InsertAt failed, The list does not match expected");
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1 };
            int expected = 1;
            int actual = list.IndexOf(0);
            Assert.AreEqual(expected, actual, "IndexOf did not return the correct index");
        }

        [TestMethod()]
        public void ContainsTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1 };
            Assert.IsTrue(list.Contains(0), "The list does not contain the item");
        }

        [TestMethod()]
        public void FindTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1 };
            Assert.IsNotNull(list.Find(0), "The list does not contain the item");
        }

        [TestMethod()]
        public void CopyToTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1 };
            var expected = new int[] { 1, 0, -1 };
            var actual = new int[list.Count];
            list.CopyTo(actual, 0);

            CollectionAssert.AreEqual(expected, actual, "The arrays do not match");
        }

        [TestMethod()]
        public void GetYieldBasedEnumeratorTest()
        {
            var list = new IndexedLinkedList<int> { 1, 0, -1, 44, 22, 22, 11, 2, 3, 4, 5 };
            var expected = new int[] { 1, 0, -1, 44, 22, 22, 11, 2, 3, 4, 5 };
            var actual = new System.Collections.Generic.List<int>();
            foreach (var item in list) { actual.Add(item); }

            CollectionAssert.AreEqual(expected, actual, "The collections do not match");
        }
    }
}
