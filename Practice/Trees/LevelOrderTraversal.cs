using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Queue;

namespace Practice.Trees
{
    class LevelOrderTraversal
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();
            Console.WriteLine("Level Traversal ... !");
            LevelTraversal(root);
            Console.WriteLine();
            LevelOrderDisplay(root);
            Console.WriteLine();
        }

        private static void LevelOrderDisplay(TreeNode<int> root)
        {
            var queue = new Queue<TreeNode<int>>();
            var currentNode = root;
            queue.Enqueue(root);
            queue.Enqueue(null);
            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                if(node == null && queue.Count == 0)
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
                if(node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if(node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }

            }
        }

        private static void LevelTraversal(TreeNode<int> root)
        {
            var queue = new GenericLLQueue<TreeNode<int>>();
            var node = root;
            Console.Write("({0}), ", node.Value);
            queue.Enqueue(node);

            while(!queue.IsEmpty())
            {
                node = queue.Dequeue();
                if(node.Left != null)
                {
                    Console.Write("({0}), ", node.Left.Value);
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    Console.Write("({0}), ", node.Right.Value);
                    queue.Enqueue(node.Right);
                }
            }
        }
    }
}
