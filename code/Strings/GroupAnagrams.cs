using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Strings
{
    // Given an array of strings, group anagrams together.
    // https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/778/

    public partial class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                string key = SortString(str);

                if (dict.ContainsKey(key))
                {
                    dict[key].Add(str);
                }
                else
                {
                    dict.Add(key, new List<string> { str });
                }
            }

            IList<IList<string>> result = new List<IList<string>>();
            foreach (string key in dict.Keys)
            {
                result.Add(dict[key]);
            }

            return result;


        }

        public static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
