using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class KthElementFromLast
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5245878#overview

            var numArray = new int[] {1, 2, 3, 4, 5, 6, 7 };
            int k = 3; //Find 3rd from last (5)
            

            LinkedList ll = LLHelper.CreateLinkedList(numArray);

            Node slow = ll.Head;
            Node fast = ll.Head;

            for(int i =1; i<=k;i++)
            {
                fast = fast.Next;
            }
            while(fast != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            Console.WriteLine(slow.Value);
        }
    }
}
