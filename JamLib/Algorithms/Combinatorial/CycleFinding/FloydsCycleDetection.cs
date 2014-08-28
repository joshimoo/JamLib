using System;
using System.Collections.Generic;

namespace JamLib.Algorithms.Combinatorial.CycleFinding
{
    // TODO: Think about this naming scheme.
    public static class FloydsCycleDetection
    {
        // TODO: Implement a more Generic version which also returns the cycle length as well as cycle start
        // The NetFramework implementation of a LinkedList stops you from adding any cycles, therefore we are using our rudimentary implementation for demonstration
        public static bool DetectCycle<T>(JamLib.DataStructures.Lists.IndexedLinkedList<T> list)
        {
            // Start at the beginning +1 and +2
            var i = list.First != null ? list.First.Next : null; ;
            var j = i != null ? i.Next : null;

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
            // Start both at the same position
            var i = list.First;
            var j = list.First;

            while (j != null)
            {
                // Iterate trough our list, j is always at index i * 2 (example: 1,2 > 2,4 > 3,6)
                i = i.Next;
                j = j.Next != null ? j.Next.Next : null;
                if (j == i) { break; }
            }

            // We found a cycle if j != null
            return j != null;
        }
    }
}
