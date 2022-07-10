using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class GridTraveller
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dp = new Dictionary<string, int>();

            Console.WriteLine(Travel(3, 3, dp));

            dp = new Dictionary<string, int>();

            Console.WriteLine(Travel(3, 2, dp));
        }

        private static int Travel(int m, int n, Dictionary<string,int> dp)
        {
            string key = string.Format("{0},{1}", m, n);
            if (dp.ContainsKey(key)) return dp[key];
            if (m == 1 && n == 1) return 1;
            if (m == 0 || n == 0) return 0;
            dp[key] = Travel(m - 1, n, dp) + Travel(m, n - 1, dp);
            return dp[key];
        }
    }
}
