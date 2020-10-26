using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Queue
{
    class QueueUsingLL
    {
        static void Main(string[] args)
        {
            Console.Write("How many elements you want to put in Queue: ");
            int n = int.Parse(Console.ReadLine());
            var queue = new GenericLLQueue<int>();
            Console.WriteLine("Queueing ... ! ");
            for (int i=1; i<=n; i++)
            {
                Console.Write("Enter element {0} : ", i);
                int elem = int.Parse(Console.ReadLine());
                queue.Enqueue(elem);
            }
            Console.WriteLine("Dequeueing ... ! ");
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Element {0} : {1}", i, queue.Dequeue());
            }
            Console.WriteLine("Queue Empty : {0}, Dequeueing default value : {1}", queue.IsEmpty(), queue.Dequeue());
        }
    }

    public class GenericLLQueue<T>
    {
        private LinkedList<T> ll;
        private Node<T> Front;
        private Node<T> Rear;

        public GenericLLQueue()
        {
            ll = new LinkedList<T>();
            Front = ll.Head;
            Rear = ll.Tail;
        }

        public void Enqueue(T val)
        {
            if(Front == null && Rear == null) // first node or element to queue
            {
                var node = new Node<T>();
                node.Value = val;
                node.Next = null;
                ll.Head = node;
                ll.Tail = node;
                Front = node;
                Rear = node;
            }
            else
            {
                var node = new Node<T>();
                node.Value = val;
                node.Next = null;
                ll.Tail.Next = node;
                ll.Tail = node;
                Rear = ll.Tail;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty()) return default(T);

            var p = ll.Head;
            T val = p.Value;
            p = p.Next;
            ll.Head = p;
            Front = p;
            if(p == null) // last node
            {
                ll.Tail = null;
                Rear = null;
            }
            p = null;
            return val;
        }

        public bool IsEmpty()
        {
            return Front == null && Rear == null;
        }

        public class LinkedList<T>
        {
            public Node<T> Head { get; set; }
            public Node<T> Tail { get; set; }
        }

        public class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
        }
    }
}
