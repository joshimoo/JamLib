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
            Assert.Fail();
        }
    }
}
