using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BinarySearchTree
{
    class PrintInRange
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating binary search tree ... !");
            int[] input = new int[] { 9, 15, 5, 20, 16, 8, 12, 3, 6 };
            Console.Write("Input Array - ({0})", string.Join(",", input));
            var root = BinarySearchTreeHelper.InitializeBinarySearchTree(input);
            Console.WriteLine();
            Console.WriteLine("Inorder traversal ... !");
            InOrder(root);

            int k1 = 5;
            int k2 = 12;
            Console.WriteLine();
            Console.WriteLine("Printing b/w 5 and 12");
            Print(root, k1, k2);
        }

        private static void Print(TreeNode node, int k1, int k2)
        {
            if (node == null) return;

            if (node.Value >= k1 && node.Value <= k2)
            {
                Console.Write(node.Value + " ");
                Print(node.Left, k1, k2);
                Print(node.Right, k1, k2);
            }
            else if (node.Value > k2)
            {
                Print(node.Left, k1, k2);
            }
            else if (node.Value < k1)
            {
                Print(node.Right, k1, k2);
            }
        }

        private static void InOrder(TreeNode node)
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
