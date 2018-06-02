using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    /*
    You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.
    Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
    You are given an API bool isBadVersion(version) which will return whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.
    https://leetcode.com/explore/interview/card/top-interview-questions-easy/96/sorting-and-searching/774/
    */

    /* The isBadVersion API is defined in the parent class VersionControl.
          bool IsBadVersion(int version); */

    public partial class Solution //: VersionControl
    {
        private uint firstBad;

        public void FirstBadVersion()
        {
            firstBad = 1702766719;
            uint n = 2126753390;
            int result = FirstBadVersion((int)n);
            Console.WriteLine(result);
        }

        public bool IsBadVersion(int v)
        {
            return v >= firstBad;
        }
        public int FirstBadVersion(int n)
        {
            uint start = 1;
            uint end = (uint)n;

            while (true)
            {
                uint mid = (start + end) / 2;

                if (mid == n) { return n; } // maybe?
                if (end == 1) { return 1; }

                bool isMidBad = IsBadVersion((int)mid);
                bool isMid1Bad = IsBadVersion((int)mid + 1);

                if (!isMid1Bad) // If mid1 is good, mid doesn't matter. Search the right half.
                {
                    start = mid + 1;
                }
                else if (isMidBad) // both are bad. Search the left half.
                {
                    end = mid;
                }
                else
                {
                    return (int)mid + 1;
                }
            }

        }
    }
}
