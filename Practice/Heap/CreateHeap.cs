 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Heap
{
    // In max heap, a node will always be greater than its descendents
    // In min heap, a node will always be smaller than its descendents
    // A node at ith position will always have its left child at 2i position and right child at 2i+1 position
    // Implementation array index will start from 1 and not 0
    class CreateHeap
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of heap : ");
            int n = int.Parse(Console.ReadLine());
            var heapArray = new int[n+1];
            heapArray[0] = -1; // remember index should start from 1

            for(int i=1; i<=n; i++)
            {
                Console.Write("Enter element {0} : ", i);
                var elem = int.Parse(Console.ReadLine());
                heapArray[i] = elem;
                heapArray = InsertIntoMaxHeap(heapArray, i);
            }
            Console.WriteLine("Output Heap - ({0})", string.Join(",", heapArray.Where(x => x > -1)));
        }

        private static int[] InsertIntoMaxHeap(int[] heapArray, int indexOfInsertedElement)
        {
            if (indexOfInsertedElement == 1) return heapArray;

            int temp = heapArray[indexOfInsertedElement]; int i = indexOfInsertedElement;

            while(i > 1 && temp > heapArray[i/2]) // For min heap just change condition to i > 1 && temp < heapArray[i/2]
            {
                heapArray[i] = heapArray[i / 2];
                i /= 2;
            }
            heapArray[i] = temp;
            return heapArray;
        }
    }
}
