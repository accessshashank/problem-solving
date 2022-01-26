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

            Console.WriteLine("Deleting elements : Only root is deleted everytime ");

            for(int i=n; i>1; i--)
            {
                heapArray = Delete(heapArray, i);
            }

            Console.WriteLine("Output (or sorted) Heap after all elements deletion- ({0})", string.Join(",", heapArray.Where(x => x > -1)));
        }

        private static int[] Delete(int[] heapArray, int heapSize)
        {
            var elementToBeDeleted = heapArray[1]; // only root can be deleted and index starts from 1 not 0
            heapArray[1] = heapArray[heapSize];
            int i = 1; int j = 2 * i;

            while(j < heapSize)
            {
                if(heapArray[j+1] > heapArray[j])
                {
                    j = j + 1;
                }

                if(heapArray[i] < heapArray[j])
                {
                    int temp = heapArray[j];
                    heapArray[j] = heapArray[i];
                    heapArray[i] = temp;
                    i = j;
                    j = 2 * i;
                }
                else
                {
                    break;
                }
            }

            heapArray[heapSize] = elementToBeDeleted; // this will make array sorted once all elements are deleted
            return heapArray;
        }

        private static int[] DeleteV2(int[] heapArray, int heapSize)
        {
            int elementToDelete = heapArray[1];
            heapArray[1] = heapArray[heapSize];
            int i = 1; int j = 2 * i;

            while(j < heapSize)
            {
                if(heapArray[j+1] > heapArray[j])
                {
                    j = j + 1;
                }

                if(heapArray[i] < heapArray[j])
                {
                    int temp = heapArray[i];
                    heapArray[i] = heapArray[j];
                    heapArray[j] = temp;
                    i = j;
                    j = 2 * i;
                }
                else
                {
                    break;
                }
            }

            heapArray[heapSize] = elementToDelete;
            return heapArray;
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

        private static int[] InsertIntoMaxHeapV2(int[] heapArray, int indexOfInsertedElement)
        {
            if (indexOfInsertedElement == 1) return heapArray;

            int temp = heapArray[indexOfInsertedElement];
            int i = indexOfInsertedElement;

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
