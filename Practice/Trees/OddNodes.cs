using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class OddNodes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();

            Console.WriteLine("Level Order Display");
            LevelOrderDisplay(root);

            Console.WriteLine("Nodes at ODD level, root treated as level 1");
            Odd(root);
        }

        private static void Odd(TreeNode<int> node)
        {
            var queue = new Queue<TreeNode<int>>();
            queue.Enqueue(node);
            //Console.Write(node.Value + " ");
            int level = 1;
            while(queue.Any())
            {
                
                int size = queue.Count;

                while(size > 0)
                {
                    var n = queue.Dequeue();
                    size--;
                    if(level % 2 == 1)
                    {
                        Console.Write(n.Value + " ");
                    }

                    if (n.Left != null)
                        queue.Enqueue(n.Left);

                    if (n.Right != null)
                        queue.Enqueue(n.Right);
                }
                level++;
            }

            Console.WriteLine();
        }

        private static void LevelOrderDisplay(TreeNode<int> root)
        {
            var queue = new Queue<TreeNode<int>>();
            var currentNode = root;
            queue.Enqueue(root);
            queue.Enqueue(null);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == null && queue.Count == 0)
                {
                    Console.WriteLine();
                    return;
                }
                else if (node == null)
                {
                    Console.WriteLine();
                    queue.Enqueue(null);
                    continue;
                }
                Console.Write(node.Value + " ");
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }

            }
        }
    }
}
