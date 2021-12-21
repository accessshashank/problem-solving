using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Sort
{
    class MissingNumber
    {
        static void Main(string[] args)
        {
            // missing element in  array of size n, numbers can be ONLY 0 to n
            var a = new int[] { 1, 3, 0, 4 };
            int n = 4;
            Find(a, n);
        }

        private static void Find(int[] a, int n)
        {
            for(int i = 0; i<a.Length; i++)
            {
                //var value = a[i];
                while(a[i] != i)
                {
                    int correctIndex = a[i];
                    if (correctIndex < a.Length)
                    {
                        var temp = a[correctIndex];
                        a[correctIndex] = a[i];
                        a[i] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            bool missingFound = false;
            for(int i=0; i<a.Length; i++)
            {
                if(a[i] != i)
                {
                    Console.WriteLine("{0} is missing", i);
                    missingFound = true;
                    break;
                }
            }

            if(missingFound == false)
                Console.WriteLine("{0} is missing", n);
        }
    }
}
