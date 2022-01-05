using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Sort
{
    class ChopstickPairs
    {
        static void Main(string[] args)
        {
            /*
             * Given N sticks and an array length where length[i] represents length of each stick. 
             * Find minimum number of pairs of these sticks such that difference between length of two sticks is at most D. 
             * A stick cant be part of more than one pair.
                I/P - {1, 3, 3, 9, 4} D=2
                O/P - 2 (1st and 3rd, 2nd and 5th are pairs)
             */
            var input = new int[] { 1, 3, 3, 9, 4 };
            Console.WriteLine("input array ({0})", string.Join(",", input));
            int noOfPairs = 0;
            var sorted = BubbleSortFunc(input, input.Length);
            for(int i=0; i<sorted.Length;i++)
            {
                for(int j=i+1; j<sorted.Length;j++)
                {
                    if(sorted[j] - sorted[i] <= 2)
                    {
                        Console.WriteLine("{0}, {1} are a pair", sorted[i], sorted[j]);
                        noOfPairs++;
                        sorted[i] = -1;
                        sorted[j] = -1;
                        break;
                    }
                }
            }
            Console.WriteLine("Total Pairs = "+noOfPairs);
        }

        private static int[] BubbleSortFunc(int[] input, int length)
        {
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (input[j] > input[j + 1])
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
