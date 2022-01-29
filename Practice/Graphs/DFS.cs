using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Graphs
{
    class DFS
    {
        static void Main(string[] args)
        {
            int[,] vertices = new int[8, 8] {
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

            Console.WriteLine("DFS using adjacency matrix");
            PerformDFSUsingAdjacencyMatrix(1, vertices, visit);

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

            Console.WriteLine("DFS using adjacency list");
            PerformDFSUsingAdjacencyList(1, arrayVertices, visit);
            Console.WriteLine();
        }

        private static void PerformDFSUsingAdjacencyList(int u, LinkedList<int>[] arrayVertices, int[] visit)
        {
            if(visit[u] == 0)
            {
                Console.Write(u + "->");
                visit[u] = 1;
                var allVertices = arrayVertices[u];
                var enumerate = allVertices.GetEnumerator();
                while (enumerate.MoveNext())
                {
                    PerformDFSUsingAdjacencyList(enumerate.Current, arrayVertices, visit);
                }
            }
        }

        private static void PerformDFSUsingAdjacencyListV2(int u, LinkedList<int>[] arrayVertices, int[] visit)
        {
           if(visit[u] == 0)
            {
                Console.Write(u + "->");
                visit[u] = 1;

                var allVertices = arrayVertices[u];
                var enumerator = allVertices.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    PerformDFSUsingAdjacencyListV2(enumerator.Current, arrayVertices, visit);
                }
            }
        }

        private static void PerformDFSUsingAdjacencyMatrix(int u, int[,] vertices, int[] visit)
        {
            if(visit[u] == 0)
            {
                Console.Write(u + "->");
                visit[u] = 1;
                for(int v = 1; v < 8; v++)
                {
                    if(vertices[u,v] == 1 && visit[v] == 0)
                    {
                        PerformDFSUsingAdjacencyMatrix(v, vertices, visit);
                    }
                }
            }
        }

        private static void PerformDFSUsingAdjacencyMatrixV2(int u, int[,] vertices, int[] visit)
        {
            if(visit[u] == 0)
            {
                Console.Write(u + "->");
                visit[u] = 1;

                for(int v =1; v<8; v++)
                {
                    if(vertices[u,v] == 1 && visit[v] == 0)
                    {
                        PerformDFSUsingAdjacencyMatrixV2(v, vertices, visit);
                    }
                }
            }
        }
    }
}
