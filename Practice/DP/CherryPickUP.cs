using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class CherryPickUP
    {
        static void Main(string[] args)
        {
            // Two user starts from 0,0 and 0,m-1. They need to reach bottom row with max path
            const int n = 3;
            const int m = 4;
            int[,] grid = new int[n, m] { {2, 3, 1, 2 }, {3, 4, 2, 2 }, {5, 6, 3, 5 } };
            Console.WriteLine(MaxPathSumCherry(0, 0, m - 1, grid));
        }

        private static int MaxPathSumCherry(int i, int j1, int j2, int[,] grid)
        {
            if (j1 < 0 || j1 > 3 || j2 < 0 || j2 > 3) return -1000000;
            if(i == 2)
            {
                if (j1 == j2)
                { 
                    return grid[2, j1]; 
                }
                else
                {
                    return grid[2, j1] + grid[2, j2];
                }
            }

            int maxi = 0;
            for (int diff1 = -1;diff1 <=1;diff1++)
            {
                for(int diff2 = -1; diff2<=1;diff2++)
                {
                    if (j1 == j2)
                    {
                        maxi = Math.Max(maxi, grid[i, j1] + MaxPathSumCherry(i + 1, j1 + diff1, j2 + diff2, grid));
                    }
                    else
                    {
                        maxi = Math.Max(maxi, grid[i, j1] + grid[i, j2] + MaxPathSumCherry(i + 1, j1 + diff1, j2 + diff2, grid));
                    }
                        
                }
            }

            return maxi;
        }
    }
}
