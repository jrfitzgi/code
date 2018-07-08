using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.SortingAndSearching.SearchRange
{
    /*
    Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.

    Your algorithm's runtime complexity must be in the order of O(log n).


    If the target is not found in the array, return [-1, -1].


    Example 1:


    Input: nums = [5, 7, 7, 8, 8, 10], target = 8
    Output: [3,4]
    Example 2:


    Input: nums = [5, 7, 7, 8, 8, 10], target = 6
    Output: [-1,-1]

    https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/802/

    */
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[2] { -1, -1 };

            if (nums == null || nums.Count() == 0) { return result; }

            result = Helper(nums, target, 0, nums.Count() - 1);

            return result;
        }

        private int[] Helper(int[] nums, int target, int start, int end)
        {
            int[] result = new int[2] { -1, -1 };

            if (start == end)
            {
                if (nums[start] == target)
                {
                    result[0] = start;
                    result[1] = start;
                }

                return result;
            }

            int mid = (start + end) / 2;

            int[] left = Helper(nums, target, start, mid);
            int[] right = Helper(nums, target, mid + 1, end);

            if (left[0] != -1) { result[0] = left[0]; }
            else if (right[0] != -1) { result[0] = right[0]; }

            if (right[1] != -1) { result[1] = right[1]; }
            else if (left[1] != -1) { result[1] = left[1]; }

            return result;
        }
    }
}
