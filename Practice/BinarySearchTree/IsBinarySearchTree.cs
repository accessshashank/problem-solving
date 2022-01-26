using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Trees;

namespace Practice.BinarySearchTree
{
    class IsBinarySearchTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();

            Console.WriteLine(IsBST(root));
        }

        private static bool IsBST(TreeNode<int> node)
        {
            if(node == null)
            {
                return true;
            }

            if(node.Left == null && node.Right == null)
            {
                return true;
            }

            bool leftCondition = node.Left != null ? (node.Value > node.Left.Value) : true;
            bool rightCondition = node.Right != null ? (node.Value < node.Right.Value) : true;

            bool isBST = leftCondition && rightCondition;

            return isBST && IsBST(node.Left) && IsBST(node.Right);
        }
    }
}
