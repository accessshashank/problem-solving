using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class ReverseDoublyLL
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 1,2,3,4,5 };
            var dll = LLHelper.CreateDoublyLinkedList(numArray);

            Console.WriteLine("Display Forward");
            LLHelper.DisplayDoublyForward(dll.Head);

            Console.WriteLine();

            Console.WriteLine("Display Backward");
            LLHelper.DisplayDoublyBackward(dll.Tail);

            Console.WriteLine();
            Console.WriteLine("Reversing Doubly LL");
            dll = Reverse(dll);

            Console.WriteLine("Display Forward");
            LLHelper.DisplayDoublyForward(dll.Head);

            Console.WriteLine();

            Console.WriteLine("Display Backward");
            LLHelper.DisplayDoublyBackward(dll.Tail);

            Console.WriteLine();
        }

        private static DoublyLinkedList Reverse(DoublyLinkedList dll)
        {
            var p = dll.Head;   
            dll.Tail = p;
            while(p != null)
            {
                var temp = p.Next;
                p.Next = p.Previous;
                p.Previous = temp;
                if(p.Previous == null)
                {
                    dll.Head = p;
                }
                p = p.Previous;
            }

            return dll;
        }
    }
}
