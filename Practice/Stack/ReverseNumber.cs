using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class ReverseNumber
    {
        static void Main(string[] args)
        {
            int n = 456;
            Console.WriteLine(Rev(n));
        }

        private static int Rev(int num)
        {
            Stack<int> s = new Stack<int>();
            while(num > 0)
            {
                int rem = num % 10;
                s.Push(rem);
                num /= 10;
            }

            int len = s.Count;
            int i = 0;
            double sum = 0;
            while(s.Count != 0)
            {
                int n = s.Pop();
                sum = sum + n * Math.Pow(10, i);
                i++;
            }

            return Convert.ToInt32(sum);
        }
    }
}
