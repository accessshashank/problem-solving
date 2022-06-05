using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class PartitionArrayMaxDiffK
    {
        static void Main(string[] args)
        {
            //https://leetcode.com/contest/weekly-contest-296/problems/partition-array-such-that-maximum-difference-is-k/
            int[] nums = new int[] { 3, 6, 1, 2, 5 };
            int k = 2;

            Console.WriteLine(PartitionArray(nums, k));
        }
        static int PartitionArray(int[] nums, int k)
        {
            Array.Sort(nums); // 1, 2, 3, 5, 6
            int c = 1, prev = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] - nums[prev] <= k) continue;
                c++; prev = i;
            }
            return c;
        }
    }
}
