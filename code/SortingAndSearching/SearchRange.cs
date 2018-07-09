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

            result[0] = FindLeft(nums, target);
            if (result[0] == -1) { return result; }
            result[1] = FindRight(nums, target);

            return result;
        }

        private int FindLeft(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Count() - 1;


            while (start < end)
            {
                int mid = (start + end) / 2;

                if (target <= nums[mid])
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }

            if (nums[start] != target) { return -1; }
            else { return start; }
        }

        private int FindRight(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Count() - 1;


            while (start < end)
            {
                int mid = (start + end) / 2 + 1;

                if (target < nums[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid;
                }
            }

            if (nums[start] != target) { return -1; }
            else { return start; }
        }
    }
}
