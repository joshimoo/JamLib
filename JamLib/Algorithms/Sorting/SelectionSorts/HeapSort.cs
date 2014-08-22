using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Algorithms.Sorting.SelectionSorts
{
    public static class HeapSort
    {
        public static void Sort<T>(IList<T> data) { Sort(data, Comparer<T>.Default); }
        public static void Sort<T>(IList<T> data, IComparer<T> comparer)
        {
            // Build the heap in array a so that largest value is at the root)
            Heapify(data, comparer);

            // The following loop maintains the invariants that a[0:end] is a heap and every element
            // beyond end is greater than everything before it (so a[end:count] is in sorted order)
            for (int endIndex = data.Count - 1; endIndex > 0; endIndex--)
            {
                // a[0] is the root and largest value. The swap moves it in front of the sorted elements.
                SortingUtils.Swap(data, 0, endIndex);

                // the swap ruined the heap property, so restore it for all elements in front of the sorted elements (endIndex -1)
                SiftDown(data, 0, endIndex - 1, comparer);
            }
        }

        // Build a Max Heap (biggest element == root)
        private static void Heapify<T>(IList<T> data, IComparer<T> comparer)
        {
            //start is assigned the index of the last parent node, since the last element is at count-1 we need to find it's parent
            for (int startIndex = Parent(data.Count - 1); startIndex >= 0; startIndex--)
            {
                // sift down the node at startIndex to the proper place such that all nodes below the startIndex are in heap order
                SiftDown(data, startIndex, data.Count - 1, comparer);
            }
        }

        private static void SiftDown<T>(IList<T> data, int startIndex, int endIndex, IComparer<T> comparer)
        {
            // While the root has at least one child
            int root = startIndex;
            while (LeftChild(root) <= endIndex)
            {
                int leftChild = LeftChild(root);
                int rightChild = RightChild(root);
                int swap = root;

                // If the left/right child is bigger then swap, make them the new swap
                if (comparer.Compare(data[swap], data[leftChild]) < 0) { swap = leftChild; }
                if (rightChild <= endIndex && comparer.Compare(data[swap], data[rightChild]) < 0) { swap = rightChild; }

                // Update the root element, till we have nothing left to swap
                if (swap != root)
                {
                    SortingUtils.Swap(data, root, swap);
                    root = swap;
                }
                else { return; }
            }
        }

        private static int LeftChild(int i) { return 2 * i + 1; }
        private static int RightChild(int i) { return 2 * i + 2; }
        private static int Parent(int i) { return (i - 1) / 2; }
    }
}
