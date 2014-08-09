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

        public static void BubbleSort(this int[] data)
        {
            // NOTE: Run this atleast once, could use a do while instead
            bool swapped = true;
            while (swapped)
            {
                // Reset Swap Status
                swapped = false;

                for (int i = 1; i < data.Length; i++)
                {
                    // if this pair is out of order, swap them and remember something changed
                    if (data[i - 1] > data[i])
                    {
                        int temp = data[i - 1];
                        data[i - 1] = data[i];
                        data[i] = temp;
                        swapped = true;
                    }
                }
            }
        }


    }
}
