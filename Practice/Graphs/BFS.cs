using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Graphs
{
    class BFS
    {
        static void Main(string[] args)
        {
            int[,] vertices = new int[8,8] { 
                {-1, -1, -1, -1, -1, -1, -1, -1 },
                {-1, 0, 1, 1, 1, 0, 0, 0 },
                {-1, 1, 0, 1, 0, 0, 0, 0 },
                {-1, 1, 1, 0, 1, 1, 0, 0 },
                {-1, 1, 0, 1, 0, 1, 0, 0 },
                {-1, 0, 0, 1, 1, 0, 1, 1 },
                {-1, 0, 0, 0, 0, 1, 0, 0 },
                {-1, 0, 0, 0, 0, 1, 0, 0 }
            };

            int[] visit = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            PerformBFSUsingAdjacencyMatrix(5, vertices, visit);
            Console.WriteLine();

            LinkedList<int>[] arrayVertices = new LinkedList<int>[8];
            arrayVertices[0] = null;
            arrayVertices[1] = new LinkedList<int>();
            arrayVertices[1].AddLast(2);
            arrayVertices[1].AddLast(3);
            arrayVertices[1].AddLast(4);

            arrayVertices[2] = new LinkedList<int>();
            arrayVertices[2].AddLast(1);
            arrayVertices[2].AddLast(3);

            arrayVertices[3] = new LinkedList<int>();
            arrayVertices[3].AddLast(1);
            arrayVertices[3].AddLast(2);
            arrayVertices[3].AddLast(4);
            arrayVertices[3].AddLast(5);

            arrayVertices[4] = new LinkedList<int>();
            arrayVertices[4].AddLast(1);
            arrayVertices[4].AddLast(3);
            arrayVertices[4].AddLast(5);

            arrayVertices[5] = new LinkedList<int>();
            arrayVertices[5].AddLast(3);
            arrayVertices[5].AddLast(4);
            arrayVertices[5].AddLast(6);
            arrayVertices[5].AddLast(7);

            arrayVertices[6] = new LinkedList<int>();
            arrayVertices[6].AddLast(5);

            arrayVertices[7] = new LinkedList<int>();
            arrayVertices[7].AddLast(5);

            visit = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            PerformBFSUsingAdjacencyList(5, arrayVertices, visit);

            Console.WriteLine();
        }

        private static void PerformBFSUsingAdjacencyMatrix(int u, int[,] vertices, int[] visit)
        {
            Console.WriteLine("BFS using adjacency matrix");
            var queue = new Queue<int>();
            Console.Write(u + "->");
            visit[u] = 1;
            queue.Enqueue(u);

            while(queue.Any())
            {
                u = queue.Dequeue();
                for(int v=1; v<8; v++)
                {
                    if(vertices[u, v] == 1 && visit[v] == 0)
                    {
                        Console.Write(v + "->");
                        visit[v] = 1;
                        queue.Enqueue(v);
                    }
                }
            }
        }

        private static void PerformBFSUsingAdjacencyList(int u, LinkedList<int>[] arrayVertices, int[] visit)
        {
            Console.WriteLine("BFS using adjacency list");
            var queue = new Queue<int>();
            Console.Write(u + "->");
            visit[u] = 1;
            queue.Enqueue(u);

            while (queue.Any())
            {
                u = queue.Dequeue();
                var allVertices = arrayVertices[u];
                var enumerate = allVertices.GetEnumerator();
                while(enumerate.MoveNext())
                {
                    var v = enumerate.Current;
                    if(visit[v] == 0)
                    {
                        Console.Write(v + "->");
                        visit[v] = 1;
                        queue.Enqueue(v);
                    }
                }
            }
        }
    }
}
