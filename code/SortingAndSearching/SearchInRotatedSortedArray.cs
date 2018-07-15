using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.SortingAndSearching.SearchInRotatedSortedArray
{
    /*
    Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

    (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

    You are given a target value to search. If found in the array return its index, otherwise return -1.

    You may assume no duplicate exists in the array.

    Your algorithm's runtime complexity must be in the order of O(log n).

    Example 1:

    Input: nums = [4,5,6,7,0,1,2], target = 0
    Output: 4
    Example 2:

    Input: nums = [4,5,6,7,0,1,2], target = 3
    Output: -1

    https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/804/

    */

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Count() == 0) { return -1; }

            int lo = 0;
            int hi = nums.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2; // avoid integer overflow

                if (nums[mid] == target) { return mid; }

                if (nums[lo] <= nums[mid]) // left is ordered
                {
                    if (inRange(lo, mid, target, nums))
                    {
                        // search left
                        hi = mid - 1;
                    }
                    else
                    {
                        // search right
                        lo = mid + 1;
                    }
                }
                else // right is ordered
                {
                    if (inRange(mid, hi, target, nums))
                    {
                        // search right
                        lo = mid + 1;
                    }
                    else
                    {
                        // search left
                        hi = mid - 1;
                    }
                }
            }

            return -1;

        }

        private bool inRange(int lo, int hi, int target, int[] nums)
        {
            return (nums[lo] <= target && target <= nums[hi]);
        }

    }
}
