using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class TargetSum
    {
        static void Main(string[] args)
        {
            // func should return bool indicating whether its possible to generate targetSum using elements in array
            // all elements of array can be used any number of times
            // all numbers are positive
            var dp = new Dictionary<int, bool>();
            Console.WriteLine(Sum(7, new int[] { 2, 3 }, dp));
            dp = new Dictionary<int, bool>();
            Console.WriteLine(Sum(7, new int[] { 2, 4 }, dp));
            dp = new Dictionary<int, bool>();
            Console.WriteLine(Sum(8, new int[] { 5, 3, 2 }, dp));
            dp = new Dictionary<int, bool>();
            Console.WriteLine(Sum(300, new int[] { 7, 14 }, dp));
        }

        private static bool Sum(int targetSum, int[] arr, Dictionary<int, bool> dp)
        {
            if (dp.ContainsKey(targetSum)) return dp[targetSum];
            if (targetSum == 0) return true;
            if (targetSum < 0) return false;

            foreach (var element in arr)
            {
                int remaining = targetSum - element;
                if(Sum(remaining, arr, dp) == true)
                {
                    dp[targetSum] = true;
                    return true;
                }
            }
            dp[targetSum] = false;
            return false;
        }
    }
}
