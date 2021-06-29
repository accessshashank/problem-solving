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

            PerformBFS(3, vertices, visit);
            Console.WriteLine();
        }

        private static void PerformBFS(int u, int[,] vertices, int[] visit)
        {
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
    }
}
