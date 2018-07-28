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
        https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/549/
        Given a non-empty array of integers, every element appears twice except for one. Find that single one.
        Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
        */

        public void SingleNumber()
        {
            List<int> nums = new List<int>() { 4, 1, 2, 1, 2 };
            int x = SingleNumber(nums.ToArray());
            Console.WriteLine(x);
        }

        public int SingleNumber(int[] nums)
        {
            // XOR the same number and get 0

            for (int i=1; i<nums.Length; i++)
            {
                nums[0] ^= nums[i];
            }

            return nums[0];
        }

            public int SingleNumber_Naive(int[] nums)
        {
            //PrintArray(nums);

            // [4,1,2,1,2]

            int[,] tracking = new int[nums.Length, 2];

            // go through the array and find each pair
            for (int i = 0; i < nums.Length; i++)
            {
                bool foundMatch = false;
                for (int j = 0; j < tracking.GetLength(0); j++)
                {
                    if (tracking[j, 1] == 1 && tracking[j, 0] == nums[i])
                    {
                        // found a match
                        foundMatch = true;
                        tracking[j, 1] = 2; // this means a pair was found
                    }
                }

                if (!foundMatch)
                {
                    // add it to the tracking array
                    tracking[i, 0] = nums[i];
                    tracking[i, 1] = 1; // this means one instance of the int was found
                }
            }

            // there should be only one unmatched int left
            int unmatched = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if(tracking[i,1] == 1)
                {
                    unmatched = tracking[i, 0];
                }
            }

            return unmatched;

        }

    }
}
