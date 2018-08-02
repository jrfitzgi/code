using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.SortingAndSearching.BinarySearch2
{
    class Solution
    {
        public static void Run()
        {
            int[] nums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Solution s = new Solution();

            for (int i=0; i < nums.Length; i++)
            {
                Console.WriteLine(s.BinarySearch(nums, i));
            }
        }

        public int BinarySearch(int[] nums, int target)
        {
            if (nums == null) { return -1; }

            int lo = 0;
            int hi = nums.Length-1;
            

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (nums[mid] >= target)
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            if (nums[lo] == target)
            {
                return nums[hi];
            }
            else
            {
                return -1;
            }
        }


    }
}
