using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class CircularLL
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 2, 8, 10, 15, 18 };
            var ll = LLHelper.CreateLinkedList(numArray);
            var head = ll.Head;
            var fifthTerm = head.Next.Next.Next.Next;
            fifthTerm.Next = head; // Made LL Circular

            Console.WriteLine("Display Iteratively");
            Display(ll);

            Console.WriteLine("Display Recursively");
            DisplayRecursively(ll.Head, ll.Head, true);
            Console.WriteLine();

            Console.WriteLine("Insert 100 before first node");
            ll = InsertNodeAtFirstPosition(ll);
            Display(ll);

            Console.WriteLine("Delete first node");
            ll = DeleteNodeAtFirstPosition(ll);
            Display(ll);
        }

        private static LinkedList DeleteNodeAtFirstPosition(LinkedList ll)
        {
            var temp = ll.Head;
            while(temp.Next != ll.Head)
            {
                temp = temp.Next;
            }

            temp.Next = ll.Head.Next;
            ll.Head = temp.Next;
            return ll;
        }

        private static LinkedList InsertNodeAtFirstPosition(LinkedList ll)
        {
            Node node = new Node();
            node.Value = 100;
            node.Next = ll.Head;
            var p = ll.Head;
            while(p.Next != ll.Head)
            {
                p = p.Next;
            }
            p.Next = node;
            ll.Head = node;

            return ll;
        }

        private static void DisplayRecursively(Node head, Node temp, bool isFirstIteration)
        {
            if(temp != head || isFirstIteration)
            {
                Console.Write(temp.Value + "->");
                DisplayRecursively(head, temp.Next, false);
            }
        }

        private static void Display(LinkedList ll)
        {
            var head = ll.Head;
            var temp = head;
            do 
            {
                Console.Write(temp.Value + "->");
                temp = temp.Next;
            } while(temp != head);
            Console.WriteLine();
        }
    }
}
