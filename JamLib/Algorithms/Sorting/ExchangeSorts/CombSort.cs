using System.Collections.Generic;

namespace JamLib.Algorithms.Sorting.ExchangeSorts
{
    public static class CombSort
    {
        // TODO: Think about adding additional overloads for IComparable as well as Comparison (so that we can use lambda expressions)
        public static void Sort<T>(IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(IList<T> data, IComparer<T> comparer)
        {
            int gap = data.Count; //initialize gap size
            float shrink = 1.3f; //set the gap shrink factor
            bool sorted = false;

            while (gap > 1 || !sorted)
            {
                // Update Gap size
                gap = (int)(gap / shrink);
                if (gap < 1) { gap = 1; }

                // Reset Sort Status
                sorted = true;

                for (int i = 0; i + gap < data.Count; i++)
                {
                    // if this pair is out of order, swap them and remember something changed
                    if (comparer.Compare(data[i], data[i + gap]) > 0)
                    {
                        SortingUtils.Swap(data, i, i + gap);
                        sorted = false;
                    }
                }

            }
        }


    }
}