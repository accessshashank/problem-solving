using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class SumOfDigits
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumRec(3451));
        }

        private static int Sum(int num)
        {
            int sum = 0;
            
            //sum = sum + reminder;
            while(num != 0)
            {
                int reminder = num % 10;
                num = num / 10;
                sum = sum + reminder;
            }
            return sum;
        }

        private static int SumRec(int num)
        {
            if (num == 0)
                return 0;

            int remainder = num % 10;
            return remainder + SumRec(num / 10);
        }
    }
}
