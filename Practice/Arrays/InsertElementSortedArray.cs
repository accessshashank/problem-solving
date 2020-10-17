using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class InsertElementSortedArray
    {
        static void Main(string[] args)
        {
            var elements = new int[8] {3, 7, 9, 14, 19, 28, 45, 99999};
            var elementToInsert = 34;
            InsertElement(elements, elementToInsert);
        }

        private static void InsertElement(int[] elements, int elementToInsert)
        {
            int i = elements.Length-1 - 1;
            while(i >= 0 && elements[i] > elementToInsert)
            {
                elements[i + 1] = elements[i];
                i--;
            }
            elements[i + 1] = elementToInsert;
            Console.WriteLine(string.Join(",", elements));
        }
    }
}
