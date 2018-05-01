using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    public partial class Solution
    {
        /*
        https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/770/
        You are given an n x n 2D matrix representing an image.
        Rotate the image by 90 degrees (clockwise).
        You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.        
        */

        public void RotateImage()
        {
            int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            PrintArray(matrix);
            RotateImage(matrix);
            Console.WriteLine();
            PrintArray(matrix);
        }

        public void RotateImage(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int maxIteration = (int)Math.Ceiling((double)n / 2);
            for (int i = 0; i < maxIteration; i++)
            {
                for (int j = 0; j < maxIteration; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[n - j - 1, i];
                    matrix[n - i - 1, 0] = matrix[n - j - 1, n - i - 1];
                    matrix[n - i - 1, n - j - 1] = matrix[j, n - i - 1];
                    matrix[i, n - j - 1] = temp;

                    Console.WriteLine();
                    PrintArray(matrix);
                }
            }
        }

    }
}
