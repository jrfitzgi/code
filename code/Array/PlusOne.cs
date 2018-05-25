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
        https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/559/
        Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
        The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.
        You may assume the integer does not contain any leading zero, except the number 0 itself.
        */

        public void PlusOne()
        {
            List<int> nums = new List<int>() { 1 };
            PrintArray(nums.ToArray());
            int[] x = PlusOne(nums.ToArray());
            PrintArray(x);
        }

        public int[] PlusOne(int[] digits)
        {
            int[] newDigits = new int[digits.Length];

            bool addOne = true;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9 && addOne)
                {
                    digits[i] = digits[i] + 1;
                    addOne = false;
                }
                else if(digits[i] == 9 && addOne)
                {
                    digits[i] = 0;
                    addOne = true;
                }
                else
                {
                    return digits;
                }
            }

            if (addOne)
            {
                // The input array was all 9's
                newDigits = new int[digits.Length + 1];
                newDigits[0] = 1;
                return newDigits;
            }
            else
            {
                return digits;
            }
        }

    }
}
