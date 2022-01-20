using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class ReverseLL
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Reversing LL using auxiliary array");
            var numArray = new int[] { 5, 10, 13, 12, 18, 20, 25 };
            var ll = LLHelper.CreateLinkedList(numArray);
            Console.WriteLine("Input LL");
            LLHelper.Display(ll.Head);
            Console.WriteLine();
            ll = ReverseUsingArray(ll);
            LLHelper.Display(ll.Head);
            Console.WriteLine();

            Console.WriteLine("2. Reversing LL using sliding pointers");
            ll = LLHelper.CreateLinkedList(numArray);
            Console.WriteLine("Input LL");
            LLHelper.Display(ll.Head);
            Console.WriteLine();
            ll = ReverseUsingSlidingPointers(ll);
            LLHelper.Display(ll.Head);
            Console.WriteLine();

            Console.WriteLine("3. Reversing LL using recursion");
            ll = LLHelper.CreateLinkedList(numArray);
            Console.WriteLine("Input LL");
            LLHelper.Display(ll.Head);
            Console.WriteLine();
            ll = ReverseUsingRecursion(ll);
            LLHelper.Display(ll.Head);
            Console.WriteLine();
        }

        private static LinkedList ReverseUsingRecursion(LinkedList ll)
        {
            Node previous = null;
            Node current = ll.Head;

            ReverseRecursively(previous, current, ll);

            return ll;
        }

        private static void ReverseRecursively(Node previous, Node current, LinkedList ll)
        {
            if(current != null)
            {
                ReverseRecursively(current, current.Next, ll);
                current.Next = previous;
            }
            else
            {
                ll.Head = previous;
            }
        }

        private static LinkedList ReverseUsingSlidingPointers(LinkedList ll)
        {
            Node r = null;
            Node q = null;
            Node p = ll.Head;

            while(p != null)
            {
                r = q;
                q = p;
                p = p.Next;
                q.Next = r; 
            }

            ll.Head = q;
            return ll;
        }

        private static LinkedList ReverseUsingArray(LinkedList ll)
        {
            var auxArray = new int[ll.Length];
            var temp = ll.Head;
            int i = 0;
            while(temp != null)
            {
                auxArray[i++] = temp.Value;
                temp = temp.Next;
            }

            temp = ll.Head;
            i--;
            while(temp != null)
            {
                temp.Value = auxArray[i--];
                temp = temp.Next;
            }

            return ll;
        }

        private static void ReverseLL1(LinkedList ll)
        {
            Node r = null;
            Node q = null;
            Node p = ll.Head;

            while(p != null)
            {
                r = q;
                q = p;
                p = p.Next;
                q.Next = r;
            }

            ll.Head = q;
        }

        private static void ReverseLLRev(LinkedList ll)
        {
            Node previous = null;
            Node current = ll.Head;

            ReverseRec(previous, current, ll);
        }

        private static void ReverseRec(Node previous, Node current, LinkedList ll)
        {
            if(current != null)
            {
                ReverseRec(current, current.Next, ll);
                current.Next = previous;
            }
            else
            {
                ll.Head = previous;
            }
        }
    }
}
