using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.SortingAndSearching.BinarySearch
{
    class Solution
    {
        public static void Test()
        {
            int[] nums = new int[6] { 2, 4, 6, 6, 8, 10 };
            int target = 6;
            int result = Solution.BinarySearch_Iterative(nums, target);
            Console.WriteLine("Result: " + result);
        }

        public static int BinarySearch_Iterative(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) { return -1; }

            int lo = 0;
            int hi = nums.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2; // avoid integer overflow

                if (nums[mid] == target) { return mid; }

                if (target < nums[mid])
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

            return -1;
        }
    }
}
