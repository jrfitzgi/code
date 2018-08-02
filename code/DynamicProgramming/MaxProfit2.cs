using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.DynamicProgramming.MaxProfit2
{
    /*
    Say you have an array for which the ith element is the price of a given stock on day i.

    Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:

    You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
    After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)

    https://leetcode.com/explore/interview/card/top-interview-questions-hard/121/dynamic-programming/862

    */


    public class Solution
    {

        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length < 2) { return 0; }

            int n = prices.Length;
            int[] s0 = new int[n];
            int[] s1 = new int[n];
            int[] s2 = new int[n];

            s0[0] = 0;
            s1[0] = -prices[0];
            s2[0] = int.MinValue;

            for (int i = 1; i < n; i++)
            {
                s0[i] = Math.Max(s0[i - 1], s2[i - 1]);
                s1[i] = Math.Max(s0[i - 1] - prices[i], s1[i - 1]);
                s2[i] = s1[i - 1] + prices[i];
            }

            return Math.Max(s0[n - 1], s2[n - 1]);
        }
    }
}
