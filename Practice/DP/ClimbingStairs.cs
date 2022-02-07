using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class ClimbingStairs
    {
        static void Main(string[] args)
        {
            // person can climb only 1 or 2 stairs at a time
            int noOfStairs = 5;
            Console.WriteLine(CountNoOfWays(noOfStairs));

            int[] dp = new int[noOfStairs + 1];
            for(int i=0; i<noOfStairs+1;i++)
            {
                dp[i] = -1;
            }

            Console.WriteLine(CountNoOfWaysTopDown(noOfStairs, dp));

            for (int i = 0; i < noOfStairs + 1; i++)
            {
                dp[i] = -1;
            }

            Console.WriteLine(CountNoOfWaysBottonUp(noOfStairs, dp));
        }

        private static int CountNoOfWaysBottonUp(int noOfStairs, int[] dp)
        {
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 3;

            for(int i = 4; i<=noOfStairs;i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[noOfStairs];
        }

        private static int CountNoOfWaysTopDown(int noOfStairs, int[] dp)
        {
            if (noOfStairs == 1) return 1;
            if (noOfStairs == 2) return 2;
            if (noOfStairs == 3) return 3;

            if (dp[noOfStairs] != -1) return dp[noOfStairs];

            dp[noOfStairs] = CountNoOfWaysTopDown(noOfStairs - 1, dp) + CountNoOfWaysTopDown(noOfStairs - 2, dp);
            return dp[noOfStairs];
        }

        private static int CountNoOfWays(int noOfStairs)
        {
            if (noOfStairs == 1) return 1;
            if (noOfStairs == 2) return 2;
            if (noOfStairs == 3) return 3;

            return CountNoOfWays(noOfStairs - 1) + CountNoOfWays(noOfStairs - 2);

        }
    }
}
