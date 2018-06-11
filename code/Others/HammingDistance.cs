using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    // The Hamming distance between two integers is the number of positions at which the corresponding bits are different.
    // Given two integers x and y, calculate the Hamming distance.
    // Note: 0 ≤ x, y< 231.
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/99/others/762/

    public partial class Solution
    {
        public int HammingDistance(int x, int y)
        {

            int hammingDistance = 0;

            int xor = x ^ y;

            for (int i = 0; i < 31; i++) // ignore the sign bit
            {
                if (xor % 2 == 1)
                {
                    hammingDistance++;
                }

                xor = xor >> 1;
            }

            return hammingDistance;

        }
    }
}
