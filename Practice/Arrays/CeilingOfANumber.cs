using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class CeilingOfANumber
    {
        //ceiling = smallest number in array greater than equal to target
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 3, 5, 9, 14, 16, 18 };
            int target = 15;

            Console.WriteLine(Ceiling(arr, target));

        }

        private static int Ceiling(int[] arr, int target)
        {
            int start = 0;
            int end = arr.Length - 1;
           

            while(start <= end)
            {
                int mid = start + (end - start) / 2;
                
                if (arr[mid] == target)
                {
                    return target;
                }
                else if(arr[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }

               
            }

            return arr[start];
        }
    }
}
