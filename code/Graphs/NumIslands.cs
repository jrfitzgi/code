using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Graphs.NumIslands
{
    // Given a 2d grid map of '1's (land) and '0's (water), count the number of islands.
    // An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
    // You may assume all four edges of the grid are all surrounded by water.

    // https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/792/

    public class Solution
    {
        public int NumIslands(char[,] grid)
        {
            if (grid == null) { return 0; }

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            if (rows == 0 && cols == 0) { return 0; }

            int numIslands = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r, c] == '1')
                    {
                        numIslands++;
                        TraverseIsland(grid, r, c);
                    }
                }
            }

            ResetGrid(grid);
            return numIslands;
        }

        private void TraverseIsland(char[,] grid, int r, int c)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            if (r < 0 || r > rows - 1 || c < 0 || c > cols - 1)
            {
                return;
            }

            if (grid[r, c] != '1')
            {
                return;
            }

            grid[r, c] = '2';

            TraverseIsland(grid, r - 1, c);
            TraverseIsland(grid, r + 1, c);
            TraverseIsland(grid, r, c - 1);
            TraverseIsland(grid, r, c + 1);


        }

        private void ResetGrid(char[,] grid)
        {

        }
    }
}
