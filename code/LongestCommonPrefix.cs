using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    /*
    Write a function to find the longest common prefix string amongst an array of strings.
    If there is no common prefix, return an empty string "".
    https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/887/
    */

    public partial class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            if (strs.Length == 1) return strs[0];

            string prefix = "";

            // Go through each char in the first string
            for (int i = 0; i < strs[0].Length; i++)
            {
                // Go through each string in strs
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i > strs[j].Length - 1 || strs[0][i] != strs[j][i])
                    {
                        return prefix;
                    }
                }

                prefix += strs[0][i];
            }

            return prefix;

        }
    }
}
