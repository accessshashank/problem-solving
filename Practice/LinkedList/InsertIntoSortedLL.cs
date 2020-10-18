using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class InsertIntoSortedLL
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 5, 10, 13, 15, 18, 20, 25 };
            var ll = LLHelper.CreateLinkedList(numArray);

            Console.WriteLine("The elements of linked list are : ");
            LLHelper.Display(ll.Head);

            Console.WriteLine();
            Console.WriteLine("Inserting number 2 ");
            int numberToInsert = 2;
            ll = InsertNum(ll, numberToInsert);
            LLHelper.Display(ll.Head);


            Console.WriteLine();
            Console.WriteLine("Inserting number 12 ");
            numberToInsert = 12;
            ll = InsertNum(ll, numberToInsert);
            LLHelper.Display(ll.Head);


            Console.WriteLine();
            Console.WriteLine("Inserting number 30 ");
            numberToInsert = 30;
            ll = InsertNum(ll, numberToInsert);
            LLHelper.Display(ll.Head);

            Console.WriteLine();
        }

        private static LinkedList InsertNum(LinkedList ll, int numberToInsert)
        {
            Node previous = null;
            Node current = ll.Head;
            if(current.Value > numberToInsert)
            {
                Node node = new Node();
                node.Value = numberToInsert;
                node.Next = ll.Head;
                ll.Head = node;
                return ll;
            }

            while(current != null && current.Value < numberToInsert)
            {
                previous = current;
                current = current.Next;
            }

            Node temp = new Node();
            temp.Value = numberToInsert;
            temp.Next = previous.Next;
            previous.Next = temp;
            return ll;
        }
    }
}
