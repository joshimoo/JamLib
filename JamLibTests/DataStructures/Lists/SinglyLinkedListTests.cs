using System.Collections.Specialized;
using System.Security.AccessControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JamLib.DataStructures.Lists;

namespace JamLib.DataStructures.Lists.Tests
{
    [TestClass()]
    public class SinglyLinkedListTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var list = new SinglyLinkedList<int> { 1, 0, -1 };
            Assert.AreEqual(3, list.Count, "Did not add the items");
            list.Add(1);
            Assert.AreEqual(4, list.Count, "Did not add the item");
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var list = new SinglyLinkedList<int> { 1, 0, -1, 1 };
            Assert.IsTrue(list.Remove(1));
            Assert.AreEqual(3, list.Count, "Did not remove the item");
        }

        [TestMethod()]
        public void ClearTest()
        {
            var list = new SinglyLinkedList<int> { 1, 0, -1 };
            list.Clear();
            Assert.AreEqual(0, list.Count, "List Size does not match");
        }

        [TestMethod()]
        public void ContainsTest()
        {
            var list = new SinglyLinkedList<int> { 1, 0, -1 };
            Assert.IsTrue(list.Contains(0), "The list does not contain the item");
        }

        [TestMethod()]
        public void FindTest()
        {
            var list = new SinglyLinkedList<int> { 1, 0, -1 };
            Assert.IsNotNull(list.Find(0), "The list does not contain the item");
        }

        [TestMethod()]
        public void CopyToTest()
        {
            // NOTE: the Add method, adds them to the front of the list, therefore the list is in reverse
            var list = new SinglyLinkedList<int> { 1, 0, -1 };
            var expected = new int[] { -1, 0, 1 };
            var actual = new int[list.Count];
            list.CopyTo(actual, 0);

            CollectionAssert.AreEqual(expected, actual, "The arrays do not match");
        }


        [TestMethod()]
        public void GetEnumeratorTest()
        {
            // NOTE: the Add method, adds them to the front of the list, therefore the list is in reverse
            var list = new SinglyLinkedList<int> { 1, 0, -1, 44, 22, 22, 11, 2, 3, 4, 5 };
            var expected = new int[] { 5, 4, 3, 2, 11, 22, 22, 44, -1, 0, 1 };
            var actual = new System.Collections.Generic.List<int>();
            foreach (var item in list) { actual.Add(item); }

            CollectionAssert.AreEqual(expected, actual, "The collections do not match");
        }
    }
}
