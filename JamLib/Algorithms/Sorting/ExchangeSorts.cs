﻿using System;
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
    /// Quicksort: http://en.wikipedia.org/wiki/Quicksort
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
                        SortingUtils.Swap(data, i - 1, i);
                        swapped = true;
                    }
                }
            }
        }

        // TODO: Think about creating individual classes for each algorithm
        public static void QuickSort(this int[] data)
        {
            // Shuffle to make sure, we don't hit worst case performance
            SortingUtils.Shuffle(data);
            QuickSort(data, 0, data.Length - 1);
        }

        // startIndex, endIndex is inclusive
        private static void QuickSort(this int[] data, int startIndex, int endIndex)
        {
            // Exit early, once the indexes cross
            if (startIndex >= endIndex) { return; }

            // Calculate Partion index then sort both sides from the partion index
            int partitionIndex = Partition(data, startIndex, endIndex);
            QuickSort(data, startIndex, partitionIndex - 1);
            QuickSort(data, partitionIndex + 1, endIndex);
        }

        // partition the subarray data[startIndex .. endIndex] so that data[startIndex .. partitionIndex-1] <= data[partitionIndex] <= data[partitionIndex+1 .. endIndex]
        // then return the partition index
        private static int Partition(int[] data, int startIndex, int endIndex)
        {
            int leftIndex = startIndex;
            int rightIndex = endIndex + 1; // also acts as the final partition index
            var target = data[startIndex];

            while (true)
            {
                // find item on the left side to swap
                while (SortingUtils.Less(data[++leftIndex], target))
                {
                    if (leftIndex == endIndex) { break; }
                }

                // find item on the right side to swap
                while (SortingUtils.Less(target, data[--rightIndex]))
                {
                    if (rightIndex == startIndex) { break; }
                }

                // check if pointers cross
                if (leftIndex >= rightIndex) { break; }

                // Swap the item on the left with the item on the right, so that data[]
                SortingUtils.Swap(data, leftIndex, rightIndex);
            }

            // Swap the target with the final partition index, so that data[startIndex .. rightIndex-1] <= data[rightIndex] <= data[rightIndex+1 .. endIndex]
            SortingUtils.Swap(data, startIndex, rightIndex);
            return rightIndex;
        }


    }
}
