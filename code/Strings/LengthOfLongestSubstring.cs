using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Strings
{
    /*
    Given a string, find the length of the longest substring without repeating characters.
    Examples:
    Given "abcabcbb", the answer is "abc", which the length is 3.
    Given "bbbbb", the answer is "b", with the length of 1.
    Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
    https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/779/
    */

    public partial class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null) { return 0; }

            Dictionary<char, int> dict = new Dictionary<char, int>();

            int longest = 0;

            int j = 0; // follower
            for (int i = 0; i < s.Length; i++)
            {

                if (dict.ContainsKey(s[i])) // found a repeated char
                {
                    j = Math.Max(j, dict[s[i]] + 1);
                    dict[s[i]] = i;
                }
                else
                {
                    dict.Add(s[i], i);
                }


                longest = Math.Max(longest, i - j + 1);

            }


            return longest;
        }
    }
}
