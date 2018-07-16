using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.SortingAndSearching.SearchMatrix
{
    /*
    Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

    Integers in each row are sorted in ascending from left to right.
    Integers in each column are sorted in ascending from top to bottom.
    Example:

    Consider the following matrix:

    [
      [1,   4,  7, 11, 15],
      [2,   5,  8, 12, 19],
      [3,   6,  9, 16, 22],
      [10, 13, 14, 17, 24],
      [18, 21, 23, 26, 30]
    ]
    Given target = 5, return true.

    Given target = 20, return false.

    https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/806/

    */

    public class Solution
    {
        public static void Test()
        {
            int[,] matrix = new int[5, 5]
            {
                {1,   4,  7, 11, 15},
                {2,   5,  8, 12, 19},
                {3,   6,  9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            //int[,] matrix = new int[1, 2]
            //{
            //    { 1, 1 }
            //};

            int target = 20;

            Solution s = new Solution();
            bool result = s.SearchMatrix(matrix, target);
            Console.WriteLine(result);
        }

        public bool SearchMatrix(int[,] matrix, int target)
        {
            // check later if dimensions need to be checked
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) { return false; }

            int x = 0;
            int y = matrix.GetLength(1) - 1;

            while (x < matrix.GetLength(0) && y >= 0)
            {
                if (matrix[x, y] == target) { return true; }

                if (target < matrix[x, y]) { y--; }
                else { x++; }
            }

            return false;
        }
    }
}
