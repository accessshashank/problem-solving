using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class MaxPathSumVariableStartEndPoints
    {
        static void Main(string[] args)
        {
            // user can move from any cell in first row to any cell in last row, thus calculate max sum
            const int n = 4;
            const int m = 4;
            int[,] grid = new int[n, m] { {1, 2, 10, 4 }, {100, 3, 2, 1 }, {1, 1, 20, 2 }, {1, 2, 2, 1 } };
            int max = -100000;
            for(int j = 0; j<m;j++)
            {
                max = Math.Max(max, MaxSum(n - 1, j, grid));
            }

            Console.WriteLine(max);

            int[,] dp = new int[m, n] { { -1, -1, -1, -1 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 } };

            max = -100000;
            for (int j = 0; j < m; j++)
            {
                max = Math.Max(max, MaxSumTopDown(n - 1, j, grid, dp));
            }

            Console.WriteLine(max);

            dp = new int[m, n] { { -1, -1, -1, -1 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 } };

            Console.WriteLine(MaxSumBottomUp(grid, dp));
        }

        private static int MaxSumBottomUp(int[,] grid, int[,] dp)
        {
            dp[0, 0] = grid[0, 0];
            dp[0, 1] = grid[0, 1];
            dp[0, 2] = grid[0, 2];
            dp[0, 3] = grid[0, 3];

            for(int i=1; i<4;i++)
            {
                for(int j=0;j <4;j++)
                {
                    int st = -100000;
                    int ld = -1000000;
                    int rd = -1000000;

                    st = grid[i, j] + dp[i - 1, j];
                    if(j > 0)
                    ld = grid[i, j] + dp[i - 1, j - 1];
                    if(j < 3)
                    rd = grid[i, j] + dp[i - 1, j + 1];
                    dp[i, j] = Math.Max(st, Math.Max(ld, rd));
                }
            }

            int maxi = dp[3, 0];
            for(int j=1; j<4;j++)
            {
                maxi = Math.Max(maxi, dp[3, j]);
            }
            return maxi;
        }

        private static int MaxSumTopDown(int i, int j, int[,] grid, int[,] dp)
        {
            if (j < 0 || j >= 4) return -100000;
            if (i == 0) return grid[i, j];

            if (dp[i, j] != -1) return dp[i, j];

            int st = grid[i, j] + MaxSumTopDown(i - 1, j, grid, dp);
            int ld = grid[i, j] + MaxSumTopDown(i - 1, j - 1, grid, dp);
            int rd = grid[i, j] + MaxSumTopDown(i - 1, j + 1, grid, dp);

            dp[i,j] = Math.Max(st, Math.Max(ld, rd));
            return dp[i, j];
        }

        private static int MaxSum(int i, int j, int[,] grid)
        {
            if (j < 0 || j >= 4) return -100000;
            if (i == 0) return grid[i, j];

           

            int st = grid[i, j] + MaxSum(i - 1, j, grid);
            int ld = grid[i, j] + MaxSum(i - 1, j - 1, grid);
            int rd = grid[i, j] + MaxSum(i - 1, j + 1, grid);

            return Math.Max(st, Math.Max(ld, rd));
        }
    }
}
