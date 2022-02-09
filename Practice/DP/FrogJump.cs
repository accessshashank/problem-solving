using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class FrogJump
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[] height = new int[] { 10, 20, 30, 10 };

            Console.WriteLine(FindMinRecur(n, 0, height));
            int[] dp = new int[4];
            for (int i = 0; i < 4; i++)
            {
                dp[i] = -1;
            }
            Console.WriteLine(FindMinTopDown(n, 0, height, dp));
            Console.WriteLine(FindMinBottomUp(n, height));
        }

        private static int FindMinRecur(int n, int index, int[] height)
        {
            if (index >= n-1) return 0;

            int firstJump = Math.Abs(height[index] - height[index + 1]) + FindMinRecur(n, index + 1, height);

            int secondJump = 0;
            if(index+2 < n)
            secondJump = Math.Abs(height[index] - height[index + 2]) + FindMinRecur(n, index + 2, height);

            return Math.Min(firstJump, secondJump);
        }

        private static int FindMinTopDown(int n, int index, int[] height, int[] dp)
        {
            if (index >= n - 1) return 0;

            if (dp[index] != -1) return dp[index];

            int firstJump = Math.Abs(height[index] - height[index + 1]) + FindMinRecur(n, index + 1, height);

            int secondJump = 0;
            if (index + 2 < n)
                secondJump = Math.Abs(height[index] - height[index + 2]) + FindMinRecur(n, index + 2, height);

            dp[index] = Math.Min(firstJump, secondJump);
            return dp[index];
        }

        private static int FindMinBottomUp(int n, int[] height)
        {
            int[] dp = new int[n];
            dp[0] = 0;

            for(int index =1; index<n;index++)
            {
                int fs = Math.Abs(height[index] - height[index - 1]) + dp[index - 1];
                int ss = int.MaxValue;
                if(index > 1)
                {
                    ss = Math.Abs(height[index] - height[index - 2]) + dp[index - 2];
                }

                dp[index] = Math.Min(fs, ss);
            }

            return dp[n - 1];
        }
    }
}
