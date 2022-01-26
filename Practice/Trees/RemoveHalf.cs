using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class RemoveHalf
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();
            LevelOrderDisplay(root);
            root = Remove(root);
            LevelOrderDisplay(root);
            InOrder(root);
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

        private static void InOrder(TreeNode<int> node)
        {
            if (node != null)
            {

                InOrder(node.Left);
                Console.Write("({0}), ", node.Value);
                InOrder(node.Right);
            }
        }

        private static bool IsHavingOnlyOneChild(TreeNode<int> node)
        {
            if (node.Left == null && node.Right == null) return false;

            if (node.Left != null && node.Right == null) return true;

            if (node.Left == null && node.Right != null) return true;

            return false;
        }

        private static TreeNode<int> Remove(TreeNode<int> node)
        {
            if (node == null) return null;

            if(IsHavingOnlyOneChild(node))
            {
                if(node.Left == null)
                {
                    node = node.Right;
                }
                else if(node.Right == null)
                {
                    node = node.Left;
                }
                node = Remove(node);
            }
            else
            {
                node.Left = Remove(node.Left);
                node.Right = Remove(node.Right);
            }

            return node;
        }
    }
}
