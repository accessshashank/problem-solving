using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class CountConstruct
    {
        static void Main(string[] args)
        {
            // should return no of ways that target can be constructed by concanating elements of array.
            // elements of array can be reused as many times as needed
            Console.WriteLine(Count("abcdef", new string[] {"ab", "abc", "cd", "def", "abcd" })); // 1
            Console.WriteLine(Count("purple", new string[] { "purp", "p", "ur", "le", "purpl" })); // 2
            Console.WriteLine(Count("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); // 4

            var dp = new Dictionary<string, int>();
            Console.WriteLine(CountDP("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }, dp)); // 1
            dp = new Dictionary<string, int>();
            Console.WriteLine(CountDP("purple", new string[] { "purp", "p", "ur", "le", "purpl" }, dp)); // 2
            dp = new Dictionary<string, int>();
            Console.WriteLine(CountDP("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" }, dp)); // 4
        }

        private static int CountDP(string target, string[] arr, Dictionary<string, int> dp)
        {
            if (dp.ContainsKey(target)) return dp[target];
            if (target == "") return 1;
            int count = 0;
            foreach (var element in arr)
            {
                if (target.StartsWith(element))
                {
                    string remaining = target.Substring(element.Length);
                    count = count + CountDP(remaining, arr, dp);
                }
            }
            dp[target] = count;
            return count;
        }

        private static int Count(string target, string[] arr)
        {
            if (target == "") return 1;
            int count = 0;
            foreach (var element in arr)
            {
                if (target.StartsWith(element))
                {
                    string remaining = target.Substring(element.Length);
                    count = count + Count(remaining, arr);
                }
            }
            return count;
        }
    }
}
