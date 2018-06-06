using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    // Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/97/dynamic-programming/566/

    public partial class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            int max = dp[0];

            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = nums[i] + (dp[i - 1] > 0 ? dp[i - 1] : 0);
                max = Math.Max(dp[i], max);
            }

            return max;
        }
    }
}
