using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Backtracking.GenerateParenthesis
{

    //Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

    //For example, given n = 3, a solution set is:
    //[
    //  "((()))",
    //  "(()())",
    //  "(())()",
    //  "()(())",
    //  "()()()"
    //]

    //https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/794/

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> results = new List<string>();
            Helper(results, String.Empty, n, 0, 0);

            return results;
        }

        private void Helper(List<string> results, string current, int n, int opened, int closed)
        {
            if (current.Length == n * 2)
            {
                results.Add(current);
                return;
            }

            if (opened < n)
            {
                Helper(results, current + "(", n, opened + 1, closed);
            }

            if (closed < opened)
            {
                Helper(results, current + ")", n, opened, closed + 1);
            }
        }

    }
}
