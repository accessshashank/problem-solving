using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class DiameterOfTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();
            Console.WriteLine("Diameter : " + Diameter(root));

        }

        private static int Diameter(TreeNode<int> root)
        {
            if (root == null) return 0;

            int D1 = Height(root.Left) + Height(root.Right);
            int D2 = Diameter(root.Left);
            int D3 = Diameter(root.Right);

            return Math.Max(D1, Math.Max(D2, D3));
        }

        private static int Height(TreeNode<int> node)
        {
            if (node == null)
            {
                return 0;
            }

            int h1 = Height(node.Left);
            int h2 = Height(node.Right);

            return 1 + Math.Max(h1, h2);
        }
    }
}
