using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class AllConstruct
    {
        public static void Main(string[] args)
        {
            List<string> temp = new List<string>();
            var output = All("purple", new string[] {"purp", "p", "ur", "le", "purpl" }, temp);
            foreach (var inner in output)
            {
                Console.WriteLine(string.Join(",", inner));
            }

            Console.WriteLine();

            temp = new List<string>();
            output = All("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" }, temp);
            foreach (var inner in output)
            {
                Console.WriteLine(string.Join(",", inner));
            }
        }

        private static List<List<string>> All(string target, string[] arr, List<string> temp)
        {
            List<List<string>> output = new List<List<string>>();
            if(target == "")
            {
                var copy = new List<string>();
                foreach (var item in temp)
                {
                    copy.Add(item);
                }
                output.Add(copy);
                return output;
            }

            foreach (var element in arr)
            {
                if(target.StartsWith(element))
                {
                    string remaining = target.Substring(element.Length);
                    temp.Add(element);
                    var subCallsOutut = All(remaining, arr, temp);
                    if(subCallsOutut != null && subCallsOutut.Count > 0)
                    {
                        output.AddRange(subCallsOutut);
                    }
                    temp.Remove(element);
                }
            }
            return output;

        }
    }
}
