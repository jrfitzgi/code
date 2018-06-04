using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.DynamicProgramming
{
    /*
    You are climbing a stair case. It takes n steps to reach to the top.
    Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
    Note: Given n will be a positive integer.
    https://leetcode.com/explore/interview/card/top-interview-questions-easy/97/dynamic-programming/569/
    */

    public partial class Solution
    {
        // Could also be treated as Fibonacci. Then, we don't need O(n) space, just save prior 2 values.

        public int ClimbStairs(int n)
        {
            if (n <= 2) { return n; }

            int[] steps = new int[n];
            steps[0] = 1; // (1)
            steps[1] = 2; // (1,1),(2)

            for (int i = 2; i < n; i++)
            {
                steps[i] = steps[i - 1] + steps[i - 2];
            }

            return steps[n - 1];
        }
    }
}
