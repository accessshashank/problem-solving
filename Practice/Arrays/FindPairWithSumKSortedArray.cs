using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class FindPairWithSumKSortedArray
    {
        static void Main(string[] args)
        {

            var a = new int[] { 1, 3, 4, 5, 6, 8, 9, 10, 12, 14 };

            FindPair(a, 10);
        }

        private static void FindPair(int[] a, int K)
        {
            int low = 0;
            int high = a.Length - 1;

            while(low < high)
            {
                var sum = a[low] + a[high];
                if(sum > K)
                {
                    high--;
                }
                else if(sum < K)
                {
                    low++;
                }
                else
                {
                    Console.WriteLine("Pair ({0},{1}) has sum {2}",a[low], a[high], K);
                    low++;
                    high--;
                }
            }
        }
    }
}
