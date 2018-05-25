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
        Write a function that takes a string as input and returns the string reversed.

        Example:
        Given s = "hello", return "olleh".

        https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/879/

        */

        public string ReverseString(string s)
        {
            if (s == null) return s;

            char[] sArray = s.ToCharArray();
            int n = sArray.Length;
            int n2 = n / 2;

            int j = n - 1;
            for (int i = 0; i < n2; i++)
            {

                sArray[i] = sArray[j];
                sArray[j] = s[i];
                j--;
            }

            return new String(sArray);

        }
    }
}
