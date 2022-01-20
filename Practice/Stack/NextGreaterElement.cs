using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class NextGreaterElement
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5265248#overview
            int[] arr = new int[] {4, 5, 3, 1, 2, 25 };
            var a = NextGreater(arr, arr.Length);
            Console.WriteLine(string.Join(",", a));

            var ab = NextGreaterAnother(arr, arr.Length);
            Console.WriteLine(string.Join(",", ab));
        }

        private static int[] NextGreaterAnother(int[] arr, int length)
        {
            int n = length;
            int[] arr1 = new int[n];

            Stack<int> s = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                while (s.Count > 0 && s.Peek() <= arr[i])
                    s.Pop();

                if (s.Count == 0)
                    arr1[i] = -1;
                else
                    arr1[i] = s.Peek();

                s.Push(arr[i]);
            }
            return arr1;
        }

        private static int[] NextGreater(int[] arr, int length)
        {
            int[] a = new int[length];
            var stack = new Stack<int>();
            int[] temp = new int[length];
            int k = 0;

            for(int i = length-1; i >=0; i--)
            {
                stack.Push(arr[i]);
            }

            for(int i=0; i<length;i++)
            {
                int current = stack.Pop();
                k = 0;
                while(stack.Count > 0 && stack.Peek() < current)
                {
                    temp[k++] = stack.Pop();
                }

                if(stack.Count == 0)
                {
                    a[i] = -1;
                }
                else
                {
                    a[i] = stack.Peek();
                    k--;
                    while(k >=0)
                    {
                        stack.Push(temp[k]);
                        k--;
                    }
                }
            }
            return a;
        }
    }
}
