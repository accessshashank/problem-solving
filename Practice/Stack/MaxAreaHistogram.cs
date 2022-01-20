using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Stack
{
    class MaxAreaHistogram
    {
        static void Main(string[] args)
        {
            int[] histogram = new int[] { 6, 2, 5, 4, 5, 1, 6 };
            Console.WriteLine(FindMaxArea(histogram));
        }

        private static int FindMaxArea(int[] histogram)
        {
            int maxArea = 0;
            int[] previousSmaller = FindPreviousSmaller(histogram);
            int[] nextSmaller = FindNextSmaller(histogram);

            for(int i=0; i<histogram.Length;i++)
            {
                int currentArea = (nextSmaller[i] - previousSmaller[i] - 1) * histogram[i];
                maxArea = Math.Max(maxArea, currentArea);
            }

            return maxArea;
        }

        //Note that we will be putting indexes and not values
        private static int[] FindNextSmaller(int[] histogram)
        {
            int[] nextSmaller = new int[histogram.Length];

            var stack = new Stack<int>();

            for (int i = histogram.Length - 1; i >= 0; i--)
            {
                int val = histogram[i];

                while (stack.Count > 0 && histogram[stack.Peek()] >= val)
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    nextSmaller[i] = histogram.Length - 1; // This will help in area calc. Avoiding setting -1.
                }
                else
                {
                    nextSmaller[i] = stack.Peek();
                }
                stack.Push(i);

            }
            return nextSmaller;
        }

        //Note that we will be putting indexes and not values
        private static int[] FindPreviousSmaller(int[] histogram)
        {
            int[] previousSmaller = new int[histogram.Length];

            var stack = new Stack<int>();

            for(int i=0; i<histogram.Length;i++)
            {
                int val = histogram[i];

                while(stack.Count > 0 && histogram[stack.Peek()] >= val)
                {
                    stack.Pop();
                }

                if(stack.Count == 0)
                {
                    previousSmaller[i] = -1;
                }
                else
                {
                    previousSmaller[i] = stack.Peek();
                }
                stack.Push(i);

            }
            return previousSmaller;
        }
    }
}
