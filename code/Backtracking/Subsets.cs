using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Backtracking.Subsets
{
    /*
    Given a set of distinct integers, nums, return all possible subsets (the power set).

    Note: The solution set must not contain duplicate subsets.

    Example:

    Input: nums = [1,2,3]
    Output:
    [
      [3],
      [1],
      [2],
      [1,2,3],
      [1,3],
      [2,3],
      [1,2],
      []
    ]
    */

    // https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/796/

    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();
            if (nums == null) { return results; }

            results.Add(new List<int> { });

            for (int i = 0; i < nums.Count(); i++)
            {
                IList<int> cur = new List<int> { nums[i] };
                Helper(results, cur, i + 1, nums);
            }


            return results;
        }

        private void Helper(IList<IList<int>> results, IList<int> cur, int start, int[] nums)
        {
            results.Add(cur);

            for (int i = start; i < nums.Count(); i++)
            {
                List<int> newCur = new List<int>(cur);
                newCur.Add(nums[i]);
                Helper(results, newCur, i + 1, nums);
            }
        }

    }
}
