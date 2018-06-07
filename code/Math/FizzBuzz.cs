using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    // Write a program that outputs the string representation of numbers from 1 to n.
    // But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”. For numbers which are multiples of both three and five output “FizzBuzz”.
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/102/math/743/

    public partial class Solution
    {
        public IList<string> FizzBuzz(int n)
        {

            List<string> result = new List<string>();

            if (n <= 0) { return result; }

            int fizz = 3;
            int fizzCounter = 0;
            int buzz = 5;
            int buzzCounter = 0;

            for (int i = 1; i <= n; i++)
            {
                fizzCounter++;
                buzzCounter++;

                if (fizzCounter == fizz && buzzCounter == buzz)
                {
                    result.Add("FizzBuzz");
                    fizzCounter = 0;
                    buzzCounter = 0;
                }
                else if (fizzCounter == fizz)
                {
                    result.Add("Fizz");
                    fizzCounter = 0;
                }
                else if (buzzCounter == buzz)
                {
                    result.Add("Buzz");
                    buzzCounter = 0;
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result;


        }
    }
}
