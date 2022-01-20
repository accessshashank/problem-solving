using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class DuplicateParenthesis
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5265330#overview

            string str = "((a+b)+((c+d)))";
            Console.WriteLine(Check(str));

            string str1 = "((a+b)+(c+d))";
            Console.WriteLine(Check(str1));
        }

        private static bool Check(string str)
        {
            var stack = new Stack<char>();
            foreach (var item in str.ToCharArray())
            {
                if(item == ')')
                {
                    char top = stack.Pop();
                    int elementInside = 0;
                    while(stack.Count > 0 && stack.Peek() != '(')
                    {
                        elementInside++;
                        top = stack.Pop();
                    }
                    if(elementInside < 1)
                    {
                        return true;
                    }
                }
                else
                {
                    stack.Push(item);
                }
            }

            return false;
        }
    }
}
