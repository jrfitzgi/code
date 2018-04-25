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
        https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/549/
        Given a non-empty array of integers, every element appears twice except for one. Find that single one.
        Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
        */

        public void SingleNumber()
        {
            List<int> nums = new List<int>() { 4, 1, 2, 1, 2 };
            SingleNumber(nums.ToArray());
        }

        public int SingleNumber(int[] nums)
        {
            PrintArray(nums);

            // [4,1,2,1,2]

            return 0;

        }

    }
}
