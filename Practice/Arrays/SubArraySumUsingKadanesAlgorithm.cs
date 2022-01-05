using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class SubArraySumUsingKadanesAlgorithm
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { -2, 3, 4, -1, 5, -12, 6, 1, 3 };
            KadaneAlgo(numArray, numArray.Length);
        }

        private static void KadaneAlgo(int[] numArray, int length)
        {
            int currentSum = 0;
            int maximumSum = 0;

            for(int i=0; i<numArray.Length;i++)
            {
                currentSum = currentSum + numArray[i];
                if(currentSum < 0)
                {
                    currentSum = 0;
                }

                maximumSum = Math.Max(maximumSum, currentSum);
            }

            Console.WriteLine("largest subarray sum using Kadane's Algo is = " + maximumSum);
        }
    }
}
