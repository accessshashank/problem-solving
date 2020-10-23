using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class ParenthesisMatching
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Parenthesis : ");
            var str = Console.ReadLine();
            bool isBalanced = CheckBalance(str);
            if (isBalanced) Console.WriteLine("Parenthesis IS balanced");
            else Console.WriteLine("Parenthesis is NOT balanced");
        }

        private static bool CheckBalance(string str)
        {
            var stack = new GenericStack<char>(str.Length);

            for(int i=0; i< str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '[' || str[i] == '{') 
                    stack.Push(str[i]);
                else if(str[i] == ')' || str[i] == ']' || str[i] == '}')
                {
                    if (stack.IsEmpty()) return false;
                    char bracket = stack.Pop();
                    if (str[i] == ')' && bracket != '(') return false;
                    if (str[i] == ']' && bracket != '[') return false;
                    if (str[i] == '}' && bracket != '{') return false;
                }
            }

            if (stack.IsEmpty()) return true;
            return false;
        }
    }
}
