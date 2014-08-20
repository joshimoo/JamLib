using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Algorithms.Searching
{
    public static class LinearSearch
    {
        public static int Search<T>(this IList<T> data, T element) { return Search(data, element, Comparer<T>.Default); }
        public static int Search<T>(this IList<T> data, T element, IComparer<T> comparer)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (comparer.Compare(data[i], element) == 0) { return i; }
            }

            return -1;
        }

        public static int ReverseSearch<T>(this IList<T> data, T element) { return ReverseSearch(data, element, Comparer<T>.Default); }
        public static int ReverseSearch<T>(this IList<T> data, T element, IComparer<T> comparer)
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                if (comparer.Compare(data[i], element) == 0) { return i; }
            }

            return -1;
        }

    }
}
