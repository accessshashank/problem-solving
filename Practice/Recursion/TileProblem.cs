using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class TileProblem
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/lecture/29529671#overview
            int n = 4;
            int m = 3;
            Console.WriteLine(Tiling(n, m));
        }

        private static int Tiling(int n, int m)
        {
            return tiles(n, m);
        }

        private static int tiles(int n, int m)
        {
            if (n < m) return 1;
            int op1 = tiles(n - 1, m);
            int op2 = tiles(n - m, m);
            return (op1 + op2);
        }
    }
}
