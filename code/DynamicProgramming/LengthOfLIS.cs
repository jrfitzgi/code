using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.DynamicProgramming.LengthOfLIS
{
    /*
    Given an unsorted array of integers, find the length of longest increasing subsequence.

    Example:

    Input: [10,9,2,5,3,7,101,18]
    Output: 4 
    Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4. 
    Note:

    There may be more than one LIS combination, it is only necessary for you to return the length.
    Your algorithm should run in O(n2) complexity.
    Follow up: Could you improve it to O(n log n) time complexity?
    */

    public class Solution
    {
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0) { return 0; }

            // stores partial results
            int[,] results = new int[nums.Length, 2];

            // keeps track of LIS
            int LIS = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                results[i, 0] = num;
                results[i, 1] = 1;

                // scan results backwards looking for longest partial result that
                // this could be appended to
                int candidateIndex = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (results[j, 0] < num) // possible candidate
                    {
                        if (candidateIndex == -1 || results[j, 1] > results[candidateIndex, 1]) // best candidate so far
                        {
                            candidateIndex = j;
                        }
                    }
                }

                if (candidateIndex != -1)
                {
                    results[i, 1] = results[candidateIndex, 1] + 1;
                }

                if (results[i, 1] > LIS)
                {
                    LIS = results[i, 1];
                }
            }

            return LIS;

        }


    }
}
