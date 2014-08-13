using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Algorithms.Sorting.InsertionSorts
{
    public static class InsertionSort
    {
        // I Like the IComparer, Comparison approach much more, since it is generic.
        // But since this is mearly a toy it does not really matter.
        // Pseudo Code:
        // Increase Search Space
        // Traverse Search Space in Reverse
        // Swap Element if smaller

        // NOTE: an external api consumer has no need to call InsertionSort with a specified interval parameter.
        public static void Sort<T>(this IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(this IList<T> data, IComparer<T> comparer) { Sort(data, 1, comparer); }
        
        internal static void Sort<T>(this IList<T> data, int interval) { Sort(data, interval, Comparer<T>.Default); }
        internal static void Sort<T>(this IList<T> data, int interval, IComparer<T> comparer)
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
    }
}
