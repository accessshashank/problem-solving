using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class MiddleNodeOfLL
    {
        static void Main(string[] args) 
        {
            var numArray = new int[] { 2, 8, 10, 15, 18, 20 };
            var ll = LLHelper.CreateLinkedList(numArray);
            Console.WriteLine("Given LL");
            LLHelper.Display(ll.Head);
            Console.WriteLine();

            FindMiddleNode(ll.Head);
        }

        private static void FindMiddleNode(Node head)
        {
            var slow = head;
            var fast = head;

            while(fast != null)
            {
                fast = fast.Next;
                if (fast != null) fast = fast.Next;
                if (fast != null) slow = slow.Next;
            }

            Console.WriteLine("Middle node is {0}", slow.Value);
        }
    }
}
