using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class CheckForSortedArray
    {
        static void Main(string[] args)
        {
            var elements = new int[8] { 3, 7, 9, 14, 16, 28, 45, 67 };
            var isSorted = CheckSortedArray(elements);
            Console.WriteLine(isSorted);
        }

        private static bool CheckSortedArray(int[] elements)
        {
            for(int i = 0; i < elements.Length - 1; i++)
            {
                if (elements[i] > elements[i + 1])
                    return false;
            }
            return true;
        }
    }
}
