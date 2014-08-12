using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamLib.Algorithms.Sorting
{

    /// <summary>
    /// Insertion sort: http://en.wikipedia.org/wiki/Insertion_sort
    /// Shell sort: http://en.wikipedia.org/wiki/Shellsort
    /// Splay sort
    /// Tree sort
    /// Library sort
    /// Patience sorting
    /// </summary>
    public static class InsertionSorts
    {
        // I Like the IComparer, Comparison approach much more, since it is generic.
        // But since this is mearly a toy it does not really matter.
        // TODO: Think about Extension Method vs Regular Method, right now I am invoking them as a regular method, since I have not decided yet.
        // Pseudo Code:
        // Increase Search Space
        // Traverse Search Space in Reverse
        // Swap Element if smaller

        // NOTE: an external api consumer has no need to call InsertionSort with a specified interval parameter.
        public static void InsertionSort<T>(this IList<T> data) { InsertionSort(data, Comparer<T>.Default); }
        public static void InsertionSort<T>(this IList<T> data, IComparer<T> comparer) { InsertionSort(data, 1, comparer); }
        internal static void InsertionSort<T>(this IList<T> data, int interval) { InsertionSort(data, interval, Comparer<T>.Default); }
        internal static void InsertionSort<T>(this IList<T> data, int interval, IComparer<T> comparer)
        {
            for (int i = interval; i < data.Count; i++)
            {
                // Swap if left side is bigger, exits the loop if it's not
                for (int j = i; j >= interval && (comparer.Compare(data[j - interval], data[j]) > 0); j -= interval)
                {
                    SortingUtils.Swap(data, j - interval, j);
                }
            }
        }


        public static void ShellSort<T>(this IList<T> data) { ShellSort(data, Comparer<T>.Default); }
        public static void ShellSort<T>(this IList<T> data, IComparer<T> comparer)
        {
            // Using Marcin Ciura's gap sequence
            int[] intervals = new int[] { 701, 301, 132, 57, 23, 10, 4, 1 };
            ShellSort(data, intervals, comparer);
        }

        public static void ShellSort<T>(this IList<T> data, int[] intervals) { ShellSort(data, intervals, Comparer<T>.Default); }
        public static void ShellSort<T>(this IList<T> data, int[] intervals, IComparer<T> comparer)
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
                InsertionSort(data, interval, comparer);
            }
        }

    }
}
