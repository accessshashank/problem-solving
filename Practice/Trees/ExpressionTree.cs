using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class ExpressionTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV3();
            Console.WriteLine(Eval(root));
        }

        private static bool IsOp(string val)
        {
            if (val == "+" || val == "-" || val == "*" || val == "/") return true;
            return false;
        }

        private static int Eval(TreeNode<string> node)
        {
            if (node == null) return 0;

            if (IsOp(node.Value) == false) return int.Parse(node.Value);

            if (node.Value == "+") return Eval(node.Left) + Eval(node.Right);

            if (node.Value == "-") return Eval(node.Left) - Eval(node.Right);

            if (node.Value == "*") return Eval(node.Left) * Eval(node.Right);

            if (node.Value == "/") return Eval(node.Left) / Eval(node.Right);

            return 0;

        }
    }
}
