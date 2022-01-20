using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class AlternateMerge
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5293152#overview
            var numArray = new int[] { 5, 7, 17, 13, 11 };
            LinkedList ll1 = LLHelper.CreateLinkedList(numArray);

            var numArray1 = new int[] { 12, 10, 2, 4, 6 };
            LinkedList ll2 = LLHelper.CreateLinkedList(numArray1);

            Node head = MergeLL(ll1, ll2);
        }

        private static Node MergeLL(LinkedList ll1, LinkedList ll2)
        {
            Node head = new Node();
            Node p = ll1.Head;
            head = p;
            Node q = null;

            Node r = ll2.Head;
            Node s = null;

            while(p != null && r != null)
            {
                q = p;
                p = p.Next;
                s = r;
                r = r.Next;

                q.Next = s;
                s.Next = p;
            }

            return head;
        }
    }
}
