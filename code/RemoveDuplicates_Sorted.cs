using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    public partial class Solution
    {
        // https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/

        public void RemoveDuplicates()
        {
            //int[] nums = new int[1] { 5 };
            int[] nums = new int[10] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //int[] nums = new int[0] { };
            //int[] nums = new int[4] { 1, 1, 2, 3 };
            //int[] nums = new int[7] { 1, 1, 2, 3, 4, 5, 5 };

            int result = RemoveDuplicates_Sorted(nums);
            Console.WriteLine("Length: " + result);
        }

        public int RemoveDuplicates(int[] nums)
        {
            // 1,2,2,3

            // i is the slow runner
            // j is the fast runner (to the end)

            if (nums.Length == 0) { return 0; }

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }

        public int RemoveDuplicates_Sorted(int[] nums)
        {
            //Console.Write("Array is: ");
            //this.PrintArray(nums);
            int numsLength = nums.Length;

            int numDupes = 0;

            for (int i = 0; i < numsLength - numDupes; i++)
            {
                //Console.WriteLine("Inspecting index {0} value {1}", i, nums[i]);

                for (int j = i + 1; j < numsLength - numDupes; j++)
                {
                    if (nums[j] == nums[i])
                    {
                        //Console.WriteLine("Found dupe value {0} at index {1}", nums[i], j);

                        // Shift everything left
                        for (int k = j; k < numsLength - numDupes - 1; k++)
                        {
                            nums[k] = nums[k + 1];
                            //Console.WriteLine("Shift {0} from index {1} into index {2}", nums[k + 1], k + 1, k);
                        }

                        numDupes++;
                        //Console.WriteLine("numDupes incremented to {0}", numDupes);

                        //Console.Write("Array is: ");
                        //this.PrintArray(nums);

                        j--;
                    }
                }
            }

            //Console.Write("Array is: ");
            //this.PrintArray(nums);

            return numsLength - numDupes;
        }
    }



}
