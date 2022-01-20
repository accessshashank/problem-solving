using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class SumOfNodes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();

            Console.WriteLine(Sum(root));
        }

        private static int Sum(TreeNode<int> root)
        {
            int sum = 0;

            var q = new Queue<TreeNode<int>>();

            q.Enqueue(root);

            while(q.Count > 0)
            {
                var node = q.Dequeue();

                sum = sum + node.Value;

                if (node.Left != null) q.Enqueue(node.Left);

                if (node.Right != null) q.Enqueue(node.Right);
            }

            return sum;
        }
    }
}
