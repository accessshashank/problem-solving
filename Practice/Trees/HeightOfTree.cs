using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class HeightOfTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();
            Console.WriteLine("Calculating height ... !");

            Console.WriteLine(Height(root));
        }

        private static int Height(TreeNode<int> node)
        {
            if(node == null)
            {
                return 0;
            }

            int h1 = Height(node.Left);
            int h2 = Height(node.Right);

            return 1 + Math.Max(h1, h2);
        }
    }
}
