using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Sort
{
    class InsertionSort
    {
        static void Main(string[] args)
        {
            var input = new int[] { 8, 5, 7, 3, 2 };
            Console.WriteLine("input array ({0})", string.Join(",", input));

            var output = InsertionSortFunc(input, input.Length);
            Console.WriteLine("output array ({0})", string.Join(",", output));
        }

        private static int[] InsertionSortFunc(int[] input, int length)
        {
            for(int i = 1; i<length; i++)
            {
                int j = i - 1;
                var x = input[i];

                while(j> -1 && input[j] > x)
                {
                    input[j + 1] = input[j];
                    j--;
                }

                input[j+1] = x;
            }

            return input;
        }
    }
}
