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
            var numArray = new int[] { 5, 10, 13, 12, 18, 20, 25 };
            var ll = LLHelper.CreateLinkedList(numArray);
            Console.WriteLine("Input LL");
            LLHelper.Display(ll.Head);
            Console.WriteLine();
            Console.WriteLine("Reversing LL using auxiliary array");
            ll = ReverseUsingArray(ll);
            LLHelper.Display(ll.Head);
            Console.WriteLine();
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
    }
}
