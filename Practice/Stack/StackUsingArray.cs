using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class StackUsingArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of stack : ");
            Console.ReadLine();
            Console.WriteLine("Accepting size 3 : ");
            int size = 3;

            var stack = new Stack(size);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("Is stack full : "+ stack.IsFull());
            Console.WriteLine("Peek element :{0}", stack.Peek());
            Console.WriteLine("Pop element :{0}", stack.Pop());
            Console.WriteLine("Pop element :{0}", stack.Pop());
            Console.WriteLine("Pop element :{0}", stack.Pop());
            Console.WriteLine("Is stack empty : " + stack.IsEmpty());
        }
    }

    public class Stack
    {
        public int Size { get; private set; }
        private int Top { get; set; }
        private readonly int[] arr;

        public Stack(int size)
        {
            Size = size;
            Top = -1;
            arr = new int[size];
        }

        public void Push(int val)
        {
            if (IsFull()) return;

            arr[++Top] = val;
        }

        public int Pop()
        {
            if (IsEmpty()) return -1;

            return arr[Top--];
        }

        public int Peek()
        {
            if (IsEmpty()) return -1;
            return arr[Top];
        }

        public bool IsEmpty()
        {
            return Top == -1;
        }

        public bool IsFull()
        {
            return Top == Size - 1;
        }
    }
}
