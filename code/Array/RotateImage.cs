using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Arrays
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
            //int[,] matrix = new int[5, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
            int[,] matrix = new int[6, 6] { { 1, 2, 3, 4, 5, 6 }, { 7, 8, 9, 10, 11, 12 }, { 13, 14, 15, 16, 17, 18 }, { 19, 20, 21, 22, 23, 24 }, { 25, 26, 27, 28, 29, 30 }, { 31, 32, 33, 34, 35, 36 } };
            //int[,] matrix = new int[6, 6] { { 2, 29, 20, 26, 16, 28 }, { 12, 27, 9, 25, 13, 21 }, { 32, 33, 32, 2, 28, 14 }, { 13, 14, 32, 27, 22, 26 }, { 33, 1, 20, 7, 21, 7 }, { 4, 24, 1, 6, 32, 34 } };
            //int[,] matrix = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            //int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            PrintArray(matrix);
            RotateImage(matrix);
            Console.WriteLine();
            PrintArray(matrix);
        }

        public void RotateImage(int[,] matrix)
        {

            int n = matrix.GetLength(0);
            int maxIteration = (int)Math.Floor((double)n / 2);
            for (int i = 0; i < maxIteration; i++)
            {
                int r = i; // startRow
                int length = n - (2 * i);
                //Console.WriteLine("startrow(r) {0}, length {1}", r, length);
                for (int c = r; c < length - 1 + r; c++)
                {
                    int temp = matrix[0 + r, c + r];
                    matrix[0 + r, c + r] = matrix[length - c - 1 + r, 0 + r];
                    matrix[length - c - 1 + r, 0 + r] = matrix[length - 1 + r, length - c - 1 + r];
                    matrix[length - 1 + r, length - c - 1 + r] = matrix[c + r, length - 1 + r];
                    matrix[c + r, length - 1 + r] = temp;

                    Console.WriteLine("--");
                    PrintArray(matrix);
                }
            }
        }

    }
}
