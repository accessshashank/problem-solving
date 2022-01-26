using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BinarySearchTree
{
    class DeleteInBinarySearchTree
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
            Console.WriteLine("Deleting node 8");
            Delete(root, root, 8);
            Console.WriteLine("Inorder traversal ... !");
            InOrder(root);
            Console.WriteLine();
            Console.WriteLine("Deleting node 9");
            Delete(root, root, 9);
            Console.WriteLine("Inorder traversal ... !");
            InOrder(root);
            Console.WriteLine();

            Console.WriteLine("ANOTHER VERSION");

            Console.WriteLine("Creating binary search tree ... !");
            int[] input1 = new int[] { 9, 15, 5, 20, 16, 8, 12, 3, 6 };
            Console.Write("Input Array - ({0})", string.Join(",", input1));
            var root1 = BinarySearchTreeHelper.InitializeBinarySearchTree(input1);
            Console.WriteLine();
            Console.WriteLine("Inorder traversal ... !");
            InOrder(root1);
            Console.WriteLine();
            Console.WriteLine("Deleting node 8");
            DeleteV2(root1, 8);
            Console.WriteLine("Inorder traversal ... !");
            InOrder(root1);
            Console.WriteLine();
            Console.WriteLine("Deleting node 9");
            DeleteV2(root1, 9);
            Console.WriteLine("Inorder traversal ... !");
            InOrder(root1);
            Console.WriteLine();
        }

        private static TreeNode Delete(TreeNode root, TreeNode p, int key)
        {
            TreeNode q = null;

            if (p == null) return null;

            if(p.Left == null && p.Right == null)
            {
                if(p == root)
                {
                    root = null;
                }
                return null;
            }

            if(key > p.Value)
            {
                p.Right = Delete(root, p.Right, key);
            }
            else if (key < p.Value)
            {
                p.Left = Delete(root, p.Left, key);
            }
            else
            {
                if(Height(p.Left) > Height(p.Right))
                {
                    q = FindInorderPredecessor(p.Left);
                    p.Value = q.Value;
                    p.Left = Delete(root, p.Left, q.Value);
                }
                else
                {
                    q = FindInorderSuccessor(p.Right);
                    p.Value = q.Value;
                    p.Right = Delete(root, p.Right, q.Value);
                }
            }


            return p;
        }

        // InorderSuccessor is left most node of right subtree. See the input passed from calling function is right node (of p)
        private static TreeNode FindInorderSuccessor(TreeNode p)
        {
            while(p != null && p.Left != null)
            {
                p = p.Left;
            }
            return p;
        }

        //InorderPredecessor is the right most node of left subtree. See the input passed from calling function is left node (of p)
        private static TreeNode FindInorderPredecessor(TreeNode p)
        {
            while(p != null && p.Right != null)
            {
                p = p.Right;
            }
            return p;
        }

        private static int Height(TreeNode p)
        {
            if (p == null) return 0;
            int x = Height(p.Left);
            int y = Height(p.Right);
            if(x > y)
            {
                return x + 1;
            }
            return y + 1;
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

        private static TreeNode DeleteV2(TreeNode node, int key)
        {
            if(node == null)
            {
                return null;
            }

            if(node.Left == null && node.Right == null)
            {
                return null;
            }

            if(key > node.Value)
            {
                node.Right = DeleteV2(node.Right, key);
            }
            else if(key < node.Value)
            {
                node.Left = DeleteV2(node.Left, key);
            }
            else
            {
                if(HeightV2(node.Left) > HeightV2(node.Right))
                {
                    var pred = InOrderPredecessorV2(node.Left);
                    node.Value = pred.Value;
                    node.Left = DeleteV2(node.Left, pred.Value);
                }
                else
                {
                    var succ = InOrderSuccessorV2(node.Right);
                    node.Value = succ.Value;
                    node.Right = DeleteV2(node.Right, succ.Value);
                }
            }

            return node;
        }

        private static int HeightV2(TreeNode node)
        {
            if (node == null)
                return 0;

            int left = HeightV2(node.Left);
            int right = HeightV2(node.Right);

            return Math.Max(left, right) + 1;
        }

        private static TreeNode InOrderPredecessorV2(TreeNode node)
        {
            if(node != null && node.Right != null)
            {
                node = node.Right;
            }

            return node;
        }

        private static TreeNode InOrderSuccessorV2(TreeNode node)
        {
            if (node != null && node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }
}
