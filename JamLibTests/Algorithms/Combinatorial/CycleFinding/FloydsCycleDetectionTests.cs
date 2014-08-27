using JamLib.Algorithms.Combinatorial.CycleFinding;
using JamLib.DataStructures.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Combinatorial.CycleFinding.Tests
{
    [TestClass()]
    public class FloydsCycleDetectionTests
    {
        [TestMethod()]
        public void FloydsCycleDetection_DetectCycleTest()
        {
            // The NetFramework implementation of a LinkedList stops you from adding any cycles, therefore we are using our rudimentary implementation for demonstration
            JamLib.DataStructures.Lists.SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1111, 2, 3, 4, 5, 6, 5555, 1, 2, 9999 };

            // get the last node, and hook it up somewhere in the middle NOTE: the LinkedList is in reverse order
            var last = list.Find(1111);
            var target = list.Find(5555);
            last.Next = target;

            Assert.IsTrue(FloydsCycleDetection.DetectCycle(list), "Should have found a cycle");
        }

        public void FloydsCycleDetection_NoCycleTest()
        {
            // The NetFramework implementation of a LinkedList stops you from adding any cycles, therefore we are using our rudimentary implementation for demonstration
            JamLib.DataStructures.Lists.SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1111, 5, 2, 3, 4, 5, 6, 5555, 1, 2, 9999 };
            Assert.IsFalse(FloydsCycleDetection.DetectCycle(list), "Should not have found a cycle");
        }
    }
}
