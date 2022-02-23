using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class MinPathSum
    {
        static void Main(string[] args)
        {
            int m = 3;
            int n = 3;
            int[,] arr = new int[,] { {10,8,2 },{10,5,100 },{1,1,2 } };

            Console.WriteLine(FindMin(m - 1, n - 1, arr));

            int[,] dp = new int[3,3];

            for(int i=0; i<3;i++)
            {
                for(int j=0; j<3;j++)
                {
                    dp[i, j] = -1;
                }
            }

            Console.WriteLine(FindMinTopDown(m - 1, n - 1, arr, dp));

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dp[i, j] = -1;
                }
            }

            Console.WriteLine(FindMinBottomUp(arr, dp));
        }

        private static int FindMinBottomUp(int[,] arr, int[,] dp)
        {
            for(int i=0; i<3;i++)
            {
                for(int j=0; j<3;j++)
                {
                    int up = 99999;
                    int left = 99999;

                    if (i == 0 && j == 0)
                    {
                        dp[0, 0] = arr[0, 0];
                    }
                    else
                    {
                        if (i > 0)
                            up = arr[i, j] + dp[i - 1, j];

                        if (j > 0)
                            left = arr[i, j] + dp[i, j - 1];

                        dp[i, j] = Math.Min(up, left);
                    }
                }
            }

            

            return dp[2, 2];
        }

        private static int FindMinTopDown(int i, int j, int[,] arr, int[,] dp)
        {
            if (i == 0 && j == 0) return arr[i, j];

            if (i < 0 || j < 0) return 99999;

            if (dp[i, j] != -1) return dp[i, j];

            int up = arr[i, j] + FindMinTopDown(i - 1, j, arr, dp);
            int left = arr[i, j] + FindMinTopDown(i, j - 1, arr, dp);

            dp[i,j] = Math.Min(up, left);

            return dp[i, j];
        }

        private static int FindMin(int i, int j, int[,] arr)
        {
            if (i == 0 && j == 0) return arr[i, j];

            if (i < 0 || j < 0) return 99999;

            int up = arr[i, j] + FindMin(i - 1, j, arr);
            int left = arr[i, j] + FindMin(i, j - 1, arr);

            return Math.Min(up, left);
        }
    }
}
