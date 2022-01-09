using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Bitwise
{
    class EarthLevel
    {
        static void Main(string[] args)
        {
            Console.WriteLine(earthLevel(8));
        }

        static long convertDecimalToBinary(long n)
        {
            long binaryNumber = 0;
            long remainder, i = 1;

            while (n != 0)
            {
                remainder = n % 2;
                n /= 2;
                binaryNumber += remainder * i;
                i *= 10;
            }
            return binaryNumber;
        }

        static int earthLevel(int k)
        {
            long binaryNumber, sum = 0;
            binaryNumber = convertDecimalToBinary(k);

            while (binaryNumber != 0)
            {
                long t;
                t = binaryNumber % 2;
                sum = sum + t;
                binaryNumber = binaryNumber / 10;
            }

            return (int)sum;
        }
    }
}
