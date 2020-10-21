using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class DoublyLL
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 2, 10, 15, 18, 20, 25 };
            var dll = LLHelper.CreateDoublyLinkedList(numArray);

            Console.WriteLine("Display Forward");
            LLHelper.DisplayDoublyForward(dll.Head);

            Console.WriteLine();

            Console.WriteLine("Display Backward");
            LLHelper.DisplayDoublyBackward(dll.Tail);

            Console.WriteLine();
            Console.WriteLine("Inserting 100 at first position");
            dll = InsertDoublyNodeAtFirstPosition(dll);

            Console.WriteLine("Display Forward");
            LLHelper.DisplayDoublyForward(dll.Head);

            Console.WriteLine();

            Console.WriteLine("Display Backward");
            LLHelper.DisplayDoublyBackward(dll.Tail);

            Console.WriteLine();

            Console.WriteLine("Insert 500 at third position");
            dll = InsertDoublyNodeAtNPosition(dll, 3);

            Console.WriteLine("Display Forward");
            LLHelper.DisplayDoublyForward(dll.Head);

            Console.WriteLine();

            Console.WriteLine("Display Backward");
            LLHelper.DisplayDoublyBackward(dll.Tail);

            Console.WriteLine();

            Console.WriteLine("Deleting node at first position");
            dll = DeleteDoublyNodeAtFirstPosition(dll);

            Console.WriteLine("Display Forward");
            LLHelper.DisplayDoublyForward(dll.Head);

            Console.WriteLine();

            Console.WriteLine("Display Backward");
            LLHelper.DisplayDoublyBackward(dll.Tail);

            Console.WriteLine();

            Console.WriteLine("Deleting node at third position");
            dll = DeleteDoublyNodeAtNPosition(dll, 3);

            Console.WriteLine("Display Forward");
            LLHelper.DisplayDoublyForward(dll.Head);

            Console.WriteLine();

            Console.WriteLine("Display Backward");
            LLHelper.DisplayDoublyBackward(dll.Tail);

            Console.WriteLine();

        }

        private static DoublyLinkedList DeleteDoublyNodeAtNPosition(DoublyLinkedList dll, int position)
        {
            var temp = dll.Head;
            for (int i = 1; i < position - 1; i++)
                temp = temp.Next;

            var nodeToDelete = temp.Next;
            temp.Next = nodeToDelete.Next;
            if(nodeToDelete.Next != null)
            nodeToDelete.Next.Previous = temp;

            return dll;
        }

        private static DoublyLinkedList DeleteDoublyNodeAtFirstPosition(DoublyLinkedList dll)
        {
            var head = dll.Head;

            head.Next.Previous = null;
            dll.Head = head.Next;
            head.Next = null;
            head = null;

            return dll;
        }

        private static DoublyLinkedList InsertDoublyNodeAtNPosition(DoublyLinkedList dll, int position)
        {
            var node = new DoublyNode();
            node.Value = 500;

            var temp = dll.Head;
            for(int i=1; i < position-1; i++)
            {
                temp = temp.Next;
            }

            //var nodeToDelete = temp.Next;
            node.Previous = temp;
            node.Next = temp.Next;
            temp.Next = node;
            if(node.Next != null)
            node.Next.Previous = node;

            return dll;
        }

        private static DoublyLinkedList InsertDoublyNodeAtFirstPosition(DoublyLinkedList dll)
        {
            var node = new DoublyNode();
            node.Value = 100;
            node.Previous = null;
            node.Next = dll.Head;
            dll.Head.Previous = node;
            dll.Head = node;

            return dll;
        }
    }
}
