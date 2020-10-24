using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Queue
{
    class QueueUsingGeneric
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of Queue : ");
            int size = int.Parse(Console.ReadLine());

            var queue = new GenericQueue<int>(size);
            for(int i=1; i<=size; i++)
            {
                Console.Write("Enter Element {0} : ", i);
                var element = int.Parse(Console.ReadLine());
                queue.Enqueue(element);
            }

            Console.WriteLine("Queue is full : {0}, Dequeueing ... !", queue.IsFull());
            for (int i = 1; i <= size; i++)
            {
                Console.Write("Element {0} : {1}", i, queue.Dequeue());
                Console.WriteLine();
            }
            Console.WriteLine("Queue is empty : {0}", queue.IsEmpty());
        }
    }

    public class GenericQueue<T>
    {
        private readonly T[] arr;
        public int Size { get; set; }
        private int Front = -1;
        private int Rear = -1;

        public GenericQueue(int size)
        {
            Size = size;
            Front = -1;
            Rear = -1;
            arr = new T[size];
        }

        public void Enqueue(T val)
        {
            if (IsFull()) throw new Exception("Queue is full ... !");
            arr[++Rear] = val; ;
        }

        public T Dequeue()
        {
            if (IsEmpty()) throw new Exception("Queue is empty ... !");
            return arr[++Front];
        }

        public bool IsEmpty()
        {
            bool isEmpty =  Front == Rear;
            if(isEmpty)
            {
                Front = -1;
                Rear = -1;
            }
            return isEmpty;
        }

        public bool IsFull()
        {
            return Rear == Size - 1;
        }
    }
}
