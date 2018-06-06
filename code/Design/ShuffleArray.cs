using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Design
{
    // Shuffle a set of numbers without duplicates
    // https://leetcode.com/problems/shuffle-an-array/description/

    //public class Solution
    //{

    //    public Solution(int[] nums)
    //    {
    //        this.nums = nums;
    //        r = new Random();
    //    }

    //    private int[] nums;
    //    private Random r;

    //    /** Resets the array to its original configuration and return it. */
    //    public int[] Reset()
    //    {
    //        return this.nums;
    //    }

    //    /** Returns a random shuffling of the array. */
    //    public int[] Shuffle()
    //    {
    //        if (this.nums == null || this.nums.Length <= 1) { return this.nums; }

    //        int[] shuffled = new int[nums.Length];
    //        for (int i = 0; i < nums.Length; i++)
    //        {
    //            shuffled[i] = nums[i];
    //        }

    //        for (int i = 0; i < nums.Length; i++)
    //        {
    //            int swapIndex = this.r.Next(i, nums.Length);
    //            int temp = shuffled[i];
    //            shuffled[i] = shuffled[swapIndex];
    //            shuffled[swapIndex] = temp;
    //        }

    //        return shuffled;
    //    }
    //}

    ///**
    // * Your Solution object will be instantiated and called as such:
    // * Solution obj = new Solution(nums);
    // * int[] param_1 = obj.Reset();
    // * int[] param_2 = obj.Shuffle();
    // */
}
