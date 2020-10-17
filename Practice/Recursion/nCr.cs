using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class nCr
    {
        //nCr using pascals triangle
        static void Main(string[] args)
        {
            // nCr = n-1Cr-1 + n-1Cr
            //4C2 = 6
            int result = combination(4, 2);
            Console.WriteLine(result);
        }

        private static int combination(int n, int r)
        {
            if (r == 0 || n == r) return 1;
            return combination(n - 1, r - 1) + combination(n - 1, r);
        }
    }
}
