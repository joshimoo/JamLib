namespace JamLib.Algorithms.Sorting
{
    public static class ExchangeSorts
    {
        public static int[] BubbleSort(this int[] array)
        {
            // Run this atleast once, could use a do while instead
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
