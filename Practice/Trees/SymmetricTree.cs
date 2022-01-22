using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class SymmetricTree
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();
            var coll = LevelTraversal(root);
            var inverted = Invert(root);
            var coll2 = LevelTraversal(inverted);

            bool isSymmetric = true;
            for(int i=0; i<coll.Count;i++)
            {
                if(coll[i] != coll2[i])
                {
                    isSymmetric = false;
                    break;
                }
            }

            Console.WriteLine(isSymmetric);

            Console.WriteLine("Trying another approach !");
            Console.WriteLine("Creating Binary Tree ... !");
            root = BinaryTreeHelper.InitializeBinaryTreeV2();
            Console.WriteLine(IsSymmetricAnother(root));
        }

        private static bool IsSymmetricAnother(TreeNode<int> node)
        {
            if (node == null) return true;

            if (node.Left == null && node.Right == null) return true;

            if (node.Left != null && node.Right == null) return false;

            if (node.Left == null && node.Right != null) return false;

            var q1 = new Queue<TreeNode<int>>();
            var q2 = new Queue<TreeNode<int>>();

            q1.Enqueue(node.Left);
            q2.Enqueue(node.Right);

            while(q1.Count > 0 && q2.Count > 0)
            {
                var f1 = q1.Dequeue();
                var f2 = q2.Dequeue();

                if (f1.Left == null && f2.Right != null) return false;

                if (f1.Left != null && f2.Right == null) return false;

                if (f1.Right == null && f2.Left != null) return false;

                if (f1.Right != null && f2.Left == null) return false;

                if (f1.Value != f2.Value) return false;

                if(f1.Left != null) q1.Enqueue(f1.Left);
                if (f1.Right != null) q1.Enqueue(f1.Right);
                if (f2.Right != null) q2.Enqueue(f2.Right);
                if (f2.Left != null) q2.Enqueue(f2.Left);

            }

            return q1.Count == 0 && q2.Count == 0;
        }

        private static TreeNode<int> Invert(TreeNode<int> node)
        {
            if (node == null) return null;

            var left = Invert(node.Left);
            var right = Invert(node.Right);

            node.Right = left;
            node.Left = right;

            return node;
        }

        private static List<int> LevelTraversal(TreeNode<int> root)
        {
            var coll = new List<int>();
            var queue = new Queue<TreeNode<int>>();
            var node = root;

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                coll.Add(node.Value);
                if (node.Left != null)
                {

                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {

                    queue.Enqueue(node.Right);
                }
            }

            return coll;
        }
    }
}
