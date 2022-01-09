using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class StaircaseSearch2DArray
    {
        static void Main(string[] args)
        {
            // 2D array is sorted row wise and column wise both then only this algo applies
            int[,] arr = new int [4,4] { {10, 20, 30, 40 },
                                         {15, 25, 35, 45 },
                                         {27, 29, 37, 48 },
                                         {32, 33,39, 50 } };

            int search = 100;
            Search(arr, search);
        }

        private static void Search(int[,] arr, int searchNum)
        {
            int searchRowIndex = 0;
            int searchColIndex = 3;
            while(searchColIndex >=0 && searchRowIndex <= 3)
            {
                var element = arr[searchRowIndex, searchColIndex];
                if (element == searchNum)
                {
                    Console.WriteLine("Number present at index {0},{1}", searchRowIndex, searchColIndex);
                    return;
                }

                if(element > searchNum)
                {
                    searchColIndex--;
                }
                else
                {
                    searchRowIndex++;
                }
            }

            Console.WriteLine("Number not found");
        }
    }
}
