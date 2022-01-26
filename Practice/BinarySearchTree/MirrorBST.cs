using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BinarySearchTree
{
    class MirrorBST
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating binary search tree ... !");
            int[] input = new int[] { 9, 15, 5, 20, 16, 8, 12, 3, 6 };
            Console.Write("Input Array - ({0})", string.Join(",", input));
            var root = BinarySearchTreeHelper.InitializeBinarySearchTree(input);
            Console.WriteLine();
            /*
             *                                       9
             *                                   5        15
             *                                3     8   12    20
             *                                    6         16    
             * 
             */
            Console.WriteLine("Level Order Display Before");
            LevelOrderDisplay(root);

            Console.WriteLine("Level Order Display After");
            var root1 = Mirror(root);
            LevelOrderDisplay(root1);
        }

        private static TreeNode Mirror(TreeNode node)
        {
            if (node == null) return null;

            var left = Mirror(node.Left);
            var right = Mirror(node.Right);

            node.Left = right;
            node.Right = left;

            return node;
        }

        private static void LevelOrderDisplay(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
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
