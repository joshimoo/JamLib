using System.Collections.Generic;

namespace JamLib.Algorithms.Sorting.ExchangeSorts
{
    public static class OddEvenSort
    {
        // TODO: Think about adding additional overloads for IComparable as well as Comparison (so that we can use lambda expressions)
        public static void Sort<T>(IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(IList<T> data, IComparer<T> comparer)
        {
            bool sorted = false;
            while (!sorted)
            {
                // Reset Sort Status
                sorted = true;

                // Odd Run NOTE: Normally I like lagging behind instead of processing in advance, but processing forward is more expressive for this sort.
                for (int i = 1; i < data.Count - 1; i += 2)
                {
                    // if this pair is out of order, swap them and remember something changed
                    if (comparer.Compare(data[i], data[i + 1]) > 0)
                    {
                        SortingUtils.Swap(data, i, i + 1);
                        sorted = false;
                    }
                }

                // Even Run
                for (int i = 0; i < data.Count - 1; i += 2)
                {
                    // if this pair is out of order, swap them and remember something changed
                    if (comparer.Compare(data[i], data[i + 1]) > 0)
                    {
                        SortingUtils.Swap(data, i, i + 1);
                        sorted = false;
                    }
                }
            }
        }


    }
}