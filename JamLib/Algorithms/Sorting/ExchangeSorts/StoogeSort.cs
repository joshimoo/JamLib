using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Algorithms.Sorting.ExchangeSorts
{
    public static class StoogeSort
    {
        public static void Sort<T>(IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(IList<T> data, IComparer<T> comparer) { Sort(data, 0, data.Count - 1, comparer); }

        /// <summary>
        /// Stooge sort is a recursive sorting algorithm with a time complexity of O(n ^(log 3 / log 1.5) ) = O(n^2.7095). 
        /// The running time of the algorithm is thus slower compared to efficient sorting algorithms, such as Merge sort.
        /// And is even slower than Bubble sort, a canonical example of a fairly inefficient and simple sort.
        /// </summary>
        /// <param name="startIndex">is inclusive</param>
        /// <param name="endIndex">is inclusive</param>
        private static void Sort<T>(IList<T> data, int startIndex, int endIndex, IComparer<T> comparer)
        {
            // Swap elements if the first is bigger then the last
            if (comparer.Compare(data[startIndex], data[endIndex]) > 0) { SortingUtils.Swap(data, startIndex, endIndex); }

            int length = (endIndex - startIndex + 1);
            if (length > 2) // There is no point recursivly sorting a 2 element list since the compare&swap at the top took care of it.
            {
                int third = length / 3;
                Sort(data, startIndex, endIndex - third, comparer);
                Sort(data, startIndex + third, endIndex, comparer);
                Sort(data, startIndex, endIndex - third, comparer);
            }
        }

    }
}
