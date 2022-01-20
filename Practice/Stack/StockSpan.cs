using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class StockSpan
    {
        static void Main(string[] args)
        {
            int[] stockArray = new int[] { 100, 80, 60, 70, 60, 75, 85 };
            int len = stockArray.Length;

            var spans = Spans(stockArray, len);
            Console.WriteLine(string.Join(",", spans));
        }

        private static int[] Spans(int[] stockArray, int len)
        {
            int[] spans = new int[len];
            var stack = new Stack<int>();

            stack.Push(0); // first index of stock array
            spans[0] = 1; // first span will always be 1

            for(int i=1; i<len;i++)
            {
                int currentPrice = stockArray[i];
                while(stack.Count > 0 && stockArray[stack.Peek()] < currentPrice)
                {
                    stack.Pop();
                }
                
                if(stack.Count == 0)
                {
                    spans[i] = i + 1;
                }
                else
                {
                    spans[i] = i - stack.Peek();
                }
                stack.Push(i);
            }

            return spans;
        }
    }
}
