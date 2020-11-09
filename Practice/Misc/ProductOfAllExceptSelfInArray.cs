using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Misc
{
    class ProductOfAllExceptSelfInArray
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 10, 4, 6, 20 };
            Console.WriteLine("Input - {0}", string.Join(", ",arr));
            int[] output = FindProduct(arr);
            Console.WriteLine("Output - {0}", string.Join(", ", output));
        }

        private static int[] FindProduct(int[] arr)
        {
            var output = new int[arr.Length];
            int product = 1;
            for(int i=0; i<arr.Length; i++)
            {
                product = product * arr[i];
            }

            for(int i=0; i< arr.Length; i++)
            {
                output[i] = (int)(product * Math.Pow(arr[i], -1));
            }
            return output;
        }
    }
}
