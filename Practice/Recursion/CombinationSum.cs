using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class CombinationSum
    {
        static void Main(string[] args)
        {
            // find all subseq with target sum
            // same number can be chosen from array any number of times
            int[] arr = new int[] { 2, 3, 6, 7 };
            int target = 7;
            var output = Combination(arr, target, new List<int>());
            foreach (var item in output)
            {
                Console.WriteLine(string.Join(",", item));
            }
            Console.WriteLine();

            output = CombinationV2(0, arr, target, new List<int>());
            foreach (var item in output)
            {
                Console.WriteLine(string.Join(",", item));
            }
        }

        private static List<List<int>> Combination(int[] arr, int target, List<int> temp)
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

            foreach (var element in arr)
            {
                if(target >= element)
                {
                    int remaining = target - element;
                    temp.Add(element);
                    var belowSubSeq = Combination(arr, remaining, temp);
                    if(belowSubSeq.Count > 0)
                    {
                        output.AddRange(belowSubSeq);
                    }
                    temp.Remove(element);
                }
            }
            return output;
        }

        private static List<List<int>> CombinationV2(int index, int[] arr, int target, List<int> temp)
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

            int element = arr[index];
            if (target >= element)
            {
                int remaining = target - element;
                temp.Add(element);
                var belowSubSeq = CombinationV2(index, arr, remaining, temp); // Pick. Dont increase index so that same element can be picked in next call.
                if (belowSubSeq != null && belowSubSeq.Count > 0)
                {
                    output.AddRange(belowSubSeq);
                }
                temp.Remove(element);
            }

            var below = CombinationV2(index + 1, arr, target, temp); // Not Pick. Increase index since i decided to not pick current element
            if(below != null && below.Count > 0)
            {
                output.AddRange(below);
            }
            return output;
        }
    }
}
