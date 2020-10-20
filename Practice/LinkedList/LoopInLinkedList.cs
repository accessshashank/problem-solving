using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class LoopInLinkedList
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 5, 10, 13, 12, 18 };
            var ll = LLHelper.CreateLinkedList(numArray);
            ll = CreateLoopKnowingly(ll);
            CheckLoop(ll);

            var numArray1 = new int[] { 5, 10, 13, 12, 18, 20, 25 };
            var ll1 = LLHelper.CreateLinkedList(numArray1);
            CheckLoop(ll1);
        }

        private static void CheckLoop(LinkedList ll)
        {
            var slow = ll.Head;
            var fast = ll.Head;

            do
            {
                slow = slow.Next;
                fast = fast.Next;
                fast = fast != null ? fast.Next : fast;
            } while (slow != null && fast != null && slow != fast);

            if(slow == null || fast == null)
            {
                Console.WriteLine("This is NO LOOP in LL");
            }
            if(slow == fast)
            {
                Console.WriteLine("There is LOOP in LL");
            }
        }

        private static LinkedList CreateLoopKnowingly(LinkedList ll)
        {
            var temp = ll.Head;
            var term2 = temp.Next;
            var term5 = temp.Next.Next.Next.Next;
            term5.Next = term2;

            return ll;
        }
    }
}
