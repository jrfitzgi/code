using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    /*
    Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    An input string is valid if:
    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.
    Note that an empty string is also considered valid.
    https://leetcode.com/explore/interview/card/top-interview-questions-easy/99/others/721/
    */

    public partial class Solution
    {
        public bool ValidParentheses(string s)
        {

            Stack<char> open = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    open.Push(s[i]);
                }
                else
                {
                    if (open.Count() == 0) { return false; }

                    int popped = open.Pop();

                    if (popped == '(' && s[i] != ')')
                    {
                        return false;
                    }
                    else if (popped == '[' && s[i] != ']')
                    {
                        return false;
                    }
                    else if (popped == '{' && s[i] != '}')
                    {
                        return false;
                    }
                }


            }

            if (open.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
