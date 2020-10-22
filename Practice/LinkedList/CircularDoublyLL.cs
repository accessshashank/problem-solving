using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class CircularDoublyLL
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 1, 2, 3, 4, 5 };
            var dll = LLHelper.CreateDoublyLinkedList(numArray);
            var termFirst = dll.Head;
            var termLast = dll.Tail;
            termFirst.Previous = termLast;
            termLast.Next = termFirst;

            Display(dll);

            Console.WriteLine("Inserting node 100 at first position");
            dll = InsertNodeAtFirstPosition(dll);

            Display(dll);
        }

        private static DoublyLinkedList InsertNodeAtFirstPosition(DoublyLinkedList dll)
        {
            var node = new DoublyNode();
            node.Value = 100;
            var head = dll.Head;
            var pointerToLastNode = head.Previous;
            
            node.Next = head;
            head.Previous = node;
            node.Previous = pointerToLastNode;
            pointerToLastNode.Next = node;

            dll.Head = node;
            return dll;
        }

        private static void Display(DoublyLinkedList dll)
        {
            Console.WriteLine("Display of circular doubly linked list");
            var p = dll.Head;

            do 
            {
                Console.Write(p.Value + "->");
                p = p.Next;
            } while (p != dll.Head);

            Console.WriteLine();
        }
    }
}
