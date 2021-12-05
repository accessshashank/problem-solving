using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class TargetSum
    {
        static void Main(string[] args)
        {
            // dice
            var arr = new int[] { 1, 2, 3, 4, 5, 6 };

            SumRecursive(arr, "", 4);
        }

        private static void SumRecursive(int[] arr, string currentSum, int targetNum)
        {
            if (targetNum == 0)
            {
                Console.WriteLine(currentSum);
                return;
            }

            for(int i=0; i<arr.Length;i++)
            {
                int val = arr[i];
                if(val <= targetNum)
                SumRecursive(arr, currentSum + val, targetNum-val);
            }
        }
    }
}
