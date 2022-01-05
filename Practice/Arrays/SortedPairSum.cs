using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class SortedPairSum
    {
        static void Main(string[] args)
        {
            //given a sorted array and a number x, find a pair which is closest to x
            var numArray = new int[] { 10, 22, 27, 28, 30, 40 };
            int x = 54;
            FindPair(numArray, x);
        }

        private static void FindPair(int[] numArray, int x)
        {
            int i = 0;
            int j = numArray.Length - 1;
            int minimumDiff = int.MaxValue;
            int minLeft = 0;
            int minRight = 0;

            while(i < j)
            {
                int sum = numArray[i] + numArray[j];
                int diff = Math.Abs(sum - x);
                if(minimumDiff > diff)
                {
                    minimumDiff = diff;
                    minLeft = i;
                    minRight = j;
                }
                
                if((sum - x) > 0)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine("Closest Pair {0},{1}", numArray[minLeft], numArray[minRight]);
        }
    }
}
