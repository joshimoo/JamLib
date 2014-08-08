using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamLib.Algorithms.Sorting
{
    /// <summary>
    /// Merge sort: http://en.wikipedia.org/wiki/Merge_sort
    /// Cascade merge sort
    /// Oscillating merge sort
    /// Polyphase merge sort
    /// Strand sort
    /// </summary>
    public static class MergeSorts
    {
        // TODO: Refactor to be generic
        public static void MergeSort(this int[] array)
        {
            // Devide the list in half
            // Continue until we have a 1 Element List.
            // Combine the sublists
            //     8
            //  4    4
            // 2 2  2 2
            MergeSort(array, 0, array.Length);
        }


        // endIndex is exclusive
        private static void MergeSort(int[] array, int startIndex, int endIndex)
        {
            // Make sure the startIndex is smaller then the EndIndex
            if (startIndex < endIndex)
            {
                // Exit early, if we are at a 1 Element Sublist
                int length = endIndex - startIndex;
                if (length <= 1) { return; }

                // Calculate the Mid Boundary, and split the work in half.
                int midIndex = startIndex + (length / 2); ;
                MergeSort(array, startIndex, midIndex);
                MergeSort(array, midIndex, endIndex);
                Merge(array, startIndex, midIndex, endIndex);
            }
        }

        // Merge Routine TODO: Cleanup the Comments
        private static void Merge(int[] array, int startIndex, int midIndex, int endIndex)
        {
            int length = endIndex - startIndex;
            int[] temp = new int[length];
            int leftIndex = startIndex;
            int rightIndex = midIndex;

            for (int i = 0; i < length; i++)
            {
                // Did we reach the end of the left array, continue with the right
                if (leftIndex == midIndex) { temp[i] = array[rightIndex++]; }

                // Did we reach the end of the right array, continue with the left
                else if (rightIndex == endIndex) { temp[i] = array[leftIndex++]; }

                // Compare if the right element is smaller then the left
                // if (m_value < value) return -1;
                // if (m_value > value) return 1;
                // return 0;
                else if (array[rightIndex].CompareTo(array[leftIndex]) < 0) { temp[i] = array[rightIndex++]; }

                // The Left element is smaller
                else { temp[i] = array[leftIndex++]; }
            }

            // overwrite the changed elements in the data array
            for (int i = 0; i < length; i++)
            {
                array[startIndex + i] = temp[i];
            }
        }
    }
}
