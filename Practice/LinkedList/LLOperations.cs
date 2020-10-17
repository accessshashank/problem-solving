using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class LLOperations
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of linked list : ");
            int size = int.Parse(Console.ReadLine());
            var numArray = new int[size];
            
            for(int i=1; i<=size; i++)
            {
                Console.Write("Enter value for Node {0} : ", i);
                numArray[i - 1] = int.Parse(Console.ReadLine());
            }

            LinkedList ll = CreateLinkedList(size, numArray);

            Console.WriteLine("Display !");
            var node = ll.Head;
            while(node != null)
            {
                Console.Write(node.Value + "->");
                node = node.Next;
            }

            Console.WriteLine();
        }

        private static LinkedList CreateLinkedList(int size, int[] numArray)
        {
            var ll = new LinkedList(size);
            var node = new Node();
            node.Value = numArray[0];
            node.Next = null;
            ll.Head = node;
            ll.Tail = node;

            for(int i=1; i< numArray.Length; i++)
            {
                var temp = new Node();
                temp.Value = numArray[i];
                temp.Next = null;
                ll.Tail.Next = temp;
                ll.Tail = temp;
            }

            return ll;
        }
    }

    class LinkedList
    {
        public LinkedList(int size)
        {
            Length = size;
        }
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Length { get; private set; }
    }

    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }
}
