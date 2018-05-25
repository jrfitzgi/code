using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    /*
    Implement strStr().
    Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
    https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/885/
    */

    public partial class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle == null || haystack == null) return -1;
            if (needle.Length == 0) return 0;

            // p1 searches for the start of a needle candidate
            for (int p1 = 0; p1 < haystack.Length; p1++)
            {
                if (haystack[p1] == needle[0])
                {
                    // possibly found a needle

                    if (p1 + needle.Length > haystack.Length)
                    {
                        return -1;
                    }

                    bool needleFound = true;
                    for (int p2 = 1; p2 < needle.Length; p2++)
                    {
                        // p2 scans from this point in the haystack
                        // start p2 at 1 since we know index 0 matches
                        if (haystack[p1 + p2] != needle[p2])
                        {
                            needleFound = false;
                            break;
                        }
                    }

                    if (needleFound)
                    {
                        return p1;
                    }
                }
            }

            return -1;

        }
    }
}
