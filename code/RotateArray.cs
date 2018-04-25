using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    public partial class Solution
    {
        // https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/646/
        // Rotate an array of n elements to the right by k steps.
        // For example, with n = 7 and k = 3, the array [1, 2, 3, 4, 5, 6, 7] is rotated to [5, 6, 7, 1, 2, 3, 4].

        public void Rotate()
        {
            List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            Rotate(nums.ToArray(), 3);
        }

        public void Rotate(int[] nums, int k)
        {
            //PrintArray(nums);

            int n = nums.Length;

            if (n == 0) { return; }
            k = k % n;
            if (k == 0) { return; }

            // Copy to another array
            int[] nums2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums2[(i + k) % n] = nums[i];
            }

            // This doesn't work once the method loses scope
            // I guess since nums loses scope but what it is pointing to does not
            // So, we need to copy back to nums
            //nums = nums2;

            for (int i = 0; i < n; i++)
            {
                nums[i] = nums2[i];
            }

            //PrintArray(nums);
        }

        public void Rotate_ConstantSpace(int[] nums, int k)
        {
            //PrintArray(nums);

            int n = nums.Length;

            if (n == 0) { return; }

            // shift everything k times
            k = k % n;
            for (int j = 0; j < k; j++)
            {
                int last = nums[n - 1];
                for (int i = n - 1; i > 0; i--)
                {
                    nums[i] = nums[i - 1];
                }
                nums[0] = last;
            }

            //PrintArray(nums);
        }

    }
}
