using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamLib.DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace JamLib.DataStructures.Trees.Tests
{
    [TestClass()]
    public class BinarySearchTreeTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var bst = new BinarySearchTree<int>() { 10, 15, 5, 4, 7, 20, 14, 0, -5, -8, -2, -1 };
            bst.Add(55);
            bst.Add(-55);
            bst.Add(35);

            // TODO: Dump as array then compare against expected array
            Assert.IsTrue(bst.Contains(55), "Did not add element correctly");
            Assert.IsTrue(bst.Contains(-55), "Did not add element correctly");
            Assert.IsTrue(bst.Contains(35), "Did not add element correctly");
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var bst = new BinarySearchTree<int>() { 10, 15, 5, 4, 7, 20, 14, 0, -5, -8, -2, -1 };
            bst.Remove(20);
            bst.Remove(0);
            bst.Remove(10);

            // TODO: Dump as array then compare against expected array
            Assert.IsFalse(bst.Contains(20), "Did not remove element correctly");
            Assert.IsFalse(bst.Contains(0), "Did not remove element correctly");
            Assert.IsFalse(bst.Contains(10), "Did not remove root element correctly");
        }

        [TestMethod()]
        public void ClearTest()
        {
            var bst = new BinarySearchTree<int>() { 10, 15, 5, 4, 7, 20, 14, 0, -5, -8, -2, -1 };
            bst.Clear();
            Assert.AreEqual(0, bst.Count, "Clearing the bst did not work");
        }

        [TestMethod()]
        public void ContainsTest()
        {
            var bst = new BinarySearchTree<int>() { 10, 15, 5, 4, 7, 20, 14, 0, -5, -8, -2, -1 };
            Assert.IsTrue(bst.Contains(0), "Contain method could not find element");
        }

        [TestMethod()]
        public void CopyToTest()
        {
            Assert.Fail("Not Implemented yet");
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Fail("Not Implemented yet");
        }
    }
}
