using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class CanConstruct
    {
        static void Main(string[] args)
        {
            // Can target be constructed with concatenation of strings in array where elements in array can be repeated any no of times.
            Console.WriteLine(Can("abcdef", "", new string[] {"ab", "abc", "cd", "def", "abcd" }));
            Console.WriteLine(Can("skateboard", "", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }));

            Console.WriteLine(CanV2("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }));
            Console.WriteLine(CanV2("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }));

            var dp = new Dictionary<string, bool>();
            Console.WriteLine(CanV2DP("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }, dp));
            Console.WriteLine(CanV2DP("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }, dp));
        }

        private static bool CanV2DP(string target, string[] arr, Dictionary<string, bool> dp)
        {
            if (dp.ContainsKey(target)) return dp[target];
            if (target == "") return true;

            foreach (var element in arr)
            {
                if (target.StartsWith(element))
                {
                    string remaining = target.Substring(element.Length);
                    if (CanV2DP(remaining, arr, dp) == true)
                    {
                        dp[target] = true;
                        return true;
                    }
                }
            }

            dp[target] = false;
            return false;
        }

        private static bool CanV2(string target, string[] arr)
        {
            if (target == "") return true;  

            foreach (var element in arr)
            {
               if(target.StartsWith(element))
                {
                    string remaining = target.Substring(element.Length);
                    if(CanV2(remaining, arr) == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private static bool Can(string target, string intermediate, string[] arr)
        {
            if (target == intermediate) return true;
            if (target.Length < intermediate.Length) return false;
            if (target.StartsWith(intermediate) == false) return false;

            foreach (var element in arr)
            {
                intermediate += element;
                if(Can(target, intermediate, arr) == true)
                {
                    return true;
                }
                intermediate = intermediate.Substring(0, intermediate.Length - element.Length);
            }

            return false;
        }
    }
}
