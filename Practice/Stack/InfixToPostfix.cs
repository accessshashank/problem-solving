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
            Console.WriteLine("Use only +, -, * /");
            Console.WriteLine("Use only single digit numbers");
            Console.Write("Enter Infix Expression : ");
            var expression = Console.ReadLine();
            var postfix = ToPostfix(expression);
            Console.WriteLine("Postfix : {0}", postfix);
            Console.WriteLine("Evaluating postfix expression ... !");
            var eval = EvaluatePostfix(postfix);
            Console.WriteLine("Result : {0}", eval);
        }

        private static int EvaluatePostfix(string postfix)
        {
            var result = int.MinValue;
            int leftOperand = int.MinValue;
            int rightOperand = int.MinValue;
            var stack = new GenericStack<int>(postfix.Length);

            for(int i=0; i< postfix.Length; i++)
            {
                var ch = postfix[i];

                if(IsOperand(ch))
                {
                    stack.Push(int.Parse(ch.ToString()));
                }
                else
                {
                    rightOperand = stack.Pop();
                    leftOperand = stack.Pop();
                    switch(ch)
                    {
                        case '+':
                            {
                                result = leftOperand + rightOperand;
                                stack.Push(result);
                                break;
                            }
                        case '-':
                            {
                                result = leftOperand - rightOperand;
                                stack.Push(result);
                                break;
                            }
                        case '*':
                            {
                                result = leftOperand * rightOperand;
                                stack.Push(result);
                                break;
                            }
                        case '/':
                            {
                                result = leftOperand / rightOperand;
                                stack.Push(result);
                                break;
                            }
                    }
                }

            }

            result = stack.Pop();
            return result;
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
