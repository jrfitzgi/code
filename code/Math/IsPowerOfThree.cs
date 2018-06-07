using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    // Given an integer, write a function to determine if it is a power of three.

    // https://leetcode.com/submissions/detail/157794826/

    public partial class Solution
    {
        public bool IsPowerOfThree(int n)
        {

            int i = -1;
            while (true)
            {
                i++;

                if (n == Math.Pow(3, i))
                {
                    return true;
                }


                if (Math.Pow(3, i) > n || Math.Pow(3, i) <= 0)
                {
                    break;
                }
            }

            return false;
        }
    }
}
