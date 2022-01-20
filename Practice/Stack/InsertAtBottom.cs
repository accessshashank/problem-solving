using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class InsertAtBottom
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            int num = 5; // insert at bottom
            Insert(stack, num);
            while(stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }

        private static void Insert(Stack<int> stack, int num)
        {
            if(stack.Count == 0)
            {
                stack.Push(num);
                return;
            }

            int temp = stack.Pop();
            Insert(stack, num);
            stack.Push(temp);

        }
    }
}
