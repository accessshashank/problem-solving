using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class FirstAndLastIndexOfANumber
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 7, 7, 8, 8, 10 };
            int target = 8;
            var val = Search(arr, target);
            Console.WriteLine(string.Join(",", val));
        }

        private static int[] Search(int[] arr, int target)
        {
            int startIndex = SearchNum(arr, target, true);
            int endIndex = SearchNum(arr, target, false);

            return new int[] { startIndex, endIndex };
        }

        private static int SearchNum(int[] arr, int target, bool searchStart)
        {
            int index = -1;
            int start = 0;
            int end = arr.Length - 1;

            while(start <= end)
            {
                int mid = start + (end - start) / 2;
                if(arr[mid] > target)
                {
                    end = mid - 1;
                }
                else if(arr[mid] < target)
                {
                    start = mid + 1;
                }
                else // number is found
                {
                    index = mid;
                    if (searchStart)
                    {
                        
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }

            return index;
        }
    }
}
