using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class MaximumSumOfNonAdjacentElement
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 6, 7, 1, 30, 8, 2, 4 };
            Console.WriteLine(FindMaxSum(array, 0));
            int[] dp = new int[array.Length];
            for(int i=0; i<dp.Length;i++)
            {
                dp[i] = -1;
            }

            Console.WriteLine(FindMaxSumTopDown(array, 0, dp));
            Console.WriteLine(FindMaxSumBottomUp(array));

        }
        private static int FindMaxSumBottomUp(int[] array)
        {
            int[] dp = new int[array.Length];
            dp[0] = array[0];
            dp[1] = Math.Max(array[0], array[1]);

            for(int i=2; i<array.Length;i++)
            {
                int pick = array[i] + dp[i - 2];
                int notPick = dp[i - 1];
                dp[i] = Math.Max(pick, notPick);
            }

            return dp[array.Length - 1];
        }

        private static int FindMaxSumTopDown(int[] array, int index, int[] dp)
        {
            if (index >= array.Length) return 0;

            if (dp[index] != -1) return dp[index];

            int pick = array[index] + FindMaxSum(array, index + 2);
            int notPick = FindMaxSum(array, index + 1);

            dp[index] = Math.Max(pick, notPick);
            return dp[index];
        }

        private static int FindMaxSum(int[] array, int index)
        {
            if (index >= array.Length) return 0;

            int pick = array[index] + FindMaxSum(array, index + 2);
            int notPick = FindMaxSum(array, index + 1);

            return Math.Max(pick, notPick);
        }
    }
}
