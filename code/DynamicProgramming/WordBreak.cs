using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.DynamicProgramming.WordBreak
{
    /*
    Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

    Note:

    The same word in the dictionary may be reused multiple times in the segmentation.
    You may assume the dictionary does not contain duplicate words.
    Example 1:

    Input: s = "leetcode", wordDict = ["leet", "code"]
    Output: true
    Explanation: Return true because "leetcode" can be segmented as "leet code".
        
    https://leetcode.com/explore/interview/card/top-interview-questions-hard/121/dynamic-programming/864/
    */

    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            if (s == null || wordDict == null) { return false; }

            HashSet<string> wordDict2 = new HashSet<string>();
            for (int i = 0; i < wordDict.Count(); i++)
            {
                wordDict2.Add(wordDict[i]);
            }

            bool[] visited = new bool[s.Length];

            return WordBreakHelper(s, wordDict2, 0, visited);
        }

        private bool WordBreakHelper(string s, HashSet<string> wordDict, int startIndex, bool[] visited)
        {
            if (startIndex >= s.Length) { return true; }

            StringBuilder sb = new StringBuilder();

            for (int i = startIndex; i < s.Length; i++)
            {
                sb.Append(s[i]);

                string word = sb.ToString();

                if (wordDict.Contains(word) && !visited[i])
                {
                    visited[i] = true;

                    // branch off
                    if (WordBreakHelper(s, wordDict, i + 1, visited) == true) { return true; }

                }
            }

            return false;
        }
    }
}
