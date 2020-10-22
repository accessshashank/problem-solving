using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Local = Practice.Stack.UsingLinkedList;

namespace Practice.Stack
{
    class StackUsingLL
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stack using linked list");
            var stack = new Local.Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("Peek element :{0}", stack.Peek());
            Console.WriteLine("Pop element :{0}", stack.Pop());
            Console.WriteLine("Pop element :{0}", stack.Pop());
            Console.WriteLine("Pop element :{0}", stack.Pop());
            Console.WriteLine("Is stack empty : " + stack.IsEmpty());
        }
    }

}

namespace Practice.Stack.UsingLinkedList
{
    public class Stack
    {
        public Node Top { get; set; }

        public void Push(int val)
        {
            if(Top == null)
            {
                Top = new Node();
                Top.Value = val;
                Top.Next = null;
            }
            else
            {
                var node = new Node();
                node.Value = val;
                node.Next = Top;
                Top = node;
            }
        }

        public int Pop()
        {
            if (IsEmpty()) return -1;

            var current = Top;
            var value = Top.Value;
            Top = Top.Next;
            current.Next = null;

            return value;
        }

        public int Peek()
        {
            if (IsEmpty()) return -1;
            return Top.Value;
        }

        public bool IsEmpty()
        {
            return Top == null;
        }

        public class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }
    }



}
