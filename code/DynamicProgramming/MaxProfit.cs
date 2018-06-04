using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.DynamicProgramming
{
    /*
    Say you have an array for which the ith element is the price of a given stock on day i.
    If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.
    Note that you cannot sell a stock before you buy one.     
    https://leetcode.com/explore/interview/card/top-interview-questions-easy/97/dynamic-programming/572/
    */

    public partial class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null) return 0;
            if (prices.Length <= 1) return 0;

            int lowestPrice = prices[0];
            int maxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                int thisProfit = prices[i] - lowestPrice;
                if (thisProfit > maxProfit)
                {
                    maxProfit = thisProfit;
                }

                if (prices[i] < lowestPrice)
                {
                    lowestPrice = prices[i];
                }
            }

            return maxProfit;
        }
    }
}
