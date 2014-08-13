using System.Collections.Generic;

namespace JamLib.Algorithms.Sorting.ExchangeSorts
{
    public static class QuickSort
    {
        public static void Sort<T>(IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(IList<T> data, IComparer<T> comparer)
        {
            // Shuffle to make sure, we don't hit worst case performance
            SortingUtils.Shuffle(data);
            Sort(data, 0, data.Count - 1, comparer);
        }

        /// <summary>
        /// Regular QuickSort that sorts beetwen startIndex and endIndex, both are inclusive
        /// </summary>
        /// <param name="startIndex">is inclusive</param>
        /// <param name="endIndex">is inclusive</param>
        private static void Sort<T>(IList<T> data, int startIndex, int endIndex, IComparer<T> comparer)
        {
            // Exit once the indexes cross
            if (startIndex >= endIndex) { return; }

            // Calculate Partion index then sort both sides from the partion index
            int partitionIndex = Partition(data, startIndex, endIndex, comparer);
            Sort(data, startIndex, partitionIndex - 1, comparer);
            Sort(data, partitionIndex + 1, endIndex, comparer);
        }

        // partition the subarray data[startIndex .. endIndex] so that data[startIndex .. partitionIndex-1] <= data[partitionIndex] <= data[partitionIndex+1 .. endIndex]
        // then return the partition index
        private static int Partition<T>(IList<T> data, int startIndex, int endIndex, IComparer<T> comparer)
        {
            int leftIndex = startIndex;
            int rightIndex = endIndex + 1; // also acts as the final partition index
            var target = data[startIndex];

            while (true)
            {
                // find item on the left side to swap
                while (SortingUtils.Less(data[++leftIndex], target, comparer))
                {
                    if (leftIndex == endIndex) { break; }
                }

                // find item on the right side to swap
                while (SortingUtils.Less(target, data[--rightIndex], comparer))
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