using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Queue;

namespace Practice.Trees
{
    class CreateBinaryTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = InitializeBinaryTree();
            PreOrder(root);
            Console.WriteLine();
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
