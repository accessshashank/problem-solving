using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Bitwise
{
    class ModuloExponentiation
    {
        public static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5293140#overview
            //(x^y)%p
            Console.WriteLine(Power(12, 7, 10007));
        }

        private  static int Power(int x, int y, int p)
        {
            int res = 1; // Initialize result

            x = x % p; // Update x if it is more than or
                       // equal to p

            if (x == 0)
                return 0; // In case x is divisible by p;

            while (y > 0)
            {

                // If y is odd, multiply x with result
                if ((y & 1) != 0)
                    res = (res * x) % p;

                // y must be even now
                y = y >> 1; // y = y/2
                x = (x * x) % p;
            }
            return res;
        }
    }
}
