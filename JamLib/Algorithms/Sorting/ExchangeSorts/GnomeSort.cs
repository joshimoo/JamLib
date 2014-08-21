using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Algorithms.Sorting.ExchangeSorts
{
    public static class GnomeSort
    {
        /// <summary>
        /// Gnome sort runs in O(n^2), but if the array 
        /// is nearly sorted already it runs in about O(n)
        /// http://en.wikipedia.org/wiki/Gnome_sort
        /// </summary>
        public static void Sort<T>(IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(IList<T> data, IComparer<T> comparer)
        {
            int pos = 1;
            while (pos < data.Count)
            {
                if (comparer.Compare(data[pos - 1], data[pos]) <= 0) { pos++; }
                else
                {
                    SortingUtils.Swap(data, pos - 1, pos);
                    if (pos > 1) { pos--; }
                }
            }
        }

    }
}
