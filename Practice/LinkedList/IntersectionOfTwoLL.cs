using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class IntersectionOfTwoLL
    {
        static void Main(string[] args)
        {
            var numArray = new int[] { 8, 6, 3, 9, 10, 4, 2, 12 };
            var ll = LLHelper.CreateLinkedList(numArray);
            Console.WriteLine("Given LL1");
            LLHelper.Display(ll.Head);
            Console.WriteLine();

            var numArray1 = new int[] { 20, 30, 40, 10, 4, 2, 12 };
            var ll1 = LLHelper.CreateLinkedList(numArray1);
            Console.WriteLine("Given LL2");
            LLHelper.Display(ll1.Head);
            Console.WriteLine();

            //create intersection point

            var fifthNodeInLL1 = ll.Head.Next.Next.Next.Next;
            var thirdNodeInLL2 = ll1.Head.Next.Next;

            thirdNodeInLL2.Next = fifthNodeInLL1;
            /////////////////////////

            FindIntersectionPoint(ll, ll1);

        }

        private static void FindIntersectionPoint(LinkedList ll1, LinkedList ll2)
        {
            var array1 = new Node[ll1.Length];
            var array2 = new Node[ll2.Length];

            var p = ll1.Head;
            int i = 0;
            while(p != null)
            {
                array1[i++] = p;
                p = p.Next;
            }

            var q = ll2.Head;
            int j = 0;
            while (q != null)
            {
                array2[j++] = q;
                q = q.Next;
            }

            i--;
            j--;
            bool scan = true;
            Node lastMatchedNode = null;
            while(scan)
            {
                if(array1[i] == array2[j])
                {
                    lastMatchedNode = array1[i];
                    i--;
                    j--;
                }
                else
                {
                    scan = false;
                }
            }

            Console.WriteLine("Intersection point is at Node {0}", lastMatchedNode.Value);

        }
    }
}
