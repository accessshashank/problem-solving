using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class SubsequenceWithGivenSum
    {
        static void Main(string[] args)
        {
            int target = 2;
            int[] arr = new int[] { 1, 2, 1};
            Sum(0, arr, target, new List<int>());
        }

        private static void Sum(int index, int[] arr, int target, List<int> temp)
        {
            if(target == 0)
            {
                Console.WriteLine(string.Join(",", temp));
                return;
            }
            if(index >= arr.Length)
            {
                return;
            }

            if(target >= arr[index])
            {
                temp.Add(arr[index]);
                Sum(index + 1, arr, target - arr[index], temp);
            }

            temp.Remove(arr[index]);
            Sum(index + 1, arr, target, temp);
        }
    }
}
