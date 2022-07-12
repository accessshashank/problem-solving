using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class BestSum
    {
        static void Main(string[] args)
        {
            // func should return array that can generate targetSum using elements in array
            // return shortest length array that makes targetSum
            // all elements of array can be used any number of times
            // all numbers are positive
            // return empty array if we can generate targetSum

            Console.WriteLine(String.Join(",",Best(7, new int[] { 5, 3, 4, 7 })));
            Console.WriteLine(String.Join(",", Best(8, new int[] { 2, 3, 5 })));
            Console.WriteLine(String.Join(",", Best(8, new int[] { 1, 4, 5 })));

            Dictionary<int, int[]> dp = new Dictionary<int, int[]>();
            Console.WriteLine(String.Join(",", BestDP(100, new int[] { 1, 2, 5, 25 }, dp)));
        }
        private static int[] BestDP(int targetSum, int[] arr, Dictionary<int, int[]> dp)
        {
            if (dp.ContainsKey(targetSum)) return dp[targetSum];

            if (targetSum == 0) return new int[] { };
            if (targetSum < 0) return null;

            int[] shortestCombination = null;

            foreach (var element in arr)
            {
                int remaining = targetSum - element;
                var combination = BestDP(remaining, arr, dp);
                if (combination != null)
                {
                    int[] copy = new int[combination.Length + 1];
                    Array.Copy(combination, copy, combination.Length);
                    copy[copy.Length - 1] = element;

                    if (shortestCombination == null || copy.Length < shortestCombination.Length)
                    {
                        shortestCombination = copy;
                    }
                }
            }
            dp[targetSum] = shortestCombination;
            return shortestCombination;
        }

        private static int[] Best(int targetSum, int[] arr)
        {
            if (targetSum == 0) return new int[] { };
            if (targetSum < 0) return null;

            int[] shortestCombination = null;

            foreach (var element in arr)
            {
                int remaining = targetSum - element;
                var combination = Best(remaining, arr);
                if(combination != null)
                {
                    int[] copy = new int[combination.Length + 1];
                    Array.Copy(combination, copy, combination.Length);
                    copy[copy.Length - 1] = element;

                    if (shortestCombination == null || copy.Length < shortestCombination.Length)
                    {
                        shortestCombination = copy;
                    }
                }
            }
            return shortestCombination;
        }
    }
}
