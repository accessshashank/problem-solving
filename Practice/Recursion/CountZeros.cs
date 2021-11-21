using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class CountZeros
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ZerosNum(10040230));
            Console.WriteLine(ZerosNumAnother(10040230));
        }

        private static int ZerosNum(int num)
        {
            if (num == 0) return 0;

            int zero = num % 10 == 0 ? 1 : 0;
            return zero + ZerosNum(num / 10);
        }

        private static int ZerosNumAnother(int num)
        {
            return helper(num, 0);
        }

        private static int helper(int num, int zeros)
        {
            if (num == 0) return zeros;

            if (num % 10 == 0) zeros++;
            return helper(num / 10, zeros);
        }
    }
}
