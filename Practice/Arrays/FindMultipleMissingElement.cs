using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class FindMultipleMissingElement
    {
        static void Main(string[] args)
        {
            // multiple missing element in sorted array
            var a = new int[] { 6, 7, 8, 9, 11, 12, 15, 16, 17, 18, 19 };
                      // index= 0  1  2  3   4   5   6   7   8   9   10
            MissingElement(a);
        }

        private static void MissingElement(int[] a)
        {
            int low = a[0];
            int high = a[a.Length - 1];
            int n = a.Length;

            int diff = low - 0; // 0 is starting index

            for(int i=0; i < n; i++)
            {
                if(a[i] - i != diff)
                {
                    while(diff < a[i] - i)
                    {
                        Console.WriteLine("Missing Element {0}", diff + i);
                        diff++;
                    }
                }
            }

        }
    }
}
