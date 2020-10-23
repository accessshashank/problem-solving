using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class StackUsingGeneric
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Interger Stack");
            Console.WriteLine("Accepting size 3 : ");
            int size = 3;
            var intStack = new GenericStack<int>(size);

            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);

            Console.WriteLine("Is stack full : " + intStack.IsFull());
            Console.WriteLine("Peek element :{0}", intStack.Peek());
            Console.WriteLine("Pop element :{0}", intStack.Pop());
            Console.WriteLine("Pop element :{0}", intStack.Pop());
            Console.WriteLine("Pop element :{0}", intStack.Pop());
            Console.WriteLine("Is stack empty : " + intStack.IsEmpty());

            Console.WriteLine("Initializing Character Stack");
            Console.WriteLine("Accepting size 3 : ");
            var charStack = new GenericStack<char>(size);

            charStack.Push('A');
            charStack.Push('B');
            charStack.Push('C');

            Console.WriteLine("Is stack full : " + charStack.IsFull());
            Console.WriteLine("Peek element :{0}", charStack.Peek());
            Console.WriteLine("Pop element :{0}", charStack.Pop());
            Console.WriteLine("Pop element :{0}", charStack.Pop());
            Console.WriteLine("Pop element :{0}", charStack.Pop());
            Console.WriteLine("Is stack empty : " + charStack.IsEmpty());

        }
    }

    public class GenericStack<T>
    {
        public int Size { get; private set; }
        private int Top { get; set; }
        private readonly T[] arr;

        public GenericStack(int size)
        {
            Size = size;
            Top = -1;
            arr = new T[size];
        }

        public void Push(T val)
        {
            if (IsFull()) return;

            arr[++Top] = val;
        }

        public T Pop()
        {
            if (IsEmpty()) return default(T);

            return arr[Top--];
        }

        public T Peek()
        {
            if (IsEmpty()) return default(T);
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
