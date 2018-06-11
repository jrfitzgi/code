using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    // Write a function that takes an unsigned integer and returns the number of '1' bits it has (also known as the Hamming weight).
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/99/others/565/

    public partial class Solution
    {
        public int HammingWeight(uint n)
        {

            int hammingWeight = 0;

            for (int i = 0; i < 32; i++)
            {
                if (n % 2 == 1) { hammingWeight++; }

                n = n >> 1;
            }

            return hammingWeight;

        }
    }
}
