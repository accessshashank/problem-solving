using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class CountNodesInBinaryTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTree();
            Console.WriteLine("Counting nodes ... !");
            int count = Count(root);
            Console.WriteLine("Total nodes = {0}", count);
            int nodesHavingBothChildren = CountNodesHavingBothChildren(root);
            Console.WriteLine("Total nodes having both children = {0}", nodesHavingBothChildren);
            int leafNodes = CountLeafNodes(root);
            Console.WriteLine("Leaf nodes = {0}", leafNodes);
            int leftChildNodes = CountNodesHavingONLYLeftChild(root);
            Console.WriteLine("Nodes with ONLY left child = {0}", leftChildNodes);
            int height = Depth(root);
            Console.WriteLine("Depth of Tree = {0}", height);
        }

        //the number of  
        //nodes along the longest path from the root node
        //down to the farthest leaf node
        private static int Depth(TreeNode<int> node)
        {
            int leftCount = 0; int rightCount = 0;
            if (node != null)
            {
                leftCount = Depth(node.Left);
                rightCount = Depth(node.Right);
                if (leftCount > rightCount) return leftCount + 1;
                return rightCount + 1;
            }
            return 0;
        }

        private static int CountNodesHavingONLYLeftChild(TreeNode<int> node)
        {
            int leftCount = 0; int rightCount = 0;
            if (node != null)
            {
                leftCount = CountNodesHavingONLYLeftChild(node.Left);
                rightCount = CountNodesHavingONLYLeftChild(node.Right);
                if (node.Left != null && node.Right == null)
                    return leftCount + rightCount + 1;
                return leftCount + rightCount;
            }
            return 0;
        }

        private static int CountLeafNodes(TreeNode<int> node)
        {
            int leftCount = 0; int rightCount = 0;
            if (node != null)
            {
                leftCount = CountLeafNodes(node.Left);
                rightCount = CountLeafNodes(node.Right);
                if (node.Left == null && node.Right == null)
                    return leftCount + rightCount + 1;
                return leftCount + rightCount;
            }
            return 0;
        }

        private static int CountNodesHavingBothChildren(TreeNode<int> node)
        {
            int leftCount = 0; int rightCount = 0;
            if (node != null)
            {
                leftCount = CountNodesHavingBothChildren(node.Left);
                rightCount = CountNodesHavingBothChildren(node.Right);
                if (node.Left != null && node.Right != null)
                    return leftCount + rightCount + 1;
                return leftCount + rightCount;
            }
            return 0;
        }

        private static int Count(TreeNode<int> node)
        {
            int leftCount = 0; int rightCount = 0;
            if(node != null)
            {
                leftCount = Count(node.Left);
                rightCount = Count(node.Right);
                return leftCount + rightCount + 1;
            }
            return 0;
        }
    }
}
