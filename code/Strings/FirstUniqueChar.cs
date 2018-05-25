using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Strings
{
    public partial class Solution
    {
        // Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.
        // https://leetcode.com/problems/first-unique-character-in-a-string/description/

        public int FirstUniqChar(string s)
        {

            Dictionary<char, int> count = new Dictionary<char, int>();
            //int unique = -1;
            // traverse in reverse so that the 'last' unique char we find is the first in the string
            //for (int i = s.Length - 1; i >= 0; i--)
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (!count.ContainsKey(ch))
                {
                    //unique = i;
                    count.Add(ch, 1);
                }
                else
                {
                    count[ch]++;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (count[ch] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
