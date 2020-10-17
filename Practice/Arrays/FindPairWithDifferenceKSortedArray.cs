using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class FindPairWithDifferenceKSortedArray
    {
        static void Main(string[] args)
        {

            var a = new int[] { 2, 4, 8, 9, 13, 16, 19, 23, 25 };

            FindPair(a, 10);
        }

        private static void FindPair(int[] a, int difference)
        {
            var i = 0;
            var j = i + 1;
            while(j < a.Length)
            {
                var diff = a[j] - a[i];
                if (diff == difference)
                {
                    Console.WriteLine("Difference of pair ({0},{1}) is {2}",a[j], a[i], difference);
                    i++;
                    j++;
                }
                else if(diff < difference)
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
