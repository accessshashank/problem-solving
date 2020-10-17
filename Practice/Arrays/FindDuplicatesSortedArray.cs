using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class FindDuplicatesSortedArray
    {
        static void Main(string[] args)
        {
            // sorted array
            var a = new int[] { 3, 6, 8, 8, 10, 12, 15, 15, 15, 20 };

            FindDuplicates(a);
            CountDuplicates(a);
            FindDuplicatesAndCountUsingHashing(a);
        }

        private static void FindDuplicatesAndCountUsingHashing(int[] a)
        {
            Console.WriteLine("using hashing ...\n");
            int maxNum = a[a.Length - 1];
            var h = new int[maxNum + 1];
            for(int i=0; i< h.Length; i++)
            {
                h[i] = 0;
            }

            for(int i=0;i<a.Length; i++)
            {
                h[a[i]]++;
            }

            for(int i=0;i < h.Length; i++)
            {
                if(h[i] > 1)
                {
                    Console.WriteLine("{0} is duplicate {1} times",i, h[i]);
                }
            }
        }

        private static void CountDuplicates(int[] a)
        {
            var j = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] == a[i + 1])
                {
                    j = i + 1;
                    while(a[j] == a[i])
                    {
                        j++;
                    }
                    Console.WriteLine("{0} is duplicate {1} times", a[i], j - i);
                    i = j - 1;
                }

            }
        }

        private static void FindDuplicates(int[] a)
        {
            var lastDuplicate = 0;
            for(int i=0; i< a.Length - 1; i++)
            {
                if(a[i] == a[i+1] && a[i] != lastDuplicate)
                {
                    Console.WriteLine("{0} is duplicate", a[i]);
                    lastDuplicate = a[i];
                }
            }
        }
    }
}
