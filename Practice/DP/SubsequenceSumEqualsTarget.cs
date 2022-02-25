using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DP
{
    class SubsequenceSumEqualsTarget
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 3, 1, 1 };
            int target = 4;
            Console.WriteLine(Check(arr, arr.Length-1, target));

            int[,] dp = new int[,] { {-1,-1,-1,-1, -1 },{ -1, -1, -1, -1, -1 },{ -1, -1, -1, -1, -1 },{ -1, -1, -1, -1, -1 } };

            Console.WriteLine(CheckTopDown(arr, arr.Length - 1, target, dp));
        }

        private static bool CheckTopDown(int[] arr, int index, int target, int[,] dp)
        {
            if (target == 0) return true;
            if (index == 0) return arr[0] == target;

            if (dp[index, target] != -1) return dp[index, target] == 1;

            bool notTake = CheckTopDown(arr, index - 1, target, dp);
            bool take = false;
            if (target >= arr[index])
            {
                take = CheckTopDown(arr, index - 1, target - arr[index], dp);
            }

            dp[index,target] =  (notTake || take) ? 1 : 0;

            return dp[index, target] == 1 ? true : false;
        }

        private static bool Check(int[] arr, int index, int target)
        {
            if (target == 0) return true;
            if (index == 0) return arr[0] == target;

            bool notTake = Check(arr, index - 1, target);
            bool take = false;
            if(target >= arr[index])
            {
                take = Check(arr, index - 1, target - arr[index]);
            }

            return notTake || take;
        }
    }
}
