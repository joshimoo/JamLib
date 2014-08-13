using System.Collections.Generic;

namespace JamLib.Algorithms.Sorting.ExchangeSorts
{
    public static class QuickSort3Way
    {
        public static void Sort<T>(IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(IList<T> data, IComparer<T> comparer)
        {
            // Shuffle to make sure, we don't hit worst case performance
            SortingUtils.Shuffle(data);
            Sort(data, 0, data.Count - 1, comparer);
        }

        // Implement 3Way QuickSort uses a 3 way approach for partitioning, based on http://algs4.cs.princeton.edu/23quicksort/Quick3way.java.html
        public static void Sort<T>(IList<T> data, int startIndex, int endIndex, IComparer<T> comparer)
        {
            if (startIndex >= endIndex) { return; }

            int leftIndex = startIndex;
            int rightIndex = endIndex;
            int i = startIndex;
            T target = data[startIndex];

            while (i <= rightIndex)
            {
                int cmp = comparer.Compare(data[i], target);
                if (cmp < 0) { SortingUtils.Swap(data, leftIndex++, i++); }
                else if (cmp > 0) { SortingUtils.Swap(data, i, rightIndex--); }
                else { i++; }
            }

            // data[startIndex..leftIndex-1] < target = data[leftIndex..rightIndex] < data[rightIndex+1..endIndex]. 
            Sort(data, startIndex, leftIndex - 1, comparer);
            Sort(data, rightIndex + 1, endIndex, comparer);
        }
    }
}