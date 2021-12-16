using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class BinarySearchSorted2DArray
    {
        static void Main(string[] args)
        {
            // matrix is sorted row wise and column wise
            int[,] arr = new int[4, 4] {
            {10, 20, 30, 40 },
            {15, 25, 35, 45 },
            {28, 29, 37, 49 },
            {33, 34, 38, 50 }
            };

            var target = 15;

            Find(arr, target);
        }

        private static void Find(int[,] arr, int target)
        {
            int row = 0;
            int col = 3;

            while(row <= 3 && col >=0)
            {
                if(target == arr[row, col])
                {
                    Console.WriteLine("Target is at {0},{1}", row, col);
                    return;
                }
                else if(target < arr[row, col])
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }

            Console.WriteLine("Target not found");
        }
    }
}
