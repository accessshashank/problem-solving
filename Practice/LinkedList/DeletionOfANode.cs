using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class DeletionOfANode
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 5, 10, 13, 15, 18, 20, 25 };
            var ll = LLHelper.CreateLinkedList(numArray);
            Console.WriteLine("Initial LL");
            LLHelper.Display(ll.Head);
            ll = DeleteFirstNode(ll);
            Console.WriteLine();
            Console.WriteLine("LL after first node deletion");
            LLHelper.Display(ll.Head);
            Console.WriteLine();
            Console.WriteLine("LL after 4th node deletion");
            ll = DeleteNode(ll, 4);
            LLHelper.Display(ll.Head);
            Console.WriteLine();
        }

        private static LinkedList DeleteNode(LinkedList ll, int position)
        {
            Node previous = null;
            Node current = ll.Head;
            for(int i=2; i<=position;i++)
            {
                previous = current;
                current = current.Next;
            }

            previous.Next = current.Next;
            current = null;
            return ll;
        }

        private static LinkedList DeleteFirstNode(LinkedList ll)
        {
            var temp = ll.Head;
            ll.Head = temp.Next;
            temp = null;
            return ll;
        }
    }
}
