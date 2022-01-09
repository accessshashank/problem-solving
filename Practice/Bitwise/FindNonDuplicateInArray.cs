using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Bitwise
{
    class FindNonDuplicateInArray
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[] {1, 2, 3, 1, 4, 2, 3, 4, 7 };
            int res = arr[0] ^ arr[1];
            int i = 2;
            while(i <= arr.Length - 1)
            {
                res ^= arr[i];
                i++;
            }

            Console.WriteLine("Non duplicate number " + res);
        }
    }
}
