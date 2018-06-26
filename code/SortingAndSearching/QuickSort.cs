using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.SortingAndSearching.QuickSort
{
    class QuickSort
    {
        // Run some tests
        public static void Run()
        {
            //int[] input = new int[0] { };
            //int[] input = new int[1] { 1 };
            //int[] input = new int[7] { 1, 4, 6, 0, 5, 5, 3 };
            int[] input = new int[8] { 1, 4, 6, 0, 5, 5, 3, -5 };
            //int[] input = new int[4] { 1, 4, 6, 0 };
            //int[] input = new int[4] { 1, 4, 6, 0 };

            QuickSort s = new QuickSort();
            s.Sort(input);

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i] + ", ");
            }

            Console.WriteLine();
        }

        public void Sort(int[] input)
        {
            if (input == null) { return; }

            HelpSort(input, 0, input.Length - 1);
        }

        private void HelpSort(int[] input, int start, int end)
        {
            int length = end - start + 1;
            if (length <= 1) { return; }

            int partitionIndex = Partition(input, start, end);

            HelpSort(input, start, partitionIndex - 1);
            HelpSort(input, partitionIndex + 1, end);

        }

        private int Partition(int[] input, int start, int end)
        {
            int pivot = input[start];

            int low = start;
            for (int j = start + 1; j <= end; j++)
            {
                if (input[j] <= pivot)
                {
                    low++;
                    Swap(input, low, j);
                }
            }

            Swap(input, start, low);

            return low;
        }

        private void Swap(int[] input, int i, int j)
        {
            int temp = input[i];
            input[i] = input[j];
            input[j] = temp;
        }
    }
}
