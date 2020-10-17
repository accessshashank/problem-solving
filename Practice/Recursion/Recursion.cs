using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class Recursion
    {
        static void Main(string[] args)
        {
            int sum = SumOfNaturalNumbers(5);
            Console.WriteLine(sum);
        }

        private static int SumOfNaturalNumbers(int n)
        {
            if (n == 1) return 1;
            return n + SumOfNaturalNumbers(n - 1);
        }
    }
}
