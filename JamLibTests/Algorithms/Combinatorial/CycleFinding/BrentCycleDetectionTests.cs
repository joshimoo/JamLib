using JamLib.Algorithms.Combinatorial.CycleFinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Combinatorial.CycleFinding.Tests
{
    [TestClass()]
    public class BrentCycleDetectionTests
    {
        [TestMethod()]
        public void DetectCycleTest()
        {
            // The NetFramework implementation of a LinkedList stops you from adding any cycles, therefore we are using our rudimentary implementation for demonstration
            var list = new JamLib.DataStructures.Lists.IndexedLinkedList<int>() { 1111, 2, 3, 4, 5, 6, 5555, 1, 2, 9999 };

            // get the last node, and hook it up somewhere in the middle
            var middle = list.Find(5555);
            var target = list.First;
            middle.Next = target;

            Assert.IsTrue(FloydCycleDetection.DetectCycle(list), "Should have found a cycle");
        }

        [TestMethod()]
        public void DetectCycle_Alternative_Test()
        {
            // The NetFramework implementation of a LinkedList stops you from adding any cycles, therefore we are using our rudimentary implementation for demonstration
            var list = new JamLib.DataStructures.Lists.IndexedLinkedList<int>() { 1111, 2, 3, 4, 5, 6, 5555, 1, 2, 9999 };

            // get the last node, and hook it up somewhere in the middle
            var last = list.Last;
            var target = list.Find(5555);
            last.Next = target;

            Assert.IsTrue(FloydCycleDetection.DetectCycle(list), "Should have found a cycle");
        }

        [TestMethod()]
        public void DetectCycle_NoCycle_Test()
        {
            // The NetFramework implementation of a LinkedList stops you from adding any cycles, therefore we are using our rudimentary implementation for demonstration
            var list = new JamLib.DataStructures.Lists.IndexedLinkedList<int>() { 1111, 5, 2, 3, 4, 5, 6, 5555, 1, 2, 9999 };
            Assert.IsFalse(FloydCycleDetection.DetectCycle(list), "Should not have found a cycle");
        }
    }
}
