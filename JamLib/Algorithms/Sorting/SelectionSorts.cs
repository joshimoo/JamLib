using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamLib.Algorithms.Sorting
{
    /// <summary>
    /// Selection sort: http://en.wikipedia.org/wiki/Selection_sort
    /// Heapsort:
    /// Smoothsort:
    /// Cartesian tree sort:
    /// Tournament sort:
    /// Cycle sort:
    /// </summary>
    public static class SelectionSorts
    {
        public static void SelectionSort<T>(this IList<T> data) { SelectionSort(data, Comparer<T>.Default); }
        public static void SelectionSort<T>(this IList<T> data, IComparer<T> comparer)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                // Assume the first element is the minimum
                int minIndex = i;

                // test against elements after i to find the smallest
                for (int j = i + 1; j < data.Count; j++)
                {
                    // if data[j] is less, then it is the new minimum
                    // if (data[minIndex] > data[j]) { minIndex = j; }
                    if (comparer.Compare(data[minIndex], data[j]) > 0) { minIndex = j; }
                }

                // Swap the Elements
                if (minIndex != i)
                {
                    SortingUtils.Swap(data, i, minIndex);
                }
            }
        }


    }
}
