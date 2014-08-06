using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        // I Like the IComparer, Comparison approach much more, since it is generic.
        // But since this is mearly a toy it does not really matter.
        // TODO: Think about Extension Method vs Regular Method, right now I am invoking them as a regular method, since I have not decided yet.
        // Pseudo Code:
        // Increase Search Space
        // Traverse Search Space in Reverse
        // Swap Element if smaller

        /* Optional Parameters vs Method Overloading Discussion
         * http://haacked.com/archive/2010/08/10/versioning-issues-with-optional-arguments.aspx/
         * http://haacked.com/archive/2010/08/12/more-optional-versioning-fun.aspx/
         * http://codebetter.com/2011/01/11/c-in-depth-optional-parameters-and-named-arguments-2/
         * http://lostechies.com/jimmybogard/2010/05/18/caveats-of-c-4-0-optional-parameters/
         * http://blogs.msdn.com/b/ericlippert/archive/tags/optional+arguments/
         * 
         * Pro:
         * The gist is that optional Parameters are great for COM Interop
         * Named Parameters
         * Inline Documentation
         * 
         * Negative:
         * The problems are that they get compiled into the calling code, therefore they only get updated once you recompile against the updated library.
         * They are not supported in all Languages
         * Expressions need to supply the default parameter
         * Calling Code could still reference a method call where the parameter order was changed, but since the parameter types would be the same the compiler would not recognize the problem
         */

        // NOTE: I think a public api consumer has no need to call InsertionSort with a specified interval parameter?
        public static int[] InsertionSort(this int[] array) { return InsertionSort(array, 1); }
        internal static int[] InsertionSort(this int[] array, int interval)
        {
            for (int i = interval; i < array.Length; i++)
            {
                // Swap if left side is bigger, exits the loop if it's not
                for (int j = i; j >= interval && (array[j - interval] > array[j]); j -= interval)
                {
                    // Could be done in place
                    int temp = array[j - interval];
                    array[j - interval] = array[j];
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
            // NOTE: Make Sure the intervalls contains 1 as an intervall for the final pass.
            // Could use Assert and just Error out, but this is more robust and will function as expected even if the user of the Library does not include the final pass in the intervall
            if (!intervals.Contains(1))
            {
                int[] temp = new int[intervals.Length + 1];
                temp[0] = 1;
                intervals.CopyTo(temp, 1);
                intervals = temp;
            }

            // NOTE: Sort the Intervall before using it to make sure that it's always descending
            // Fun Times using a different sorting algorithm inside a sorting algorithm to make sure that the parameters are sorted correctly.
            Array.Sort(intervals, (i, j) => j.CompareTo(i));

            // Start with the largest gap and work down to a gap of 1 
            foreach (var interval in intervals)
            {
                // Perform InsertionSort with the current interval.
                array = InsertionSort(array, interval);
            }

            return array;
        }

    }
}
