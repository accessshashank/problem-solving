using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class SubArraySumUsingPrefixSums
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { -2, 3, 4, -1, 5, -12, 6, 1, 3 };
            LargestSubarraySum(numArray, numArray.Length);
        }

        private static void LargestSubarraySum(int[] numArray, int length)
        {
            int[] prefixArray = new int[numArray.Length];
            prefixArray[0] = numArray[0];

            for(int i=1; i<numArray.Length;i++)
            {
                prefixArray[i] = prefixArray[i - 1] + numArray[i];
            }

            var largestSubarraySum = 0;
            for(int i=0; i<numArray.Length;i++)
            {
                for(int j=i+1; j<numArray.Length;j++)
                {
                    var subArraySum = i > 0 ? prefixArray[j] - prefixArray[i - 1] : prefixArray[j];
                    largestSubarraySum = Math.Max(largestSubarraySum, subArraySum);
                }
            }

            Console.WriteLine("largest subarray sum = "+ largestSubarraySum);
        }
    }
}
