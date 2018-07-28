using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.SortingAndSearching
{
    class ArrayComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x.Length != y.Length) { return x.Length > y.Length ? 1 : -1; }

            return 0;
        }
    }
}
