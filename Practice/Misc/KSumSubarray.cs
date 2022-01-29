using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Misc
{
    class KSumSubarray
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, -2, 1, 2, 3, 4, 5, 15, 10, 5};
            int k = 15;
            Console.WriteLine(LongestSubarrayKSum(arr, k));
        }

        private static int LongestSubarrayKSum(int[] arr, int k)
        {
            int len = 0;
            int preSum = 0;

            var dict = new Dictionary<int, int>();

            for(int i = 0; i<arr.Length; i++)
            {
                preSum = preSum + arr[i];

                if(preSum == k)
                {
                    len = Math.Max(len, i + 1);
                }

                int diff = preSum - k;
                if(dict.ContainsKey(diff))
                {
                    len = Math.Max(len, i - dict[diff]);
                }
                else
                {
                    dict.Add(preSum, i);
                }
            }
            return len;
        }
    }
}
