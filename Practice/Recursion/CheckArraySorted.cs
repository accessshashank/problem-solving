using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class CheckArraySorted
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1, 2, 5 ,8, 9, 12, 43, 40 };
            Console.WriteLine(Sorted(array));
        }

        private static bool Sorted(int[] array)
        {
            return helper(array, 0, array.Length-1);
        }

        private static bool helper(int[] array, int start, int length)
        {
            if (start == length) return true;

            return array[start] < array[start + 1] && helper(array, start + 1, length);
        }
    }
}
