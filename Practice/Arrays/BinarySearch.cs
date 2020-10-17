using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            // For binary search array should be sorted
            var array = new int[] {2,5,8,9,13,16,18,19,20};
            Console.WriteLine(BinarySearchIterative(0, 8, 7, array));
            Console.WriteLine(BinarySearchRecursive(0, 8, 20, array));
        }

        private static int BinarySearchIterative(int low, int high, int key, int[] array)
        {
            while(low <= high)
            {
                int mid = (int)Math.Floor(Convert.ToDecimal((low + high) / 2));
                if(array[mid] == key)
                {
                    return mid;
                }
                else if(key < array[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;
        }
        private static int BinarySearchRecursive(int low, int high, int key, int[] array)
        {
            if (low <= high)
            {
                int mid = (int)Math.Floor(Convert.ToDecimal((low + high) / 2));
                if (array[mid] == key)
                {
                    return mid;
                }
                else if (key < array[mid])
                {
                    return BinarySearchRecursive(low, mid - 1, key, array);
                }
                else
                {
                    return BinarySearchRecursive(mid+1, high, key, array);
                }
            }
            return -1;
        }

    }
}
