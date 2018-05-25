using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    public partial class Solution
    {
        /*
        https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/546/
        Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        You may assume that each input would have exactly one solution, and you may not use the same element twice.
        */

        // NOTE: Best solution uses hashtable

        public void TwoSum()
        {
            List<int> nums = new List<int>() { 2, 5, 5, 11 };
            PrintArray(nums.ToArray());
            int[] x = TwoSum(nums.ToArray(), 10);
            PrintArray(x);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            // Make a copy of the array so we can sort it and look up original indices later
            int[] sortedNums = new int[nums.Length];
            Array.Copy(nums, sortedNums, nums.Length);
            Array.Sort(sortedNums);

            int operand1 = -1;
            int operand2 = -1;
            bool foundOperands = false;

            for (int i = 0; i < sortedNums.Length; i++)
            {
                for (int j = i + 1; j < sortedNums.Length; j++)
                {
                    if (i == j) { continue; }

                    if (sortedNums[i] + sortedNums[j] > target)
                    {
                        // since we sorted, don't keep looping
                        break;
                    }
                    else if (sortedNums[i] + sortedNums[j] == target)
                    {
                        operand1 = sortedNums[i];
                        operand2 = sortedNums[j];
                        foundOperands = true;
                        break;
                    }
                }

                if (foundOperands) { break; }
            }

            int[] operands = new int[2] { -1, -1 };

            // Find the original index of each operand
            for (int i = 0; i < nums.Length; i++)
            {
                if (operands[0] == -1 && nums[i] == operand1)
                {
                    operands[0] = i;
                }
                else if (operands[1] == -1 && nums[i] == operand2)
                {
                    operands[1] = i;
                }
            }

            return operands;
        }

    }
}
