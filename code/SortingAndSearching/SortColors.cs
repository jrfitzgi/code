using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.SortingAndSearching.SortColors
{
    /*
    Given an array with n objects colored red, white or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white and blue.

    Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

    Note: You are not suppose to use the library's sort function for this problem.

    Example:

    Input: [2,0,2,1,1,0]
    Output: [0,0,1,1,2,2]
    Follow up:

    A rather straight forward solution is a two-pass algorithm using counting sort.
    First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.
    Could you come up with a one-pass algorithm using only constant space?

    https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/798/
    */

    public class Solution
    {
        public void SortColors(int[] nums)
        {
            if (nums == null || nums.Count() <= 1) { return; }

            int p0 = -1; // last element in the 0 group
            int p1 = -1; // last element in the 1 group

            for (int i = 0; i < nums.Count(); i++)
            {
                if (nums[i] == 0) // red: move to end of red group
                {
                    p0++;
                    if (p0 >= nums.Count()) { break; }
                    Swap(i, p0, nums);
                }

                if (nums[i] == 1) // white: move to end of white group
                {
                    if (p1 == -1)
                    {
                        p1 = p0;
                    }

                    p1++;
                    if (p1 >= nums.Count()) { break; }
                    Swap(i, p1, nums);
                }

            }

        }

        private void Swap(int i, int j, int[] nums)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
