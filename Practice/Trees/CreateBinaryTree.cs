using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Queue;
using Practice.Stack;

namespace Practice.Trees
{
    class CreateBinaryTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = InitializeBinaryTree();
            Console.WriteLine("Preorder  Recursive ... !");
            PreOrder(root);

            Console.WriteLine();
            Console.WriteLine("Preorder  Iterative ... !");
            PreOrderIterative(root);

            Console.WriteLine();
            Console.WriteLine("Inorder  Recursive ... !");
            InOrder(root);

            Console.WriteLine();
            Console.WriteLine("Inorder  Iterative ... !");
            InOrderIterative(root);

            Console.WriteLine();
            Console.WriteLine("Postorder  Recursive ... !");
            PostOrder(root);

            Console.WriteLine();
            Console.WriteLine("Postorder  Iterative ... !");
            PostOrderIterative(root);
            Console.WriteLine();
        }

        private static void PreOrderIterative(TreeNode<int> node)
        {
            var stack = new GenericStack<TreeNode<int>>(50); // taking a fail safe size
            while(node != null || !stack.IsEmpty())
            {
                if(node != null)
                {
                    Console.Write("({0}), ", node.Value);
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    node = node.Right;
                }
            }
        }

        private static void PreOrder(TreeNode<int> node)
        {
            if(node != null)
            {
                Console.Write("({0}), ",node.Value);
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }

        private static void InOrderIterative(TreeNode<int> node)
        {
            var stack = new GenericStack<TreeNode<int>>(50); // taking a fail safe size
            while (node != null || !stack.IsEmpty())
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    Console.Write("({0}), ", node.Value);
                    node = node.Right;
                }
            }
        }

        private static void InOrder(TreeNode<int> node)
        {
            if (node != null)
            {
                
                InOrder(node.Left);
                Console.Write("({0}), ", node.Value);
                InOrder(node.Right);
            }
        }

        // There is a trick applied with -ve numbers, make sure tree nodes do not have -ve number anytime.
        private static void PostOrderIterative(TreeNode<int> node)
        {
            var stack = new GenericStack<TreeNode<int>>(50); // taking a fail safe size
            while (node != null || !stack.IsEmpty())
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    if(node.Value > 0)
                    {
                        node.Value = node.Value * -1;
                        stack.Push(node);
                        node = node.Right;
                    }
                    else
                    {
                        Console.Write("({0}), ", node.Value * -1);
                        node = null;
                    }
                }
            }
        }

        private static void PostOrder(TreeNode<int> node)
        {
            if (node != null)
            {
                PostOrder(node.Left);
                PostOrder(node.Right);
                Console.Write("({0}), ", node.Value);
            }
        }

        // value -1 means not to create node/child
        private static TreeNode<int> InitializeBinaryTree()
        {
            var queue = new GenericLLQueue<TreeNode<int>>();
            TreeNode<int> root = null;
            int val = 0;
            Console.Write("Enter value for Root Node : ");
            val = int.Parse(Console.ReadLine());

            root = new TreeNode<int>();
            root.Value = val;
            root.Left = null;
            root.Right = null;
            queue.Enqueue(root);

            while(!queue.IsEmpty())
            {
                var p = queue.Dequeue();

                Console.Write("Enter value for Left Child of Node ({0}) : ", p.Value);
                val = int.Parse(Console.ReadLine());
                if(val != -1)
                {
                    var leftChild = new TreeNode<int>();
                    leftChild.Value = val;
                    leftChild.Left = null;
                    leftChild.Right = null;
                    p.Left = leftChild;
                    queue.Enqueue(leftChild);
                }

                Console.Write("Enter value for Right Child of Node ({0}) : ", p.Value);
                val = int.Parse(Console.ReadLine());
                if (val != -1)
                {
                    var rightChild = new TreeNode<int>();
                    rightChild.Value = val;
                    rightChild.Left = null;
                    rightChild.Right = null;
                    p.Right = rightChild;
                    queue.Enqueue(rightChild);
                }
            }

            return root;
        }
    }

    public class TreeNode<T>
    {
        public TreeNode<T> Left { get; set; }
        public T Value { get; set; }
        public TreeNode<T> Right { get; set; }
    }
}
