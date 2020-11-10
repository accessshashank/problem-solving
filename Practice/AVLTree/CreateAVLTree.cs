using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.AVLTree
{
    // AVL trees are height balanced binary search tree, (height of node = height of left subtree - height of right  subtree)
    class CreateAVLTree
    {
        static void Main(string[] args)
        {
            var input = new int[] { 50, 10, 20};
            Console.WriteLine("Input array ({0})", string.Join(",", input));
            Console.WriteLine("Creating AVL Tree");
            var root = AVLTreeHelper.InitializeAVLTree(input);
        }
    }

    public class AVLTreeHelper
    {
        public static TreeNode InitializeAVLTree(int[] input)
        {
            TreeNode root = null;

            for (int i = 0; i < input.Length; i++)
            {
                root = InsertRecursive(root, root, input[i]);
            }

            return root;
        }

        public static TreeNode InsertRecursive(TreeNode root, TreeNode node, int key)
        {
            TreeNode t = null;
            if (node == null)
            {
                t = new TreeNode();
                t.Value = key;
                t.Height = 1;
                return t;
            }
            else
            {
                if (key > node.Value)
                {
                    node.Right = InsertRecursive(root, node.Right, key);
                }
                else
                {
                    node.Left = InsertRecursive(root, node.Left, key);
                }

                node.Height = Height(node);

                if(BalanceFactor(node) == 2 && BalanceFactor(node.Left) == 1)
                {
                    return LLRotation(root, node);
                }
                else if(BalanceFactor(node) == 2 && BalanceFactor(node.Left) == -1)
                {
                    return LRRotation(root, node);
                }
                else if (BalanceFactor(node) == -2 && BalanceFactor(node.Right) == -1)
                {
                    return RRRotation(root, node);
                }
                else if (BalanceFactor(node) == -2 && BalanceFactor(node.Right) == 1)
                {
                    return RLRotation(root, node);
                }
            }
            return node;
        }

        private static TreeNode RLRotation(TreeNode root, TreeNode p)
        {
            TreeNode pr = p.Right;
            TreeNode prl = pr.Left;
            pr.Left = prl.Right;
            p.Right = prl.Left;
            prl.Right = pr;
            prl.Left = p;

            p.Height = Height(p);
            pr.Height = Height(pr);
            prl.Height = Height(prl);

            if(root == p)
            {
                 root = prl;
            }

            return prl;
        }

        private static TreeNode RRRotation(TreeNode root, TreeNode p)
        {
            TreeNode pr = p.Right;
            TreeNode prl = pr.Left;

            pr.Left = p;
            p.Right = prl;

            pr.Height = Height(pr);
            p.Height = Height(p);

            if(p == root)
            {
                root = pr;
            }

            return pr;
        }

        private static TreeNode LRRotation(TreeNode root, TreeNode p)
        {
            TreeNode pl = p.Left;
            TreeNode plr = pl.Right;

            pl.Right = plr.Left;
            p.Left = plr.Right;
            plr.Left = pl;
            plr.Right = p;

            p.Height = Height(p);
            pl.Height = Height(pl);
            plr.Height = Height(plr);

            if(root == p)
            {
                root = plr;
            }

            return plr;
        }

        private static TreeNode LLRotation(TreeNode root, TreeNode p)
        {
            TreeNode pl = p.Left;
            TreeNode plr = pl.Right;

            pl.Right = p;
            p.Left = plr;
            pl.Height = Height(pl);
            p.Height = Height(p);

            if(p == root)
            {
                root = pl;
            }

            return pl;
        }

        private static int BalanceFactor(TreeNode node)
        {
            var left = node != null && node.Left != null ? node.Left.Height : 0;
            var right = node != null && node.Right != null ? node.Right.Height : 0;
            return left - right;
        }

        private static int Height(TreeNode node)
        {
            var x = 0; var y = 0;
            x = node != null && node.Left != null ? Height(node.Left) : 0;
            y = node != null && node.Right != null ? Height(node.Right) : 0;
            return (x > y) ? (x + 1) : (y + 1);
        }
    }


    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public int Height { get; set; }
        public int Value { get; set; }
        public TreeNode Right { get; set; }
    }
}
