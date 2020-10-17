using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Misc
{
    class SquaresInSortedOrder
    {
        static void Main(string[] args)
        {
            //square numbers of sorted array such that resulting array is sorted, do in O(n)
            var numArray = new int[] {-11, -10, -9 , -5, -4, -2, 0, 1, 3, 6, 8 };
            SortSquares(numArray);
        }

        private static void SortSquares(int[] numArray)
        {
            Console.WriteLine("Input");
            Console.WriteLine(string.Join(",", numArray));
            var resultArray = new int[numArray.Length];
            var indexOfFirstNonNegative = -1;
            for(int k=0; k<numArray.Length; k++)
            {
                if(numArray[k] >=0)
                {
                    indexOfFirstNonNegative = k;
                    break;
                }
            }

            int index = 0;
            int i = indexOfFirstNonNegative - 1,  j = indexOfFirstNonNegative;
            while(i >= 0 && j <= numArray.Length-1)
            {
                if(numArray[i]*(-1) > numArray[j])
                {
                    resultArray[index++] = numArray[j] * numArray[j];
                    j++;
                }
                else
                {
                    resultArray[index++] = numArray[i] * numArray[i];
                    i--;
                }
            }

            if (i <= -1)
            { 
                for(int k=j; k<numArray.Length; k++)
                {
                    resultArray[index++] = numArray[k] * numArray[k];
                }
            }
            else if(j >= numArray.Length)
            {
                for(int k=i; k >=0; k--)
                {
                    resultArray[index++] = numArray[k] * numArray[k];
                }
            }

            Console.WriteLine("Output");
            Console.WriteLine(string.Join(",", resultArray));
        }
    }
}
