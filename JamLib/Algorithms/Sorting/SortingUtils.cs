using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Algorithms.Sorting
{
    public static class SortingUtils
    {
        public static void Swap<T>(IList<T> data, int i, int j)
        {
            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        public static bool Less<T>(T i, T j) { return Less(i, j, Comparer<T>.Default); }
        public static bool Less<T>(T i, T j, IComparer<T> comparer) { return comparer.Compare(i, j) < 0; }

        // Fisher–Yates_shuffle: http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        public static void Shuffle<T>(this T[] array)
        {
            Random random = new Random();
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap. 0 <= j <= i-1
                int j = random.Next(i);
                Swap(array, i - 1, j);
            }
        }
    }
}
