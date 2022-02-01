using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DivideAndConquer
{
    class MinCostToReachLastCellIn2DArray
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,] { {4, 7, 8, 6, 4 }, 
                                      {6, 7, 3, 9, 2 },
                                      {3, 8, 1, 2, 4 },
                                      {7, 1, 7, 3, 7 },
                                      {2, 9, 8, 9, 3 } };

            Console.WriteLine(MinCost(arr, 0, 0));
        }

        private static int MinCost(int[,] arr, int row, int col)
        {
            
            if(row == 4 && col == 4)
            {
                
                return arr[row, col];
            }

            if (row > 4 || col > 4) return 1000000; // i want this value to be sufficient large. Cant have int.MaxValue because it goes out of bounds of Int

            

            int c1 = arr[row, col] + MinCost(arr, row + 1, col);
            int c2 = arr[row, col] + MinCost(arr, row, col + 1);

            return Math.Min(c1, c2);

        }
    }
}
