using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class InfixToPostfix
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Infix Expression : ");
            var expression = Console.ReadLine();
            var postfix = ToPostfix(expression);
            Console.WriteLine("Postfix : {0}", postfix);
        }

        private static string ToPostfix(string expression)
        {
            var postfix = string.Empty;
            var stack = new GenericStack<char>(expression.Length);
            for(int i=0; i < expression.Length; i++)
            {
                char ch = expression[i];
                if(IsOperand(ch))
                {
                    postfix = postfix + ch;
                }
                else
                {
                    if(stack.IsEmpty())
                    {
                        stack.Push(ch);

                    }
                    else
                    {
                        var precedence = Precedence(ch);
                        while((Precedence(stack.Peek()) >= precedence) && !stack.IsEmpty())
                        {
                            var item = stack.Pop();
                            postfix = postfix + item;
                        }
                        stack.Push(ch);
                    }
                }
            }

            while(!stack.IsEmpty())
            {
                postfix = postfix + stack.Pop();
            }

            return postfix;
        }

        private static bool IsOperand(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/') return false;
            return true;
        }

        private static int Precedence(char c)
        {
            if (c == '+' || c == '-') return 1;
            if (c == '*' || c == '/') return 2;
            return 0;
        }
    }
}
