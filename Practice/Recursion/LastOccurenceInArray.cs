using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class LastOccurenceInArray
    {
        static void Main(string[] args)
        {
            int[] arr = new[] { 1, 2, 7, 6, 7, 5 };
            int num = 7; // find last occurrence of num
            Console.WriteLine(LastOccurrence(arr, num));
        }

        private static int LastOccurrence(int[] arr, int num)
        {
            if (arr.Length == 0) return -1;

            int[] temp = new int[arr.Length - 1];
            Array.Copy(arr, 1, temp, 0, arr.Length - 1);
            int subIndex = LastOccurrence(temp, num);
            if(subIndex == -1)
            {
                if(arr[0] == num)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return subIndex + 1;
            }
        }
    }
}
