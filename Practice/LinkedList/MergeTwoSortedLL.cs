using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class MergeTwoSortedLL
    {
        static void Main(string[] args)
        {
            // Merge two sorted LL without using third LL
            var numArray1 = new int[] { 2, 8, 10, 15, 18 };
            var ll1 = LLHelper.CreateLinkedList(numArray1);
            Console.WriteLine("First LL");
            LLHelper.Display(ll1.Head);
            Console.WriteLine();

            var numArray2 = new int[] { 4, 7, 12, 14, 17, 19, 20 };
            var ll2 = LLHelper.CreateLinkedList(numArray2);
            Console.WriteLine("Second LL");
            LLHelper.Display(ll2.Head);
            Console.WriteLine();

            Console.WriteLine("Merged LL");
            var third = Merge(ll1, ll2);
            LLHelper.Display(third);
            Console.WriteLine();
        }

        private static Node Merge(LinkedList ll1, LinkedList ll2)
        {
            Node first = ll1.Head;
            Node second = ll2.Head;
            Node third = null;
            Node last = null;

            if(first.Value < second.Value)
            {
                third = first;
                last = first;
                first = first.Next;
                last.Next = null;
            }
            else
            {
                third = second;
                last = second;
                second = second.Next;
                last.Next = null;
            }

            while(first != null && second != null)
            {
                if(first.Value < second.Value)
                {
                    last.Next = first;
                    last = first;
                    first = first.Next;
                    last.Next = null;
                }
                else
                {
                    last.Next = second;
                    last = second;
                    second = second.Next;
                    last.Next = null;
                }
            }

            if(first != null)
            {
                last.Next = first;
            }
            else
            {
                last.Next = second;
            }

            return third;
        }
    }
}
