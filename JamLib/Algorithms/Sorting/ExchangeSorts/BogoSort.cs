using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Algorithms.Sorting.ExchangeSorts
{
    /// <summary>
    /// This is so bad it should never be used.
    /// </summary>
    public static class BogoSort
    {
        public static void Sort<T>(IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(IList<T> data, IComparer<T> comparer)
        {
            while (!SortingUtils.IsSorted(data, comparer))
            {
                SortingUtils.Shuffle(data);
            }
        }
    }
}
