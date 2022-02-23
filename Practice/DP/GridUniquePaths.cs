using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class GridUniquePaths
    {
        static void Main(string[] args)
        {
            // user has to travel from m-1,n-1 to 0,0
            int m = 5;
            int n = 5;
            Console.WriteLine(UniquePaths(m-1, n-1));

            int[,] dp = new int[m, n];
            for(int i=0; i<m;i++)
            {
                for(int j=0; j<n;j++)
                {
                    dp[i, j] = -1;
                }
            }

            Console.WriteLine(UniquePathsTopDown(m - 1, n - 1, dp));

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j] = -1;
                }
            }

            Console.WriteLine(UniquePathsBottomUp(dp));
        }

        private static int UniquePathsBottomUp(int[,] dp)
        {
            for(int i=0; i<5;i++)
            {
                for(int j=0;j<5;j++)
                {
                    int up = 0;
                    int left = 0;
                    if (i == 0 && j == 0) { dp[i, j] = 1; }
                    else
                    {
                        if (i > 0) up = dp[i - 1, j];
                        if (j > 0) left = dp[i, j - 1];
                        dp[i, j] = up + left;
                    }
                }
            }
            
            return dp[4, 4];
        }

        private static int UniquePathsTopDown(int i, int j, int[,] dp)
        {
            if (i == 0 && j == 0) return 1;
            if (i < 0 || j < 0) return 0;

            if (dp[i, j] != -1) return dp[i, j];

            int up = UniquePathsTopDown(i - 1, j, dp);
            int left = UniquePathsTopDown(i, j - 1, dp);
            dp[i,j] = up + left;
            return dp[i, j];
        }

        private static int UniquePaths(int i, int j)
        {
            if (i == 0 && j == 0) return 1;
            if (i < 0 || j < 0) return 0;

            int up = UniquePaths(i - 1, j);
            int left = UniquePaths(i, j - 1);
            return up + left;
        }
    }
}
