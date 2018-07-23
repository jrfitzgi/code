using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.DynamicProgramming.CoinChange
{
    /*
    You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

    Example 1:

    Input: coins = [1, 2, 5], amount = 11
    Output: 3 
    Explanation: 11 = 5 + 5 + 1
    Example 2:

    Input: coins = [2], amount = 3
    Output: -1
    Note:
    You may assume that you have an infinite number of each kind of coin.

    https://leetcode.com/explore/interview/card/top-interview-questions-medium/111/dynamic-programming/809/
    */

    public class Solution
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (coins == null || coins.Length == 0) { return -1; }

            Array.Sort(coins);
            int[] cache = new int[amount];
            return Helper(coins, amount, cache);
        }

        private int Helper(int[] coins, int amount, int[] cache)
        {
            if (amount < 0) { return -1; }
            if (amount == 0) { return 0; }
            if (cache[amount - 1] != 0) { return cache[amount - 1]; }

            int min = -1;

            for (int i = coins.Length - 1; i >= 0; i--)
            {
                int result = Helper(coins, amount - coins[i], cache);

                if (result == -1) { continue; }

                if (min == -1 || result < min) { min = result; }
            }

            if (min == -1)
            {
                cache[amount - 1] = min;
            }
            else
            {
                cache[amount - 1] = min + 1;
            }

            return cache[amount - 1];
        }
    }
}
