using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Arrays
{
    public partial class Solution
    {
        private void PrintArray(int[] array)
        {
            array.ToList().ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
        }

        private void PrintArray(int[,] array)
        {
            for (int i=0; i< array.GetLength(0); i++)
            {
                for (int j=0; j<array.GetLength(1); j++)
                {
                    Console.Write(array[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
