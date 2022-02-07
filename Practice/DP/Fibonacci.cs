using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class Fibonacci
    {
        static void Main(string[] args)
        {
            int n = 6;
            int[] dp = new int[n + 1];
            for(int i = 0; i<n+1; i++)
            {
                dp[i] = -1;
            }

            Console.WriteLine(FibTopDown(n, dp));

            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = -1;
            }

            Console.WriteLine(FibBottomUp(n, dp));
        }

        private static int FibTopDown(int n, int[] dp)
        {
            if (n <= 1) return n;

            if (dp[n] != -1) return dp[n];

            dp[n] = FibTopDown(n - 1, dp) + FibTopDown(n - 2, dp);
            return dp[n];
        }

        private static int FibBottomUp(int n, int[] dp)
        {
            dp[0] = 0;
            dp[1] = 1;
            for(int i=2; i<n+1;i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
    }
}
