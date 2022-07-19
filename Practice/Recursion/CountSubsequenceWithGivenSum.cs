using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class CountSubsequenceWithGivenSum
    {
        static void Main(string[] args)
        {
            int target = 2;
            int[] arr = new int[] { 1, 2, 1 };
            Console.WriteLine(CountSubseq(0, arr, target, new List<int>()));
        }

        private static int CountSubseq(int index, int[] arr, int target, List<int> temp)
        {
            int count = 0;
            if (target == 0)
            {
                return 1;
            }
            if (index >= arr.Length)
            {
                return 0;
            }

            if (target >= arr[index])
            {
                temp.Add(arr[index]);
                count = count + CountSubseq(index + 1, arr, target - arr[index], temp);
            }

            temp.Remove(arr[index]);
            count = count + CountSubseq(index + 1, arr, target, temp);
            return count;
        }
    }
}
