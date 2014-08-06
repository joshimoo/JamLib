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

        public static int[] BubbleSort(this int[] array)
        {
            // NOTE: Run this atleast once, could use a do while instead
            bool swapped = true;
            while (swapped)
            {
                // Reset Swap Status
                swapped = false;

                for (int i = 1; i < array.Length; i++)
                {
                    // if this pair is out of order, swap them and remember something changed
                    if (array[i - 1] > array[i])
                    {
                        int temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        swapped = true;
                    }
                }
            }

            return array;
        }


    }
}
