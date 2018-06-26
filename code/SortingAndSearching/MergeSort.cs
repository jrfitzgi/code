using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.SortingAndSearching.MergeSort
{
    class MergeSort
    {
        // Run some tests
        public static void Run()
        {
            //int[] input = new int[0] { };
            //int[] input = new int[1] { 1 };
            //int[] input = new int[7] { 1, 4, 6, 0, 5, 5, 3 };
            int[] input = new int[8] { 1, 4, 6, 0, 5, 5, 3, -5};
            //int[] input = new int[4] { 1, 4, 6, 0 };
            //int[] input = new int[4] { 1, 4, 6, 0 };

            MergeSort s = new MergeSort();
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
            if (length == 0) { return; }
            if (length == 1) { return; }

            int mid = (start + end) / 2;

            HelpSort(input, start, mid);
            HelpSort(input, mid + 1, end);

            int[] temp = new int[length];

            int left = start;
            int right = mid + 1;

            // Merge
            for (int i = 0; i < temp.Length; i++)
            {
                if (left > mid) // used up all the left side
                {
                    temp[i] = input[right];
                    right++;
                }
                else if (right > end) // used up right side
                {
                    temp[i] = input[left];
                    left++;
                }
                else if (input[left] <= input[right])
                {
                    temp[i] = input[left];
                    left++;
                }
                else
                {
                    temp[i] = input[right];
                    right++;
                }
            }

            // Copy from temp back to input
            for (int i = 0; i < temp.Length; i++)
            {
                input[i + start] = temp[i];
            }

        }
    }
}
