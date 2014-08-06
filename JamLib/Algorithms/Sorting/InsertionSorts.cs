using System;

namespace JamLib.Algorithms.Sorting
{

    /// <summary>
    /// Insertion sort: http://en.wikipedia.org/wiki/Insertion_sort
    /// Shell sort: http://en.wikipedia.org/wiki/Shellsort
    /// Splay sort
    /// Tree sort
    /// Library sort
    /// Patience sorting
    /// </summary>
    public static class InsertionSorts
    {
        // I Like the IComparer approach much more, since it is generic.
        // But since this is mearly a toy it does not really matter.
        // TODO: Think about Extension Method vs Regular Method 
        // Pseudo Code:
        // Increase Search Space
        // Traverse Search Space in Reverse
        // Swap Element if smaller

        public static int[] InsertionSort(this int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                // Swap if left side is bigger, exits the loop if it's not
                for (int j = i; j > 0 && (array[j - 1] > array[j]); j--)
                {
                    // Could be done in place
                    int temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                }
            }

            return array;
        }

        public static int[] ShellSort(this int[] array)
        {
            // Using Marcin Ciura's gap sequence
            int[] intervals = new int[] { 701, 301, 132, 57, 23, 10, 4, 1 };
            return array.ShellSort(intervals);
        }

        public static int[] ShellSort(this int[] array, int[] intervals)
        {
            // NOTE: Sort the Intervall before using it to make sure that it's always descending
            Array.Sort(intervals, (i, j) => j.CompareTo(i));

            // Start with the largest gap and work down to a gap of 1 
            foreach (var interval in intervals)
            {
                // Do a gapped insertion sort for this gap size.
                // The first gap elements a[0..gap-1] are already in gapped order
                // keep adding one more element until the entire array is gap sorted 
                for (int i = interval; i < array.Length; i++)
                {
                    // add a[i] to the elements that have been gap sorted
                    // save a[i] in temp and make a hole at position i
                    int temp = array[i];

                    // shift earlier gap-sorted elements up until the correct location for a[i] is found
                    int j = i;
                    while (j >= interval && (array[j - interval] > temp))
                    {
                        array[j] = array[j - interval];
                        j -= interval;
                    }

                    // put temp (the original a[i]) in its correct location
                    array[j] = temp;
                }
            }

            return array;
        }

    }
}
