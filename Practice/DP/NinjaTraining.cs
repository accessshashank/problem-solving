using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class NinjaTraining
    {
        static void Main(string[] args)
        {
            int days = 3;
            int[,] points = new int[3, 3] { {1, 2, 5 },{3, 1, 1 },{3, 3, 3 } };

            Console.WriteLine(MaxMerit(days - 1, 3, points));

            int[,] dp = new int[days, 4];
            for(int i =0; i<days;i++)
            {
                for(int j = 0; j<4;j++)
                {
                    dp[i, j] = -1;
                }
            }

            Console.WriteLine(MaxMeritTopDown(days - 1, 3, points, dp));
        }

        private static int MaxMeritTopDown(int index, int previousDay, int[,] points, int[,] dp)
        {
            if (index == 0)
            {
                int max = 0;
                for (int i = 0; i <= 2; i++)
                {
                    if (i != previousDay)
                    {
                        max = Math.Max(max, points[index, i]);
                    }
                }
                return max;
            }

            if (dp[index, previousDay] != -1) return dp[index, previousDay];

            int maxi = 0;

            for (int i = 0; i <= 2; i++)
            {
                if (i != previousDay)
                {
                    int maxPoints = points[index, i] + MaxMerit(index - 1, i, points);
                    maxi = Math.Max(maxi, maxPoints);
                }
            }

            dp[index, previousDay] = maxi;

            return dp[index, previousDay];
        }

        private static int MaxMerit(int index, int previousDay, int[,] points)
        {
            if(index == 0)
            {
                int max = 0;
                for(int i=0; i<=2; i++)
                {
                    if(i != previousDay)
                    {
                        max = Math.Max(max, points[index, i]);
                    }
                }
                return max;
            }

            int maxi = 0;

            for(int i=0;i<=2;i++)
            {
                if(i != previousDay)
                {
                    int maxPoints = points[index, i] + MaxMerit(index - 1, i, points);
                    maxi = Math.Max(maxi, maxPoints);
                }
            }

            return maxi;
        }
    }
}
