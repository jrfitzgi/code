using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Arrays.SetZeroes
{
    // Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in-place.
    // https://leetcode.com/problems/set-matrix-zeroes/description/


    public class Solution
    {
        public static void Run()
        {
            int[,] matrix = new int[3, 3] { { 1, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 } };
            Solution s = new Solution();
            s.SetZeroes(matrix);

        }


        public void SetZeroes(int[,] matrix)
        {
            if (matrix == null) { return; }

            int mSize = matrix.GetLength(0);
            int nSize = matrix.GetLength(1);

            bool zeroOutM = false;
            bool zeroOutM_1 = false;

            for (int m = 0; m < mSize; m++)
            {
                zeroOutM = false;

                for (int n = 0; n < nSize; n++)
                {
                    if (matrix[m, n] == 0)
                    {
                        zeroOutM = true;

                        // zero out everything above
                        for (int m2 = m; m2 >= 0; m2--)
                        {
                            matrix[m2, n] = 0;
                        }
                    }
                    else if (m > 0 && matrix[m - 1, n] == 0) // element above is 0
                    {
                        matrix[m, n] = 0;
                    }
                }

                if (zeroOutM_1)
                {
                    for (int n = 0; n < nSize; n++)
                    {
                        matrix[m - 1, n] = 0;
                    }
                }

                zeroOutM_1 = zeroOutM;

            }

            if (zeroOutM)
            {
                for (int n = 0; n < nSize; n++)
                {
                    matrix[mSize - 1, n] = 0;
                }
            }

        }

        public void SetZeroes2(int[,] matrix)
        {
            if (matrix == null) { return; }

            int mSize = matrix.GetLength(0);
            int nSize = matrix.GetLength(1);

            bool[] M = new bool[mSize];
            bool[] N = new bool[nSize];

            for (int m = 0; m < mSize; m++)
            {
                for (int n = 0; n < nSize; n++)
                {
                    if (matrix[m, n] == 0)
                    {
                        M[m] = true;
                        N[n] = true;
                    }
                }
            }

            // zero out M
            for (int m = 0; m < mSize; m++)
            {
                if (M[m] == true)
                {
                    for (int n = 0; n < nSize; n++)
                    {
                        matrix[m, n] = 0;
                    }
                }
            }

            // zero out N
            for (int n = 0; n < nSize; n++)
            {
                if (N[n] == true)
                {
                    for (int m = 0; m < mSize; m++)
                    {
                        matrix[m, n] = 0;
                    }
                }
            }


        }
    }
}
