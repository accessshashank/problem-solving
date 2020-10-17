using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class FindMultipleMissingElementsUnsortedArray
    {
        static void Main(string[] args)
        {
            // multiple missing element in un-sorted array
            var a = new int[] { 3, 7, 4, 9, 12, 6, 1, 11, 2, 10 };
            
            MissingElement(a);
        }

        private static void MissingElement(int[] a)
        {
            int n = a.Length;
            int low = a[0];
            int high = a[0];
            for(int i=0; i<n;  i++)
            {
                if(a[i] < low)
                {
                    low = a[i];
                }
                else if(a[i] > high)
                {
                    high = a[i];
                }
            }

            var h = new int[high+1];
            for(int i=0; i< high; i++)
            {
                h[i] = 0;
            }

            for(int i=0; i<n; i++)
            {
                h[a[i]]++;
            }

            for(int i=low; i< high; i++)
            {
                if(h[i] == 0)
                {
                    Console.WriteLine("Missing Element {0}",i);
                }
            }
        }
    }
}
