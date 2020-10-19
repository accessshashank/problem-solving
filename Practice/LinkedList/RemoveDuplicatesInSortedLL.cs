using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class RemoveDuplicatesInSortedLL
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 3, 5, 5, 8, 8, 8, 12};
            var ll = LLHelper.CreateLinkedList(numArray);
            Console.WriteLine("Input LL");
            LLHelper.Display(ll.Head);
            Console.WriteLine();
            Console.WriteLine("After duplicates removal");

            ll = RemoveDuplicates(ll);

            LLHelper.Display(ll.Head);
        }

        private static LinkedList RemoveDuplicates(LinkedList ll)
        {
            Node previous = ll.Head;
            Node current = ll.Head.Next;

            while(current != null)
            {
                if(previous.Value != current.Value)
                {
                    previous = current;
                    current = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                    current = null;
                    current = previous.Next;
                }
            }

            return ll;
        }
    }
}
