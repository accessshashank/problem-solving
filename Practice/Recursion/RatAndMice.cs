using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class RatAndMice
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5245788#overview
            int n = 5;
            int m = 4;
            int[,] grid = new int[5, 4] {
            {0, -1, 0, 0 },
            {0, 0, 0, -1 },
            {-1, 0, -1, 0 },
            {-1, 0, 0, -1 },
            {-1, -1, 0, 0 }
            };

            grid[0, 0] = 1;
            Solve(grid, 0, 0);
        }

        private static void Solve(int[,] grid, int row, int col)
        {
            if(row == 4 && col == 3)
            {
                Display(grid);
                return;
            }

            /*
            if(row < 0 || row > 4 || col < 0 || col > 3)
            {
                return;
            }

            if(grid[row, col] == -1)
            {
                return;
            }

            grid[row, col] = 1;
            */
            if(col<=2 && grid[row, col+1] != -1 && grid[row, col+1] != 1)
            {
                grid[row, col + 1] = 1;
                Solve(grid, row, col + 1); // Move Right
                grid[row, col + 1] = 0;
            }
            
            if(row <=3 && grid[row+1, col] != -1 && grid[row+1, col] != 1)
            {
                grid[row + 1, col] = 1;
                Solve(grid, row + 1, col); // Move Down
                grid[row + 1, col] = 0;
            }
            
            if(col >0 && grid[row, col-1] != -1 && grid[row, col-1] != 1)
            {
                grid[row, col - 1] = 1;
                Solve(grid, row, col - 1); // Move Left
                grid[row, col - 1] = 0;
            }
           
            if(row >0 && grid[row-1, col] != -1 && grid[row-1, col] != 1)
            {
                grid[row - 1, col] = 1;
                Solve(grid, row - 1, col); // Move Up
                grid[row - 1, col] = 0;
            }
            
            //grid[row, col] = 0;
        }

        private static void Display(int[,] grid)
        {
            for(int i =0; i<= 4; i++)
            {
                for(int j=0; j<=3; j++)
                {
                    int val = grid[i, j] == -1 ? 0 : grid[i, j];
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
