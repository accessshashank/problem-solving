using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class ConcatenateLL
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 5, 10, 13, 12, 18, 20, 25 };
            var ll1 = LLHelper.CreateLinkedList(numArray);
            Console.WriteLine("First LL");
            LLHelper.Display(ll1.Head);
            Console.WriteLine();

            var numArray1 = new int[] { 100, 130, 150 };
            var ll2 = LLHelper.CreateLinkedList(numArray1);
            Console.WriteLine("Second LL");
            LLHelper.Display(ll2.Head);
            Console.WriteLine();

            var llConcat = Concatenate(ll1, ll2);
            Console.WriteLine("Cocatenated LL");
            LLHelper.Display(llConcat.Head);
            Console.WriteLine();

        }

        private static LinkedList Concatenate(LinkedList ll1, LinkedList ll2)
        {
            var temp = ll1.Head;

            while(temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = ll2.Head;

            return ll1;
        }
    }
}
