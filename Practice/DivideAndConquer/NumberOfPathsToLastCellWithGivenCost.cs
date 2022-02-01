using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DivideAndConquer
{
    class NumberOfPathsToLastCellWithGivenCost
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,] { {4, 7, 1, 6 },
                                      {5, 7, 3, 9 },
                                      {3, 2, 1, 2 },
                                      {7, 1, 6, 3 } };

            int cost = 25;
            Console.WriteLine(NoOfPaths(arr, cost, 0, 0));
        }

        private static int NoOfPaths(int[,] arr, int cost, int row, int col)
        {
            if (cost < 0) return 0;
            if (row > 3 || col > 3) return 0;

            if(row == 3 && col == 3)
            {
                return (arr[row, col] - cost) == 0 ? 1 : 0;
            }

            int path1 = NoOfPaths(arr, cost-arr[row, col], row + 1, col);
            int path2 = NoOfPaths(arr, cost - arr[row, col], row, col+1);
            return path1 + path2;
        }
    }
}
