using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class HowSum
    {
        static void Main(string[] args)
        {
            // func should return array that can generate targetSum using elements in array
            // all elements of array can be used any number of times
            // all numbers are positive
            // return empty array if we can generate targetSum
            var dp = new Dictionary<int, bool>();
            var collection = new List<int>();
            How(7, new int[] { 2, 3 }, collection, dp);
            if (collection.Count > 0)
                Console.WriteLine("7 - " + string.Join(",", collection));
            else Console.WriteLine("7 -  No solution");

            dp = new Dictionary<int, bool>();
            collection = new List<int>();
            How(7, new int[] { 2, 4 }, collection, dp);
            if (collection.Count > 0)
                Console.WriteLine("7 - " + string.Join(",", collection));
            else Console.WriteLine("7 -  No solution");

            dp = new Dictionary<int, bool>();
            collection = new List<int>();
            How(8, new int[] { 5, 3, 2 }, collection, dp);
            if (collection.Count > 0)
                Console.WriteLine("8 - " + string.Join(",", collection));
            else Console.WriteLine("8 - No solution");

            dp = new Dictionary<int, bool>();
            collection = new List<int>();
            How(300, new int[] { 7, 14 }, collection, dp);
            if (collection.Count > 0)
                Console.WriteLine("300 - " + string.Join(",", collection));
            else Console.WriteLine("300 - No solution");

            Console.WriteLine("V2 version");

            var dp1 = new Dictionary<int, int[]>();

            var res = HowV2(8, new int[] { 5, 3, 2 }, dp1);
            if (res != null)
                Console.WriteLine("8 - " + string.Join(",", res));
            else Console.WriteLine("8 - No solution");

            dp1 = new Dictionary<int, int[]>();
            res = HowV2(7, new int[] { 2, 4 }, dp1);
            if (res != null)
                Console.WriteLine("7 - " + string.Join(",", res));
            else Console.WriteLine("7 - No solution");

            dp1 = new Dictionary<int, int[]>();
            res = HowV2(300, new int[] { 7, 14 }, dp1);
            if (res != null)
                Console.WriteLine("300 - " + string.Join(",", res));
            else Console.WriteLine("300 - No solution");
        }

        private static bool How(int targetSum, int[] arr, List<int> collection, Dictionary<int, bool> dp)
        {
            if (dp.ContainsKey(targetSum)) return dp[targetSum];
            if (targetSum == 0) return true;
            if (targetSum < 0) return false;

            foreach (var element in arr)
            {
                int remaining = targetSum - element;
                collection.Add(element);
                if (How(remaining, arr, collection, dp) == true)
                {
                    dp[targetSum] = true;
                    return true;
                }
                collection.Remove(element);
            }
            dp[targetSum] = false;
            return false;
        }

        private static int[] HowV2(int targetSum, int[] arr, Dictionary<int, int[]> dp)
        {
            if (dp.ContainsKey(targetSum)) return dp[targetSum];
            if (targetSum == 0) return new int[] { };
            if (targetSum < 0) return null;

            foreach (var element in arr)
            {
                int remaining = targetSum - element;
                var result = HowV2(remaining, arr, dp);
                if(result != null)
                {
                    int[] copy = new int[result.Length + 1];
                    Array.Copy(result, copy, result.Length);
                    copy[copy.Length - 1] = element;
                    dp[targetSum] = copy;
                    return copy;
                }
            }
            dp[targetSum] = null;
            return null;
        }
    }
}
