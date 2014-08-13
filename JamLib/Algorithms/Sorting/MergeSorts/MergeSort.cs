using System.Collections.Generic;

namespace JamLib.Algorithms.Sorting.MergeSorts
{
    public static class MergeSort
    {

        public static void Sort<T>(IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(IList<T> data, IComparer<T> comparer)
        {
            // Pseudo Code:
            // Devide the list in half
            // Continue until we have a 1 Element List.
            // Combine the sublists
            //     8
            //  4    4
            // 2 2  2 2
            Sort(data, 0, data.Count, comparer);
        }


        /// <summary>
        /// MergeSort the data in the array beetwen startIndex and endIndex
        /// </summary>
        /// <param name="startIndex">is inclusive</param>
        /// <param name="endIndex">is exclusive</param>
        private static void Sort<T>(IList<T> data, int startIndex, int endIndex, IComparer<T> comparer)
        {
            // Make sure the startIndex is smaller then the EndIndex
            if (startIndex < endIndex)
            {
                // Exit early, if we are at a 1 Element Sublist
                int length = endIndex - startIndex;
                if (length <= 1) { return; }

                // Calculate the Mid Boundary, and split the work in half.
                int midIndex = startIndex + (length / 2); ;
                Sort(data, startIndex, midIndex, comparer);
                Sort(data, midIndex, endIndex, comparer);
                Merge(data, startIndex, midIndex, endIndex, comparer);
            }
        }

        private static void Merge<T>(IList<T> data, int startIndex, int midIndex, int endIndex, IComparer<T> comparer)
        {
            int length = endIndex - startIndex;
            var temp = new T[length];
            int leftIndex = startIndex;
            int rightIndex = midIndex;

            for (int i = 0; i < length; i++)
            {
                // Did we reach the end of the left array, continue with the right
                if (leftIndex == midIndex) { temp[i] = data[rightIndex++]; }

                // Did we reach the end of the right array, continue with the left
                else if (rightIndex == endIndex) { temp[i] = data[leftIndex++]; }

                // Compare if the right element is smaller then the left
                // if (m_value < value) return -1;
                // if (m_value > value) return 1;
                // return 0;
                else if (comparer.Compare(data[leftIndex], data[rightIndex]) > 0) { temp[i] = data[rightIndex++]; }

                // The Left element is smaller
                else { temp[i] = data[leftIndex++]; }
            }

            // overwrite the changed elements in the data array
            for (int i = 0; i < length; i++)
            {
                data[startIndex + i] = temp[i];
            }
        }
    }
}
