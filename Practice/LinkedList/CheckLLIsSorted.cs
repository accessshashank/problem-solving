using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class CheckLLIsSorted
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 5, 10, 13, 12, 18, 20, 25 };
            var ll = LLHelper.CreateLinkedList(numArray);
            Console.WriteLine("Input LL");
            LLHelper.Display(ll.Head);
            CheckSorted(ll);
        }

        private static void CheckSorted(LinkedList ll)
        {
            bool isSorted = true;
            var x = int.MinValue;
            var temp = ll.Head;
            while(temp != null)
            {
                if (temp.Value < x)
                    isSorted = false;

                x = temp.Value;
                temp = temp.Next;
            }

            Console.WriteLine();
            Console.WriteLine("IsSorted : {0}", isSorted);
        }
    }
}
