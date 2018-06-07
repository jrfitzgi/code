using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace code
{
    // Count the number of prime numbers less than a non-negative number, n.
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/102/math/744/

    public partial class Solution
    {
        // Sieve of Eratosthenes
        public int CountPrimes(int n)
        {
            if (n <= 1) { return 0; }

            bool[] primes = new bool[n - 1]; // used to count primes under n
            primes[0] = true; // ignore 1
            int count = 0;

            // Steps:
            // -iterate through each int under n
            // -if marked false, then its prime. count it and mark it and its factors as true

            for (int i = 1; i < n; i++)
            {
                if (primes[i - 1] == false) // found a prime
                {
                    count++;
                    for (int j = 1; j <= (n - 1) / i; j++)
                    {
                        primes[(j * i) - 1] = true;
                    }
                }


            }

            return count;

        }

        public int CountPrimes_Array(int n)
        {
            if (n <= 1) { return 0; }

            List<int> primes = new List<int>();

            for (int i = 2; i < n; i++)
            {
                bool isPrime = true;
                for (int j = 0; j < primes.Count; j++)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    else if (primes[j] > (int)Math.Sqrt(i))
                    {
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(i);
                }
            }

            return primes.Count;
        }
    }
}
