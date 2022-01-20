using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class ReverseRecursive
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine("Before reverse");
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }

            // i have to push again because above Pop will have emptied the stack
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            //int[] arr = new int[stack.Count];
            Reverse(stack);

            Console.WriteLine();
            Console.WriteLine("After reverse");
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
        }

        private static void Reverse(Stack<int> stack)
        {
            if(stack.Count == 0)
            {
                return;
            }

            int temp = stack.Pop();;
            Reverse(stack);
            InsertAtBottom(stack, temp);
        }

        private static void InsertAtBottom(Stack<int> stack, int num)
        {
            if (stack.Count == 0)
            {
                stack.Push(num);
                return;
            }

            int temp = stack.Pop();
            InsertAtBottom(stack, num);
            stack.Push(temp);

        }
    }
}
