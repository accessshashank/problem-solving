using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Sort
{
    class SelectionSort
    {
        static void Main(string[] args)
        {
            var input = new int[] { 8, 5, 7, 3, 2 };
            Console.WriteLine("input array ({0})", string.Join(",", input));

            var output = SelectionSortFunc(input, input.Length);
            Console.WriteLine("output array ({0})", string.Join(",", output));
        }

        private static int[] SelectionSortFunc(int[] input, int length)
        {
            int k = 0;
            for(int i=0; i< length -1; i++)
            {
                k = i;
                for (int j = i; j < length; j++)
                {
                    if(input[j] < input[k])
                    {
                        k = j;
                    }
                }

                int temp = input[k];
                input[k] = input[i];
                input[i] = temp;
            }
            return input;
        }
    }
}
