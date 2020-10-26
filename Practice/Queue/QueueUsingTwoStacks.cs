using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Stack;

namespace Practice.Queue
{
    class QueueUsingTwoStacks
    {
        static void Main(string[] args)
        {
            var queue = new DoubleStackQueue<int>(5);
            Console.WriteLine("Enqueing 1, 2");
            queue.Enqueue(1);
            queue.Enqueue(2);

            Console.WriteLine("Dequeueing");
            Console.WriteLine("Element : {0}", queue.Dequeue());
            Console.WriteLine("Element : {0}", queue.Dequeue());

            Console.WriteLine("Enqueing Again 3, 4");
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine("Dequeueing Again");
            Console.WriteLine("Element : {0}", queue.Dequeue());

            Console.WriteLine("Enqueing Again 5, 6");
            queue.Enqueue(5);
            queue.Enqueue(6);

            Console.WriteLine("Dequeueing Again");
            Console.WriteLine("Element : {0}", queue.Dequeue());
            Console.WriteLine("Element : {0}", queue.Dequeue());
            Console.WriteLine("Element : {0}", queue.Dequeue());

        }
    }

    public class DoubleStackQueue<T>
    {
        private GenericStack<T> enqueueStack;
        private GenericStack<T> dequeueStack;
        public int Size { get; set; }

        public DoubleStackQueue(int size)
        {
            enqueueStack = new GenericStack<T>(size);
            dequeueStack = new GenericStack<T>(size);
        }

        public void Enqueue(T val)
        {
            enqueueStack.Push(val);
        }

        public T Dequeue()
        {
            if(dequeueStack.IsEmpty())
            {
                if (enqueueStack.IsEmpty())
                    return default(T);

                while(!enqueueStack.IsEmpty())
                {
                    dequeueStack.Push(enqueueStack.Pop());
                }
                return dequeueStack.Pop();
            }
            return dequeueStack.Pop();
        }

        public bool IsEmpty()
        {
            return enqueueStack.IsEmpty();
        }

        public bool IsFull()
        {
            return enqueueStack.IsFull();
        }
    }
}
