using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamLib.Algorithms.Sorting
{
    /// <summary>
    /// Selection sort: http://en.wikipedia.org/wiki/Selection_sort
    /// Heapsort:
    /// Smoothsort:
    /// Cartesian tree sort:
    /// Tournament sort:
    /// Cycle sort:
    /// </summary>
    public static class SelectionSorts
    {

        public static int[] SelectionSort(this int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                // Assume the first element is the minimum
                int minIndex = i;

                // test against elements after i to find the smallest
                for (int j = i + 1; j < array.Length; j++)
                {
                    // if this element is less, then it is the new minimum
                    if (array[minIndex] > array[j]) { minIndex = j; }
                }

                // Swap the Elements
                if (minIndex != i)
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }

            return array;
        }


    }
}
