using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Graphs
{
    class MinimumIslandSize
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[4, 5] { {1, 1, 0, 1, 1 },
                                         {1, 1, 0, 0, 1 },
                                         {0, 0, 0, 0, 0 },
                                         {0, 0, 0, 1, 1 }
                                       };

            Console.WriteLine(MinIsland(grid, 4, 5));
        }

        private static int MinIsland(int[,] grid, int rows, int cols)
        {
            if (grid == null || grid.Length == 0) return 0;

            var visited = new Dictionary<string, bool>();
            int min = int.MaxValue;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        int noOfIsland = PerformDFS(grid, i, j, rows, cols, visited);
                        if(noOfIsland > 0)
                        min = Math.Min(min, noOfIsland);
                    }
                }
            }
            return min;
        }

        private static int PerformDFS(int[,] grid, int i, int j, int rows, int cols, Dictionary<string, bool> visited)
        {
            if (i < 0 || i >= rows || j < 0 || j >= cols || visited.ContainsKey(string.Format("{0},{1}", i, j))) return 0;

            if (grid[i, j] == 0) return 0;

            int counter = 1;
            visited.Add(string.Format("{0},{1}", i, j), true);

            counter += PerformDFS(grid, i - 1, j, rows, cols, visited);
            counter += PerformDFS(grid, i + 1, j, rows, cols, visited);
            counter += PerformDFS(grid, i, j - 1, rows, cols, visited);
            counter += PerformDFS(grid, i, j + 1, rows, cols, visited);

            return counter;
        }
    }
}
