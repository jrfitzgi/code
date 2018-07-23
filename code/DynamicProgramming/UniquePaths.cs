using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.DynamicProgramming.UniquePaths
{
    /*
    A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

    The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

    How many possible unique paths are there?

    https://leetcode.com/explore/interview/card/top-interview-questions-medium/111/dynamic-programming/808/
    */

    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            int[] prev = new int[n];
            int[] cur = new int[n];

            // start at the finish and fill backwards
            for (int x = m - 1; x >= 0; x--)
            {
                for (int y = n - 1; y >= 0; y--)
                {
                    if (x == m - 1 || y == n - 1)
                    {
                        cur[y] = 1;
                    }
                    else
                    {
                        cur[y] = cur[y + 1] + prev[y];
                    }
                }

                prev = cur;
                cur = new int[n];

            }

            return prev[0];
        }


    }
}
