using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Sort
{
    class CycleSort
    {
        static void Main(string[] args)
        {
            // it is applicable only for number from 1 to N in an array of size N
            int[] arr = new int[] {3, 5, 2, 1, 4 };

            Sort(arr);

            Console.WriteLine(string.Join(",", arr));
        }

        private static void Sort(int[] arr)
        {
            int len = arr.Length;

            for(int i=0; i< len;i++)
            {
                while(arr[i] != i+1)
                {
                    var item = arr[i];
                    int val = arr[item - 1];
                    arr[item - 1] = item;
                    arr[i] = val;
                }
            }
        }
    }
}
