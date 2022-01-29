using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Heap
{
    class WeakestRow
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5293174#overview
            int m = 4;
            int n = 4;
            int[,] mat = new int[4, 4] { {1, 0, 0, 0 }, {1, 1, 1, 1, }, {1, 0, 0, 0 }, {1, 0, 0, 0 } };
            Weakness[] ip = new Weakness[5];
            Weakness[] op = new Weakness[5];
            ip[0] = null;
            op[0] = null;

            int k = 1;
            for(int i =0; i< 4; i++)
            {
                int sum = 0;
                for(int j = 0; j < 4; j++)
                {
                    sum = sum + mat[i, j];
                }
                ip[k++] = new Weakness { NoOfSoldiers = sum, Index = i } ;
            }

            for(int i = 1; i< 5; i++)
            {
                op[i] = ip[i];
                op = GetMinHeap(op, i);
            }

            Weakness secondWeakest = null;
            if(op[2].NoOfSoldiers < op[3].NoOfSoldiers)
            {
                secondWeakest = op[2];
            }
            else if(op[2].NoOfSoldiers > op[3].NoOfSoldiers)
            {
                secondWeakest = op[3];
            }
            else if(op[2].Index < op[3].Index)
            {
                secondWeakest = op[2];
            }
            else
            {
                secondWeakest = op[3];
            }

            var opArray = new int[] { op[1].Index, secondWeakest.Index };

            Console.WriteLine("["+string.Join(",", opArray)+"]");
        }

        private static Weakness[] GetMinHeap(Weakness[] op, int index)
        {
            if (index == 1) return op;

            var current = op[index];
            int i = index;

            while(i > 1 && Condition(current, op, i))
            {
                op[i] = op[i / 2];
                i = i / 2;
            }

            return op;
        }

        private static bool Condition(Weakness current, Weakness[] op, int index)
        {
            int childIndex = index;
            int parentIndex = index / 2;
            Weakness w = op[parentIndex];
            if(current.NoOfSoldiers < w.NoOfSoldiers)
            {
                return true;
            }
            if(current.Index < w.Index)
            {
                return true;
            }

            return false;
        }
    }

    class Weakness {
        public int NoOfSoldiers { get; set; }
        public int Index { get; set; }
    }
}
