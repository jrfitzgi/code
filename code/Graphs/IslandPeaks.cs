using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Graphs.IslandPeaks
{
    // Given a 2d grid map of 0's (water) and positive integers (land). Connected positive integers
    // represents an island. The peak is the highest point on the island.

    // Part 1: You are given random coordinates that put you on one of the islands.
    // Return the highest point on the island.

    // Part 2: Given the entire map, find the median peak height of all the islands.

    public class Solution
    {
        public static void Test()
        {
            // Input
            //int[,] grid = new int[3, 3] { {0,0,0 }, {0,1,0 }, {0,0,0 } };
            //int[,] grid = new int[3, 3] { { 1, 3, 0 }, { 0, 0, 6 }, { 4, 2, 5 } };
            int[,] grid = new int[5, 3] { { 1, 3, 0 }, { 0, 0, 6 }, { 4, 2, 5 }, { 0, 0, 0 }, { 0, 5, 0 } };

            Solution s = new Solution();
            //Console.WriteLine(s.FindPeak(grid, 0, 1));
            //Console.WriteLine(s.FindPeak(grid, 1, 1));
            //Console.WriteLine(s.FindPeak(grid, 2, 0));

            Console.WriteLine(s.MedianPeak(grid));

        }

        public double MedianPeak(int[,] grid)
        {
            if (grid == null) { return 0; }

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            if (rows == 0 && cols == 0) { return 0; }

            List<int> peaks = new List<int>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r, c] >= 1)
                    {
                        int peak = FindPeak(grid, r, c);
                        peaks.Add(peak);
                    }
                }
            }

            peaks.Sort();
            int mid = peaks.Count / 2;
            double median = peaks[mid];
            if (peaks.Count > 0 && peaks.Count % 2 == 0)
            {
                median = (median + peaks[mid - 1]) / 2;
            }

            return median;
        }

        public int FindPeak(int[,] grid, int r, int c)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            if (r < 0 || r > rows - 1 || c < 0 || c > cols - 1)
            {
                return 0;
            }

            if (grid[r, c] <= 0)
            {
                return 0;
            }

            List<int> heights = new List<int> { grid[r, c] };
            grid[r, c] = -1; // -1 means visitied

            heights.Add(FindPeak(grid, r - 1, c));
            heights.Add(FindPeak(grid, r + 1, c));
            heights.Add(FindPeak(grid, r, c - 1));
            heights.Add(FindPeak(grid, r, c + 1));

            int peak = heights.Max();
            return peak;
        }

    }
}
