using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Backtracking.Permutations
{
    // Given a collection of distinct integers, return all possible permutations.
    // https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/795/

    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {

            List<IList<int>> results = new List<IList<int>>();

            if (nums == null) { return results; }

            HelpPermute(results, nums.ToList(), new List<int>());
            return results;
        }

        private void HelpPermute(List<IList<int>> results, List<int> nums, List<int> cur)
        {
            if (nums.Count() == 0)
            {
                results.Add(cur);
                return;
            }

            for (int i = 0; i < nums.Count(); i++)
            {
                int num = nums[i];
                List<int> newCur = cur.Concat(new List<int> { num }).ToList();
                List<int> newNums = new List<int>(nums);
                newNums.Remove(num);
                HelpPermute(results, newNums, newCur);
            }

        }
    }
}
