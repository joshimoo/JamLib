using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Algorithms.Sorting
{
    public static class SortingUtils
    {
        public static void Swap<T>(IList<T> data, int i, int j)
        {
            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}
