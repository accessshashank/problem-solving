using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class MergeSortedArrays
    {
        static void Main(string[] args)
        {
            var a = new int[] { 3, 8, 16, 20, 25,45,59,70 };
            var b = new int[] { 4, 10, 12, 22, 23, 50, 55 };
            var c = new int[a.Length + b.Length];
            MergeArrays(a, b, c);
        }

        private static void MergeArrays(int[] a, int[] b, int[] c)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while(i < a.Length && j < b.Length)
            {
                if(a[i] < b[j])
                {
                    c[k++] = a[i++];
                }
                else
                {
                    c[k++] = b[j++];
                }
            }

            for(;i<a.Length;i++)
            {
                c[k++] = a[i];
            }

            for (;j<b.Length;j++)
            {
                c[k++] = b[j];
            }

            Console.WriteLine(string.Join(",", c));
        }
    }
}
