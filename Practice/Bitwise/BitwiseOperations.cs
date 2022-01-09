using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Bitwise
{
    class BitwiseOperations
    {
        static void Main(string[] args)
        {
            OddEven(10);
            OddEven(11);
            GetIthBit(5, 2);
            GetIthBit(8, 2);
            ClearIthBit(5, 2);
            SetIthBit(5, 1);
            UpdateIthBit(5, 1, 1);
            ClearLastIBits(7, 2);
            CountBits(7);
            CountBits(8);
            FastExponentiation(2, 5);
            FastExponentiation(3, 3);
        }

        private static void OddEven(int num)
        {
            var result = num & 1;
            if (result == 0) Console.WriteLine(num + " is even");
            else Console.WriteLine(num + " is odd");
        }

        private static void GetIthBit(int num, int position)
        {
            int mask = 1 << position;
            int res = num & mask;
            if (res > 0) Console.WriteLine("bit at position {0} for number {1} is 1", position, num);
            else Console.WriteLine("bit at position {0} for number {1} is 0", position, num);
        }

        private static void ClearIthBit(int num, int position)
        {
            int mask = 1 << position;
            int negation = ~mask;
            int res = num & negation;
            Console.WriteLine("The resulting number with {0}th bit cleared is {1}", position, res);
        }

        private static void SetIthBit(int num, int position)
        {
            int mask = 1 << position;
            int res = num | mask;
            Console.WriteLine("The resulting number with {0}th bit set is {1}", position, res);
        }

        private static void UpdateIthBit(int num, int position, int value)
        {
            ClearIthBit(num, position);
            int mask = value << position;
            int res = num | mask;
            Console.WriteLine("The resulting number with {0}th bit set is {1}", position, res);
        }

        private static void ClearLastIBits(int num, int i)
        {
            int mask = (-1 << i);
            int res = num & mask;
            Console.WriteLine("The resulting number with last {0} bits cleared is {1}", i, res);
        }

        private static void CountBits(int num)
        {
            int copy = num;
            int ans = 0;
            while(num>0)
            {
                num = num & (num - 1);
                ans++;
            }
            Console.WriteLine("Number of bits in {0} is {1}", copy, ans);
        }

        private static void FastExponentiation(int num, int power)
        {
            int copy = num;
            int copyPower = power;
            int ans = 1;
            while(power > 0)
            {
                int lastBit = power & 1;
                if(lastBit == 1)
                {
                    ans = ans * num;
                }

                num = num * num;
                power = power >> 1;
            }

            Console.WriteLine("{0} to the power {1} is {2}", copy, copyPower, ans);
        }
    }
}
