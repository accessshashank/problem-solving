using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class FindPairWithSumKUnsortedArray
    {
        static void Main(string[] args)
        {
           
            var a = new int[] { 6, 3, 8, 10, 16, 7, 5, 2, 9, 14 };

            FindPair(a, 10);
        }

        private static void FindPair(int[] a, int K)
        {
            int n = a.Length;
            int max = -1;
            for(int i=0; i< n; i++)
            {
                if(a[i] > max)
                {
                    max = a[i];
                }
            }

            var h = new int[max + 1];

            for(int i=0; i< h.Length; i++)
            {
                h[i] = 0;
            }

            for(int i=0; i<a.Length; i++)
            {
                h[a[i]] = 1;
                if (K - a[i] < 0) continue;
                if (a[i] == K - a[i]) continue;
                if(h[K-a[i]] == 1)
                {
                    Console.WriteLine("Pair ({0},{1}) has sum {2}",a[i], K-a[i], K);
                }
            }

        }
    }
}
