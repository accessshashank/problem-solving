using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Queue
{
    class CircularQueue
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of Circular Queue : ");
            Console.ReadLine();
            int size = 3;
            Console.WriteLine("Sorry...Taking size as 3");
            size = size + 1; // NOTE : Size should always be one extra because one array slot will always be kept empty as per logic/rule/algorithm.
            var queue = new GenericCircularQueue<int>(size);
            for (int i = 1; i < size; i++)
            {
                Console.Write("Enter Element {0} : ", i);
                var element = int.Parse(Console.ReadLine());
                queue.Enqueue(element);
            }

            Console.WriteLine("Queue is full : {0}, Dequeueing ... !", queue.IsFull());

            Console.WriteLine("Dequeue element : {0}", queue.Dequeue());
            Console.WriteLine("Dequeue element : {0}", queue.Dequeue());

            Console.WriteLine("Queueing 50, 60 ");
            queue.Enqueue(50);
            queue.Enqueue(60);
            Console.WriteLine("Dequeing again till empty ... !");
            while (!queue.IsEmpty())
            {
                Console.WriteLine("Dequeue element : {0}", queue.Dequeue());
            }

        }
    }

    public class GenericCircularQueue<T>
    {
        private readonly T[] arr;
        public int Size { get; set; }
        private int Front = 0;
        private int Rear = 0;

        public GenericCircularQueue(int size)
        {
            Size = size;
            Front = 0;
            Rear = 0;
            arr = new T[size];
        }

        public void Enqueue(T val)
        {
            if (IsFull()) throw new Exception("Queue is full ... !");
            Rear = (Rear + 1) % Size;
            arr[Rear] = val; ;
        }

        public T Dequeue()
        {
            if (IsEmpty()) throw new Exception("Queue is empty ... !");
            Front = (Front + 1) % Size;
            return arr[Front];
        }

        public bool IsEmpty()
        {
            bool isEmpty = Front == Rear;
            if (isEmpty)
            {
                Front = 0;
                Rear = 0;
            }
            return isEmpty;
        }

        public bool IsFull()
        {
            var nextRear = (Rear + 1) % Size;
            return nextRear == Front;
        }
    }
}
