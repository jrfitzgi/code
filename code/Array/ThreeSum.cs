using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Arrays.ThreeSum
{
    // https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/776/

    public class Solution
    {
        public static void Run()
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            Solution s = new Solution();
            var result = s.ThreeSum(nums);

        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();

            if (nums == null || nums.Length < 3) { return results; }

            System.Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                TwoSums(results, nums, i);
            }

            return results;

        }

        private void TwoSums(IList<IList<int>> results, int[] nums, int numIndex)
        {
            int target = 0 - nums[numIndex];

            Dictionary<int, int> hs = new Dictionary<int, int>(); // (num,count)
            for (int i = 0; i < nums.Length; i++) // create a hashtable, excluding 'skip'
            {
                if (i == numIndex) { continue; }

                int num = nums[i];
                if (hs.ContainsKey(num)) { hs[num]++; }
                else { hs.Add(num, 1); }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == numIndex) { continue; }

                int num = nums[i];
                int complement = target - num;

                if (hs.ContainsKey(complement))
                {
                    if (complement == num && hs[complement] < 2) // need at least 2 instances
                    {
                        continue;
                    }

                    // Found a pair
                    List<int> result = new List<int> { nums[numIndex], num, complement };
                    result.Sort();
                    if (results.Count > 0)
                    {
                        IList<int> priorResult = results.Last();
                        if (priorResult[0] == result[0] && priorResult[1] == result[1] && priorResult[2] == result[2])
                        {
                            continue;
                        }
                    }

                    results.Add(result);
                }

            }
        }
    }
}
