using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Heap
{
    class MaximumProduct
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {3, 4, 5, 2 };

            int[] heapArray = new int[arr.Length + 1];
            heapArray[0] = -1;

            for(int i =0; i<arr.Length;i++)
            {
                heapArray[i + 1] = arr[i];
                heapArray = CreateHeap(heapArray, i + 1);
            }

            int val1 = heapArray[1];
            int val2 = Math.Max(heapArray[2], heapArray[3]);
            Console.WriteLine((val1 - 1) * (val2 - 1));

            
        }

        private static int[] CreateHeap(int[] heapArray, int index)
        {
            if (index == 1) return heapArray;

            int temp = heapArray[index];
            int i = index;

            while(i > 1 && temp > heapArray[i/2])
            {
                heapArray[i] = heapArray[i / 2];
                i = i / 2;
            }
            heapArray[i] = temp;
            return heapArray;
        }
    }
}
