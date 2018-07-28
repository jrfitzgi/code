using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Arrays
{
    public partial class Solution
    {
        public int RemoveDuplicates_Unsorted(int[] nums)
        {
            Console.Write("Array is: ");
            this.PrintArray(nums);

            int numDupes = 0;

            for (int i = 0; i < nums.Length - numDupes; i++)
            {
                
                Console.WriteLine("Inspecting index {0} value {1}", i, nums[i]);

                for (int j = 0; j < nums.Length - numDupes; j++)
                {
                    if (j== i)
                    {
                        continue;
                    }

                    if (nums[j] == nums[i])
                    {
                        Console.WriteLine("Found dupe value {0} at index {1}", nums[i], j);

                        // Overwrite the current dupe with a value from near the end that hasn't been swapped in
                        nums[j] = nums[nums.Length - 1 - numDupes];
                        Console.WriteLine("Swap {0} from index {1} into index {2}", nums[j], nums.Length - 1 - numDupes, j);

                        numDupes++;
                        Console.WriteLine("numDupes incremented to {0}", numDupes);

                        Console.Write("Array is: ");
                        this.PrintArray(nums);
                    }
                }
            }

            Console.Write("Array is: ");
            this.PrintArray(nums);

            return nums.Length - numDupes;
        }
    }



}
