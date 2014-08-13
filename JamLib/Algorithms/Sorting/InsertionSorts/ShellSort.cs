using System;
using System.Collections.Generic;
using System.Linq;

namespace JamLib.Algorithms.Sorting.InsertionSorts
{
    public static class ShellSort
    {
        public static void Sort<T>(this IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(this IList<T> data, IComparer<T> comparer)
        {
            // Using Marcin Ciura's gap sequence
            int[] intervals = new int[] { 701, 301, 132, 57, 23, 10, 4, 1 };
            Sort(data, intervals, comparer);
        }

        public static void Sort<T>(this IList<T> data, int[] intervals) { Sort(data, intervals, Comparer<T>.Default); }
        public static void Sort<T>(this IList<T> data, int[] intervals, IComparer<T> comparer)
        {
            // NOTE: Make Sure the intervalls contains 1 as an intervall for the final pass.
            // TODO: Evaluate Could use Assert and just Error out, but this is more robust and will function as expected even if the final pass is not included in the intervall
            if (!intervals.Contains(1))
            {
                int[] temp = new int[intervals.Length + 1];
                temp[0] = 1;
                intervals.CopyTo(temp, 1);
                intervals = temp;
            }

            // NOTE: Sort the Intervall before using it to make sure that it's always descending
            // Fun Times using a different sorting algorithm inside a sorting algorithm to make sure that the parameters are sorted correctly.
            Array.Sort(intervals, (i, j) => j.CompareTo(i));

            // Start with the largest gap and work down to a gap of 1 
            foreach (var interval in intervals)
            {
                // Perform InsertionSort with the current interval.
                InsertionSort.Sort(data, interval, comparer);
            }
        }
    }
}
