using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Sort
{
    class FindDuplicate
    {
        static void Main(string[] args)
        {
            // missing element in  array of size n, numbers can be ONLY 1 to n
            var arr = new int[] { 1, 1, 2 };
            var a = FindDuplicateNum(arr);
            Console.WriteLine(a);
        }

        private static int FindDuplicateNum(int[] arr)
        {
            int i = 0;
            while (i < arr.Length)
            {
                int correctIndexOfIthElement = arr[i] - 1;
                if (arr[i] != arr[correctIndexOfIthElement])
                {
                    //swap
                    int temp = arr[i];
                    arr[i] = arr[correctIndexOfIthElement];
                    arr[correctIndexOfIthElement] = temp;
                }
                else
                {
                    i++;
                }
            }

            //var coll = new List<int>();
            for (int k = 0; k <= arr.Length - 1; k++)
            {
                if (k != arr[k] - 1)
                {
                    return arr[k];
                }
            }

            return -1;
        }
    }
}
