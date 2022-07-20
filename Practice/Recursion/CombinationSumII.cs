using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class CombinationSumII
    {
        static void Main(string[] args)
        {
            // return unique subsequences with sum as target
            // each element in array can be used only once

            int target = 8;
            int[] arr = new int[] {10, 1, 2, 7, 6, 1, 5 };
            var output = Combination(0, arr, target, new List<int>());
            foreach (var item in output)
            {
                Console.WriteLine(string.Join(",", item));
            }

            Console.WriteLine();
            int[] arr1 = new int[] { 10, 1, 2, 7, 6, 1, 5 };
            Array.Sort(arr1);
            output = Combination_V2(0, arr1, target, new List<int>());
            foreach (var item in output)
            {
                Console.WriteLine(string.Join(",", item));
            }

            Console.WriteLine();
            target = 4;
            int[] arr2 = new int[] { 1, 1, 1, 2, 2 };
            Array.Sort(arr2);
            output = Combination_V2(0, arr2, target, new List<int>());
            foreach (var item in output)
            {
                Console.WriteLine(string.Join(",", item));
            }
        }

        private static List<List<int>> Combination_V2(int index, int[] arr, int target, List<int> temp)
        {
            List<List<int>> output = new List<List<int>>();

            if (target == 0)
            {
                var copy = new List<int>();
                foreach (var item in temp)
                {
                    copy.Add(item);
                }
                output.Add(copy);
                return output;
            }

            if (index >= arr.Length) return null;

            for(int i = index; i< arr.Length; i++)
            {
                if (i > index && arr[i] == arr[i - 1]) continue;
                if (arr[i] > target) break;

                temp.Add(arr[i]);
                var combinations = Combination_V2(i + 1, arr, target - arr[i], temp);
                if(combinations != null && combinations.Count > 0)
                {
                    output.AddRange(combinations);
                }
                temp.RemoveAt(temp.Count - 1);
            }
            return output;
        }

        // NOTE : This returns duplicate susequences too.
        private static List<List<int>> Combination(int index, int[] arr, int target, List<int> temp)
        {
            List<List<int>> output = new List<List<int>>();

            if (target == 0)
            {
                var copy = new List<int>();
                foreach (var item in temp)
                {
                    copy.Add(item);
                }
                copy.Sort();
                output.Add(copy);
                return output;
            }
            if (index >= arr.Length) return null;

            if (target >= arr[index])
            {
                temp.Add(arr[index]);
                var belowCombinations = Combination(index + 1, arr, target - arr[index], temp);
                if(belowCombinations != null && belowCombinations.Count > 0)
                {
                    output.AddRange(belowCombinations);
                    
                }
                temp.Remove(arr[index]);
            }

            var below = Combination(index + 1, arr, target, temp);
            if(below != null && below.Count > 0)
            {
                output.AddRange(below);
            }
            return output;
        }
    }
}
