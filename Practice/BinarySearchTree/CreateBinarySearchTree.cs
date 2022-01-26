using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BinarySearchTree
{
    class CreateBinarySearchTree
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
            Console.WriteLine();
            Console.WriteLine("Inserting new node with value 2");
            BinarySearchTreeHelper.InsertIterative(root, 2);
            Console.WriteLine("Inorder traversal ... !");
            InOrder(root);
            Console.WriteLine();
            Console.WriteLine("Searching a node with value 16 using iteration");
            Console.WriteLine("Found = {0}", SearchIterative(root, 16));
            Console.WriteLine("Searching a node with value 16 using recursion");
            Console.WriteLine("Found = {0}", SearchRecursive(root, 16));
            Console.WriteLine("Searching a node with value 56 using iteration");
            Console.WriteLine("Found = {0}", SearchIterative(root, 56));
            Console.WriteLine("Searching a node with value 56 using recursion");
            Console.WriteLine("Found = {0}", SearchRecursive(root, 56));
        }

        private static bool SearchRecursive(TreeNode node, int key)
        {
            if (node == null) return false;
            if (node.Value == key) return true;
            if (key > node.Value) return SearchRecursive(node.Right, key);
            else return SearchRecursive(node.Left, key);
        }

        private static bool SearchRecursiveV2(TreeNode node, int key)
        {
            if (node == null)
                return false;

            if (node.Value == key) return true;

            if (key > node.Value) return SearchRecursiveV2(node.Right, key);
            else return SearchRecursiveV2(node.Left, key);
        }

        private static bool SearchIterative(TreeNode root, int key)
        {
            var p = root;
            while(p != null)
            {
                if (p.Value == key) return true;
                if (key > p.Value) p = p.Right;
                else p = p.Left;
            }
            return false;
        }

        private static bool SearchIterativeV2(TreeNode root, int key)
        { 

            TreeNode temp = root;

            while(temp != null)
            {
                if(temp.Value == key)
                {
                    return true;
                }
                else if(key > temp.Value)
                {
                    temp = temp.Right;
                }
                else
                {
                    temp = temp.Left;
                }
            }

            return false;
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

    public class BinarySearchTreeHelper
    {
        public static TreeNode InitializeBinarySearchTree(int[] input)
        {
            var root = new TreeNode();
            root.Value = input[0];
            if (input.Length == 1) return root;

            for (int i=1; i< input.Length; i++)
            {
                // Both of below two are working
                //InsertIterative(root, input[i]);
                InsertRecursive(root, input[i]);
            }

            return root;
        }

        public static TreeNode InsertRecursive(TreeNode node, int key)
        {
            TreeNode t = null;
            if (node == null)
            {
                t = new TreeNode();
                t.Value = key;
                return t;
            }
            else
            {
                if (key > node.Value)
                {
                    node.Right = InsertRecursive(node.Right, key);
                }
                else
                {
                    node.Left = InsertRecursive(node.Left, key);
                }
            }
            return node;
        }

        public static TreeNode InsertRecursiveV2(TreeNode node, int key)
        {
            if(node == null)
            {
                TreeNode n = new TreeNode();
                n.Value = key;
                return n;
            }

            if(key > node.Value)
            {
                node.Right = InsertRecursiveV2(node.Right, key);
            }
            else
            {
                node.Left = InsertRecursiveV2(node.Left, key);
            }

            return node;
        }

        public static void InsertIterative(TreeNode root, int key)
        {
            TreeNode p = root;
            TreeNode q = null;
            while (p != null)
            {
                q = p;
                if (key > p.Value)
                {
                    p = p.Right;
                }
                else
                {
                    p = p.Left;
                }
            }

            if (key > q.Value)
            {
                var node = new TreeNode();
                node.Value = key;
                q.Right = node;
            }
            else
            {
                var node = new TreeNode();
                node.Value = key;
                q.Left = node;
            }
        }

        public static void InsertIterativeV2(TreeNode root, int key)
        {
            TreeNode p = root;
            TreeNode q = null;

            while(p != null)
            {
                q = p;

                if(key > p.Value)
                {
                    p = p.Right;
                }
                else
                {
                    p = p.Left;
                }
            }

            if(key > q.Value)
            {
                TreeNode n = new TreeNode();
                n.Value = key;
                q.Right = n;
            }
            else
            {
                TreeNode n = new TreeNode();
                n.Value = key;
                q.Left = n;
            }
        }
    }

    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public int Value { get; set; }
        public TreeNode Right { get; set; }
    }
}
