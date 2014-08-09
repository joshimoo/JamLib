using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamLib.Algorithms.Sorting
{
    /// <summary>
    /// Bubble sort: http://en.wikipedia.org/wiki/Bubble_sort
    /// Cocktail sort:
    /// Odd–even sort:
    /// Comb sort:
    /// Gnome sort:
    /// Quicksort:
    /// Stooge sort:
    /// Bogosort:
    /// </summary>
    public static class ExchangeSorts
    {
        // TODO: Think about adding additional overloads for IComparable as well as Comparison (so that we can use lambda expressions)
        public static void BubbleSort<T>(this IList<T> data) { BubbleSort(data, Comparer<T>.Default); }
        public static void BubbleSort<T>(this IList<T> data, IComparer<T> comparer)
        {
            // NOTE: Run this atleast once, could use a do while instead
            bool swapped = true;
            while (swapped)
            {
                // Reset Swap Status
                swapped = false;

                for (int i = 1; i < data.Count; i++)
                {
                    // if this pair is out of order, swap them and remember something changed
                    if (comparer.Compare(data[i - 1], data[i]) > 0)
                    {
                        T temp = data[i - 1];
                        data[i - 1] = data[i];
                        data[i] = temp;
                        swapped = true;
                    }
                }
            }
        }

    }
}
