using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class Triangle
    {
        static void Main(string[] args)
        {
             
            TrianglePrint(4,1);
            Console.WriteLine();
        }

        private static void TrianglePrint(int row, int col)
        {
            if (row == 0) return;

            if(col<=row)
            {
                //Console.Write("*");
                TrianglePrint(row, col + 1);
                Console.Write("*");
            }
            else
            {
                //Console.WriteLine();
                TrianglePrint(row - 1, 1);
                Console.WriteLine();
            }
        }
    }
}
