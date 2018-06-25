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
            List<string> list = new List<string>();
            string cur = String.Empty;
            Backtrack(list, cur, 0, 0, n);
            return list;
        }

        private void Backtrack(List<string> list, string cur, int opened, int closed, int n)
        {
            // If this is a final answer, add it to the list and return
            if (cur.Length == n * 2)
            {
                list.Add(cur);
                return;
            }

            // add an open paren and recurse
            if (opened < n)
            {
                Backtrack(list, cur + "(", opened + 1, closed, n);
            }

            // add a closed paren and recurse
            if (closed < opened)
            {
                Backtrack(list, cur + ")", opened, closed + 1, n);
            }
        }
    }
}
