using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class ReverseANumber
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reverse2(96534));
        }

        private static void Reverse(int num)
        {
            
            if (num == 0)
                return;

            Console.Write(num % 10);
            Reverse(num / 10);
            
        }

        private static int Reverse2(int num)
        {

            int digits = (int)Math.Log10(num) + 1;

            return Rev(num, digits);
        }

        private static int Rev(int num, int digits)
        {
            if (num == 0) return 0;

            return (num % 10) * (int)Math.Pow(10, digits-1) + Rev(num / 10, digits - 1);
        }
    }
}
