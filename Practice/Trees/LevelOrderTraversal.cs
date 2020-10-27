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
            var root = BinaryTreeHelper.InitializeBinaryTree();
            Console.WriteLine("Level Traversal ... !");
            LevelTraversal(root);
            Console.WriteLine();
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
