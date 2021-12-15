using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class RotatedSortedArray
    {
        static void Main(string[] args)
        {
            var elements = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            var pivot = FindPivot(elements);
            int target = 2;
            int ix = -1;
            if(pivot == -1)
            {
                Console.WriteLine(BinarySearch(elements, target, 0, elements.Length - 1));
            }
            else
            {
                ix = BinarySearch(elements, target, 0, pivot);
                if(ix == -1)
                {
                    ix = BinarySearch(elements, target, pivot + 1, elements.Length - 1);
                }
            }
        }

        private static int BinarySearch(int[] elements, int target, int start, int end)
        {

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (elements[mid] == target)
                {
                    return mid;
                }
                else if (elements[mid] < target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return -1;
        }

        private static int FindPivot(int[] elements)
        {
            int start = 0;
            int end = elements.Length - 1;

            while(start <= end)
            {
                int mid = start + (end - start) / 2;
                if(elements[mid] > elements[mid+1])
                {
                    return mid;
                }
                if(elements[mid] < elements[mid-1])
                {
                    return mid - 1;
                }
                if(elements[start] < elements[mid])
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }
            }
            return -1;
        }
    }
}
