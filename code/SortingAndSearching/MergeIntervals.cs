using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.SortingAndSearching.MergeIntervals
{
    /*
     
        Given a collection of intervals, merge all overlapping intervals.

        Example 1:

        Input: [[1,3],[2,6],[8,10],[15,18]]
        Output: [[1,6],[8,10],[15,18]]
        Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
        Example 2:

        Input: [[1,4],[4,5]]
        Output: [[1,5]]
        Explanation: Intervals [1,4] and [4,5] are considerred overlapping.

        https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/803/

    */


    // Definition for an interval.
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class Solution
    {
        // Note: better solution is to sort first then traverse list once

        public IList<Interval> Merge(IList<Interval> intervals)
        {
            List<Interval> results = new List<Interval>();
            if (intervals == null || intervals.Count() == 0) { return results; }

            for (int i = 0; i < intervals.Count(); i++)
            {
                bool merged = false;

                for (int j = i + 1; j < intervals.Count(); j++)
                {

                    if ((intervals[i].start >= intervals[j].start && intervals[i].start <= intervals[j].end)
                        || (intervals[j].start >= intervals[i].start && intervals[j].start <= intervals[i].end))
                    {
                        // merge
                        intervals[j].start = Math.Min(intervals[i].start, intervals[j].start);
                        intervals[j].end = Math.Max(intervals[i].end, intervals[j].end);
                        merged = true;
                        break;
                    }
                }

                if (!merged)
                {
                    results.Add(intervals[i]);
                }
            }

            return results;
        }
    }
}
