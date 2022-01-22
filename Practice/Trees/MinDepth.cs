using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class MinDepth
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();
            Console.WriteLine("Min Depth : " + Minimum(root, root));
        }

        private static int Minimum(TreeNode<int> root, TreeNode<int> node)
        {
            if (node == null) return 0;

            Console.WriteLine("Current Node - " + node.Value);

            int h1 = Minimum(root, node.Left);
            int h2 = Minimum(root, node.Right);

            int maxHeight = Math.Max(h1, h2);

            if(node == root)
            {
                return Math.Min(h1, h2) + 1;
            }
            return maxHeight + 1;
        }
    }
}
