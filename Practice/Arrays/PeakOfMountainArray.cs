using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class PeakOfMountainArray
    {
        static void Main(string[] args)
        {
            var elements = new int[] { 1, 3, 5, 7, 8, 6};
            Console.WriteLine(FindPeak(elements));
        }

        private static int FindPeak(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;
            while(start <= end)
            {
                int mid = start + (end - start) / 2;
                if(arr[mid] > arr[mid+1]) // i am in decreasing part of array
                {
                    end = mid;
                }
                else if(arr[mid] < arr[mid+1])
                {
                    start = mid + 1;
                }

                if (start == end && start == mid) break;
            }

            return arr[start];
        }
    }
}
