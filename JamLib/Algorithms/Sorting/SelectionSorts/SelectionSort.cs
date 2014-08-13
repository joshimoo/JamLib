using System.Collections.Generic;

namespace JamLib.Algorithms.Sorting.SelectionSorts
{
    public static class SelectionSort
    {
        public static void Sort<T>(this IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(this IList<T> data, IComparer<T> comparer)
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
