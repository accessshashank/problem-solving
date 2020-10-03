using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class NegativeOnLeftSide
    {
        static void Main(string[] args)
        {
            var elements = new int[] {-6, 3,-8, 10, 5, -7, -9, 12, -4, 2 };
            MoveNegativeToLeftSide(elements);
            
        }

        private static void MoveNegativeToLeftSide(int[] elements)
        {
            int i = 0;
            int j = elements.Length - 1;
            while(i < j)
            {
                while (elements[i] < 0) i++;
                while (elements[j] > 0) j--;

                if (i < j)
                {
                    var temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;
                }
            }

            Console.WriteLine(string.Join(",", elements));
        }
    }
}
