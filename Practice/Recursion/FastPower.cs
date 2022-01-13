using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class FastPower
    {
        static void Main(string[] args)
        {
            int n = 7;
            int a = 2;
            Console.Write(Power(2, 7)); // 2 to the power 7
        }

        private static int Power(int a, int n)
        {
            if (n == 0) return 1;

            int subProb = Power(a, n / 2);
            int subProbSq = subProb * subProb;

            var last_bit = n & 1;
            if (last_bit == 1)
            {
                return a * subProbSq;
            }
            return subProbSq;
        }
    }
}
