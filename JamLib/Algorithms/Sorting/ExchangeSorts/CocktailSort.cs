using System.Collections.Generic;

namespace JamLib.Algorithms.Sorting.ExchangeSorts
{
    public static class CocktailSort
    {
        // TODO: Think about adding additional overloads for IComparable as well as Comparison (so that we can use lambda expressions)
        public static void Sort<T>(IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(IList<T> data, IComparer<T> comparer)
        {
            // NOTE: Optimization, since each pass trough the array the first/last element is always in it's final place. We no longer need to check them.
            int startIndex = 0;
            int endIndex = data.Count;
            bool swapped = true;
            while (swapped)
            {
                // Reset Swap Status
                swapped = false;

                // NOTE: Optimization increases startIndex because the elements before startIndex are in correct order
                startIndex++;

                // Left to Right pass
                for (int i = startIndex; i < endIndex; i++)
                {
                    // if this pair is out of order, swap them and remember something changed
                    if (comparer.Compare(data[i - 1], data[i]) > 0)
                    {
                        SortingUtils.Swap(data, i - 1, i);
                        swapped = true;
                    }
                }

                // we can exit early if no swaps occurred.
                if (!swapped) { break; }
                else { swapped = false; }

                // NOTE: Optimization decreases endIndex because the elements after endIndex are in correct order
                endIndex--;

                // Right to Left pass
                for (int i = endIndex; i >= startIndex; i--)
                {
                    // if this pair is out of order, swap them and remember something changed
                    if (comparer.Compare(data[i - 1], data[i]) > 0)
                    {
                        SortingUtils.Swap(data, i - 1, i);
                        swapped = true;
                    }
                }

            }
        }


    }
}