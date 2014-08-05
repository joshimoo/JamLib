namespace JamLib.Algorithms.Sorting
{

    /// <summary>
    /// Wikipedia: http://en.wikipedia.org/wiki/Insertion_sort
    /// Insertion sort 
    /// Shell sort
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
                for (int j = i; j > 0; j--)
                {
                    // Swap if smaller
                    if (array[j] < array[j - 1])
                    {
                        // Could be done in place
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                    else { break; } // TODO: Check in the for loop exit condition, since we don't need to check the rest of the array if this fails. Since they are already sorted
                }
            }
            return array;
        }
    }
}
