using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class TargetPathSum
    {
        private static List<List<int>> output = new List<List<int>>();

        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5293164#overview
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();

            var targetSum = 22;
            List<int> temp = new List<int>();

            TargetSum(root, targetSum, temp, 0);

            foreach (var outer in output)
            {
                foreach (var inner in outer)
                {
                    Console.Write(inner + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Copy(List<int> temp)
        {
            List<int> c = new List<int>();
            foreach (var item in temp)
            {
                c.Add(item);
            }

            output.Add(c);
        }

        private static void TargetSum(TreeNode<int> node, int targetSum, List<int> temp, int currentSum)
        {
            if(node.Left == null && node.Right == null)
            {
                if(targetSum == currentSum + node.Value)
                {
                    temp.Add(node.Value);
                    Copy(temp);
                    temp.Remove(node.Value);
                    return;
                }
            }

            if(node.Left != null)
            {
                temp.Add(node.Value);
                TargetSum(node.Left, targetSum, temp, currentSum + node.Value);
                temp.Remove(node.Value);
            }

            if (node.Right != null)
            {
                temp.Add(node.Value);
                TargetSum(node.Right, targetSum, temp, currentSum + node.Value);
                temp.Remove(node.Value);
            }
        }
    }
}
