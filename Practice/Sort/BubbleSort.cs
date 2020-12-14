using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Sort
{
    class BubbleSort
    {
        static void Main(string[] args)
        {
            var input = new int[] { 8, 5, 7, 3, 2 };
            Console.WriteLine("input array ({0})", string.Join(",", input));

            var output = BubbleSortFunc(input, input.Length);
            Console.WriteLine("output array ({0})", string.Join(",", output));
        }

        private static int[] BubbleSortFunc(int[] input, int length)
        {
            for(int i=0; i< length-1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if(input[j] > input[j+1])
                    {
                        var temp = input[j + 1];
                        input[j + 1] = input[j];
                        input[j] = temp;
                    }
                }
            }

            return input;
        }
    }
}
