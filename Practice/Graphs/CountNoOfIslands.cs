using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Graphs
{
    class CountNoOfIslands
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[4,5] { {1, 1, 0, 0, 0 }, 
                                         {1, 1, 0, 0, 0 }, 
                                         {0, 0, 1, 0, 0 }, 
                                         {0, 0, 0, 1, 1 } 
                                       };
            Console.WriteLine(CountIslands(grid, 4, 5));

            grid = new int[4, 5] { {1, 1, 0, 0, 0 },
                                         {1, 1, 0, 0, 0 },
                                         {0, 0, 1, 0, 0 },
                                         {0, 0, 0, 1, 1 }
                                       };

            Console.WriteLine(CountIslandsV2(grid, 4, 5));
        }

        private static int CountIslandsV2(int[,] grid, int rows, int cols)
        {
            if (grid == null || grid.Length == 0) return 0;

            var visited = new Dictionary<string, bool>();
            int count = 0;
            for(int i=0; i< rows; i++)
            {
                for(int j = 0; j<cols;j++)
                {
                    if(grid[i,j] == 1)
                    {
                        if(PerformDFS(grid, i, j, rows, cols, visited) == true)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        private static bool PerformDFS(int[,] grid, int i, int j, int rows, int cols, Dictionary<string, bool> visited)
        {
            if (i < 0 || i >= rows || j < 0 || j >= cols || visited.ContainsKey(string.Format("{0},{1}", i, j))) return false;

            if (grid[i, j] == 0) return false;

            visited.Add(string.Format("{0},{1}", i, j), true);

            PerformDFS(grid, i - 1, j, rows, cols, visited);
            PerformDFS(grid, i + 1, j, rows, cols, visited);
            PerformDFS(grid, i, j - 1, rows, cols, visited);
            PerformDFS(grid, i, j + 1, rows, cols, visited);

            return true;
        }

        private static int CountIslands(int[,] grid, int rows, int cols)
        {
            if (grid == null || grid.Length == 0) return 0;

            int count = 0;
            for(int i=0; i<rows;i++)
            {
                for(int j=0; j<cols; j++)
                {
                    if(grid[i,j] == 1)
                    {
                        count += DFS(grid, i, j);
                    }
                }
            }
            return count;
        }

        private static int DFS(int[,] grid, int i, int j)
        {
            if (i < 0 || i > 3 || j < 0 || j > 4 || grid[i, j] == 0 || grid[i,j] == 2)
                return 0;

            grid[i, j] = 2; // any number to mark cell as visited
            DFS(grid, i - 1, j);
            DFS(grid, i + 1, j);
            DFS(grid, i, j - 1);
            DFS(grid, i, j + 1);
            return 1;
        }
    }
}
