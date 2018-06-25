using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Backtracking.LetterCombinations
{
    //Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
    //A mapping of digit to letters(just like on the telephone buttons) is given below.Note that 1 does not map to any letters.

    //Example:
    //Input: "23"
    //Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
    //Note:
    //Although the above answer is in lexicographical order, your answer could be in any order you want.

    // https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/793/

    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            List<string> combos = new List<string>();

            if (digits == null || digits.Length == 0) { return combos; }

            combos.Add(String.Empty);
            List<string> newCombos;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                newCombos = new List<string>();

                foreach (string combo in combos)
                {
                    foreach (string letter in GetButtonLetters(digits[i] - '0'))
                    {
                        newCombos.Add(letter + combo);
                    }
                }

                combos = newCombos;
            }

            return combos;
        }

        private List<string> GetButtonLetters(int button)
        {
            switch (button)
            {
                case 2:
                    return new List<string> { "a", "b", "c" };
                case 3:
                    return new List<string> { "d", "e", "f" };
                case 4:
                    return new List<string> { "g", "h", "i" };
                case 5:
                    return new List<string> { "j", "k", "l" };
                case 6:
                    return new List<string> { "m", "n", "o" };
                case 7:
                    return new List<string> { "p", "q", "r", "s" };
                case 8:
                    return new List<string> { "t", "u", "v" };
                case 9:
                    return new List<string> { "w", "x", "y", "z" };
                default:
                    return new List<string>();
            }


        }
    }
}
