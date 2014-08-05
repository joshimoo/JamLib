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


    }
}
