using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Stack;

namespace Practice.BinarySearchTree
{
    class GenerateBSTUsingPreorder
    {
        static void Main(string[] args)
        {
            int[] inputPreorder = new int[] { 30, 20, 10, 15, 25, 40, 50, 45 };
            Console.Write("Input Preorder Array - ({0})", string.Join(",", inputPreorder));
            Console.WriteLine();
            Console.WriteLine("Generating BST using Preorder array");
            TreeNode root1 = GenerateTreeFromPreorder(inputPreorder);
            Console.WriteLine("Finished generating BST using Preorder array");
            Console.WriteLine("Preorder traversal for dual verification ... !");
            PreOrder(root1);

            Console.WriteLine();
            Console.WriteLine();

            int[] inputPostorder = new int[] { 15, 10, 25, 20, 45, 50, 40, 30 };
            Console.Write("Input Postorder Array - ({0})", string.Join(",", inputPostorder));
            Console.WriteLine();
            Console.WriteLine("Generating BST using Postorder array");
            TreeNode root2 = GenerateTreeFromPostorder(inputPostorder);
            Console.WriteLine("Finished generating BST using Postorder array");
            Console.WriteLine("Postorder traversal for dual verification ... !");
            PostOrder(root2);
            Console.WriteLine();

        }

        private static TreeNode GenerateTreeFromPostorder(int[] input)
        {
            TreeNode temp = null;
            TreeNode p = null;
            int i = input.Length - 1;
            TreeNode root = new TreeNode();
            root.Value = input[i--];
            if (input.Length == 1) return root;

            var stack = new GenericStack<TreeNode>(input.Length);
            p = root;
            while (i >= 0)
            {
                if (input[i] < p.Value)
                {
                    temp = new TreeNode();
                    temp.Value = input[i--];
                    p.Left = temp;
                    stack.Push(p);
                    p = temp;
                }
                else
                {
                    if (input[i] > p.Value && (stack.IsEmpty() || input[i] < stack.Peek().Value))
                    {
                        temp = new TreeNode();
                        temp.Value = input[i--];
                        p.Right = temp;
                        p = temp;
                    }
                    else
                    {
                        p = stack.Pop();
                    }
                }
            }

            return root;
        }

        private static void PreOrder(TreeNode node)
        {
            if (node != null)
            {
                Console.Write("{0}, ", node.Value);
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }

        private static void PostOrder(TreeNode node)
        {
            if (node != null)
            {
                PostOrder(node.Left);
                PostOrder(node.Right);
                Console.Write("({0}), ", node.Value);
            }
        }

        private static TreeNode GenerateTreeFromPreorder(int[] input)
        {
            TreeNode temp = null;
            TreeNode p = null;
            int i = 0;
            TreeNode root = new TreeNode();
            root.Value = input[i++];
            if (input.Length == 1) return root;

            var stack = new GenericStack<TreeNode>(input.Length);
            p = root;
            while(i < input.Length)
            {
                if(input[i] < p.Value)
                {
                    temp = new TreeNode();
                    temp.Value = input[i++];
                    p.Left = temp;
                    stack.Push(p);
                    p = temp;
                }
                else
                {
                    if(input[i] > p.Value && (stack.IsEmpty() || input[i] < stack.Peek().Value))
                    {
                        temp = new TreeNode();
                        temp.Value = input[i++];
                        p.Right = temp;
                        p = temp;
                    }
                    else
                    {
                        p = stack.Pop();
                    }
                }
            }

            return root;
        }
    }
}
