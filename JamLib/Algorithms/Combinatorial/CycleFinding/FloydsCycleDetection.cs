using System;
using System.Collections.Generic;

namespace JamLib.Algorithms.Combinatorial.CycleFinding
{
    // TODO: Think about this naming scheme.
    public static class FloydsCycleDetection
    {
        // TODO: Implement a more Generic version which also returns the cycle length as well as cycle start
        // The NetFramework implementation of a LinkedList stops you from adding any cycles, therefore we are using our rudimentary implementation for demonstration
        public static bool DetectCycle<T>(LinkedList<T> list)
        {
            // Start at the beginning and plus 1
            var i = list.First;
            var j = list.First != null ? list.First.Next : null;

            while (j != null && j != i)
            {
                // Iterate trough our list, j is always at index i * 2 (example: 1,2 > 2,4 > 3,6)
                i = i.Next;
                j = j.Next != null ? j.Next.Next : null;
            }

            // We found a cycle if j != null
            return j != null;
        }

        // The NetFramework implementation of a LinkedList stops you from adding any cycles, therefore we are using our rudimentary implementation for demonstration
        public static bool DetectCycle<T>(JamLib.DataStructures.Lists.SinglyLinkedList<T> list)
        {
            // Start at the beginning and plus 1
            var i = list.First;
            var j = list.First != null ? list.First.Next : null;

            while (j != null && j != i)
            {
                // Iterate trough our list, j is always at index i * 2 (example: 1,2 > 2,4 > 3,6)
                i = i.Next;
                j = j.Next != null ? j.Next.Next : null;
            }

            // We found a cycle if j != null
            return j != null;
        }
    }
}
