using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Union
    {
        static void Main(string[] args)
        {
            // union of two sorted arrays
            var a = new int[] { 3, 8, 16, 23, 25, 45, 59, 70 };
            var b = new int[] { 4, 10, 12, 22, 23, 50, 55 };
            var c = new int[a.Length + b.Length];
            UnionArray(a, b, c);
        }

        private static void UnionArray(int[] a, int[] b, int[] c)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while(i < a.Length && j < b.Length)
            {
                if(a[i] == b[j])
                {
                    c[k++] = a[i];
                    i++;
                    j++;
                }
                else if(a[i] < b[j])
                {
                    c[k++] = a[i++];
                }
                else
                {
                    c[k++] = b[j++];
                }
            }

            for(; i< a.Length; i++)
            {
                c[k++] = a[i];
            }

            for (; j < b.Length; j++)
            {
                c[k++] = b[j];
            }

            Console.WriteLine(string.Join(",", c));
        }
    }
}
