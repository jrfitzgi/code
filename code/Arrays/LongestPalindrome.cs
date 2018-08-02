using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Arrays.LongestPalindrome
{
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            StringBuilder longest = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                StringBuilder result = GetPalindrome(s, i);
                if (result.Length > longest.Length)
                {
                    longest = result;
                }
            }

            return longest.ToString();
        }

        private StringBuilder GetPalindrome(string s, int mid)
        {
            StringBuilder odd = GetPalindrome_Odd(s, mid);
            StringBuilder even = GetPalindrome_Even(s, mid);

            if (odd.Length > even.Length) { return odd; }
            else { return even; }
        }

        private StringBuilder GetPalindrome_Odd(string s, int mid)
        {
            StringBuilder sb = new StringBuilder();

            // odd
            sb.Append(s[mid]);
            int start = mid - 1;
            int end = mid + 1;

            while (start >= 0 && end < s.Length)
            {
                if (s[start] != s[end])
                {
                    return sb;
                }

                sb.Insert(0, s[end]);
                sb.Append(s[end]);

                start--;
                end++;
            }

            return sb;
        }

        private StringBuilder GetPalindrome_Even(string s, int mid)
        {
            StringBuilder sb = new StringBuilder();

            // even
            int start = mid;
            int end = mid + 1;

            while (start >= 0 && end < s.Length)
            {
                if (s[start] != s[end])
                {
                    return sb;
                }

                sb.Insert(0, s[end]);
                sb.Append(s[end]);

                start--;
                end++;
            }

            return sb;

        }
    }
}
