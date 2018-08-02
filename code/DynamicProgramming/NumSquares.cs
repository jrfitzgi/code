using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.DynamicProgramming.NumSquares
{
    /*

    Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

    Example 1:

    Input: n = 12
    Output: 3 
    Explanation: 12 = 4 + 4 + 4.
    Example 2:

    Input: n = 13
    Output: 2
    Explanation: 13 = 4 + 9.

    https://leetcode.com/explore/interview/card/top-interview-questions-hard/121/dynamic-programming/863/

    */

    public class Solution
    {
        public static void Run()
        {
            Solution s = new Solution();
            int result = s.NumSquares(12);
            Console.WriteLine(result);
        }

        public int NumSquares(int n)
        {
            int[] squares = CalculateSquares(n);
            int[] visited = new int[n];

            return Helper(n, squares, visited);
        }

        private int Helper(int n, int[] squares, int[] visited)
        {
            if (visited[n - 1] > 0) { return visited[n-1]; }

            int overallMin = int.MaxValue - 1;

            for (int i = 0; i < squares.Length; i++)
            {
                int diff = n - squares[i];

                if (diff == 0)
                {
                    visited[n - 1] = 1;
                    return 1;
                }
                else if (diff < 0)
                {
                    continue;
                }
                else
                {
                    int min = Helper(diff, squares, visited);
                    if (min < overallMin) { overallMin = min; }
                }
            }

            visited[n - 1] = 1 + overallMin;
            return 1 + overallMin;
        }


        private int[] CalculateSquares(int n)
        {
            int sqrt = (int)Math.Sqrt(n);

            int[] squares = new int[sqrt];
            for (int i = 1; i <= squares.Length; i++)
            {
                squares[i - 1] = i * i;
            }

            return squares;
        }
    }
}
