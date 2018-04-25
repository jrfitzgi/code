using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    public partial class Solution
    {
        public void PascalsTriangle()
        {
            var result = PascalsTriangle(0);
            result = PascalsTriangle(1);
            result = PascalsTriangle(2);
            result = PascalsTriangle(3);
            result = PascalsTriangle(4);
            result = PascalsTriangle(5);
        }

        public int[,] PascalsTriangle(int numRows)
        {
            int[,] pt = new int[numRows, numRows];

            if (numRows <= 0) { return pt; }

            pt[0, 0] = 1;
            if (numRows == 1) { return pt; }

            for (int i = 1; i < numRows; i++)
            {
                // Fill in each end
                pt[i, 0] = 1;
                pt[i, i] = 1;

                // Fill in the middle
                for (int j = 1; j < i; j++)
                {
                    pt[i, j] = pt[i - 1, j - 1] + pt[i - 1, j];
                }

            }

            return pt;
        }
    }

}
