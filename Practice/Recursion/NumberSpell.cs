using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class NumberSpell
    {
        static void Main(string[] args)
        {
            int num = 1909;
            Process(num);
            Console.WriteLine();
        }

        private static void Process(int num)
        {
            if (num == 0) return;

            int rem = num % 10;
            num = num / 10;
            Process(num);
            PrintNum(rem);
            
        }

        static void PrintNum(int x)
        {
            switch(x)
            {
                case 0: Console.Write("zero ");
                    break;
                case 1:
                    Console.Write("one ");
                    break;
                case 2:
                    Console.Write("two ");
                    break;
                case 3:
                    Console.Write("three ");
                    break;
                case 4:
                    Console.Write("four ");
                    break;
                case 5:
                    Console.Write("five ");
                    break;
                case 6:
                    Console.Write("six ");
                    break;
                case 7:
                    Console.Write("seven ");
                    break;
                case 8:
                    Console.Write("eight ");
                    break;
                case 9:
                    Console.Write("nine ");
                    break;
                default: break;
            }
        }
    }
}
