using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class InvertBinaryTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTree();
            Console.WriteLine("Inorder  Recursive ... !");
            InOrder(root);
            Console.WriteLine();
            root = Invert(root);
            Console.WriteLine("Inorder  Recursive after revert... !");
            InOrder(root);
            Console.WriteLine();
        }

        private static TreeNode<int> Invert(TreeNode<int> node)
        {
            if (node == null) return null;
            var left = Invert(node.Left);
            var right = Invert(node.Right);

            node.Left = right;
            node.Right = left;

            return node;
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
    }
}
