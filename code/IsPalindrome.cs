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
        Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        Note: For the purpose of this problem, we define empty string as valid palindrome.
        https://leetcode.com/problems/valid-palindrome/description/
        */

        public bool IsPalindrome(string s)
        {
            if (s == null) return false;
            if (s.Length == 0) return true;

            // pointers running toward each other
            int i1 = 0;
            int i2 = s.Length - 1;

            while (true)
            {
                // move i1 to next alphanumeric char
                while (!IsAlphaNumeric(s[i1]) && i1 < i2)
                {
                    i1++;
                }

                // move i2 to next alphanumeric char
                while (!IsAlphaNumeric(s[i2]) && i2 > i1)
                {
                    i2--;
                }

                if (i1 >= i2) return true;

                if (Char.ToLower(s[i1]) == Char.ToLower(s[i2]))
                {
                    i1++;
                    i2--;
                }
                else
                {
                    return false;
                }
            }


        }

        private static bool IsAlphaNumeric(char c)
        {
            return ((c >= 65 && c <= 90) || (c >= 97 && c <= 122) || (c >= 48 && c <= 57));
        }
    }
}
