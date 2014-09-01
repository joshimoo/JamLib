using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Algorithms.Combinatorial.CycleFinding
{
    public static class BrentCycleDetection
    {
        public static bool DetectCycle<T>(JamLib.DataStructures.Lists.IndexedLinkedList<T> list)
        {
            // Start both at the same position
            var i = list.First;
            var j = list.First;

            int stepCount = 0;
            int stepLimit = 2;

            while (j != null)
            {
                // Iterate trough our list
                j = j.Next;
                stepCount++;

                // Check if we are at the same position, which means there is a loop
                if (j == i) { break; }

                // Increase the step limits 
                if (stepCount == stepLimit)
                {
                    stepCount = 0;
                    stepLimit *= 2;
                    i = j;
                }
            }

            // We found a cycle if j != null
            return j != null;
        }
    }
}
