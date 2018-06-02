using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    /*
    Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
    Note:
    The number of elements initialized in nums1 and nums2 are m and n respectively.
    You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.
    https://leetcode.com/explore/interview/card/top-interview-questions-easy/96/sorting-and-searching/587/
    */

    public partial class Solution
    {
        public void MergeSortedArray(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1 == null || nums2 == null) { return; }
            if (nums1.Length == 0 || n == 0) { return; }

            int p1 = m - 1; // start at last element of nums1
            int p2 = n - 1; // start at last element of nums2

            // put the largest int at the end of nums1 and keep shifting the numbers to the right
            for (int i = nums1.Length - 1; i >= 0; i--)
            {
                if (p2 < 0) { break; }

                if (p1 >= 0 && nums1[p1] > nums2[p2])
                {
                    nums1[i] = nums1[p1];
                    p1--;
                }
                else
                {
                    nums1[i] = nums2[p2];
                    p2--;
                }
            }

        }
    }
}
