using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Trees
{
    class KthLevelOfTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTreeV2();

            LevelOrderDisplay(root);

            int k = 2;
            var nodes = KthLevel(root, k);

            Console.WriteLine("Nodes at level {0} are :-",k);

            foreach (var item in nodes)
            {
                Console.Write(item.Value + " ");
            }

            Console.WriteLine();
        }

        private static void LevelOrderDisplay(TreeNode<int> root)
        {
            var queue = new Queue<TreeNode<int>>();
            var currentNode = root;
            queue.Enqueue(root);
            queue.Enqueue(null);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == null && queue.Count == 0)
                {
                    Console.WriteLine();
                    return;
                }
                else if (node == null)
                {
                    Console.WriteLine();
                    queue.Enqueue(null);
                    continue;
                }
                Console.Write(node.Value + " ");
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }

            }
        }

        private static List<TreeNode<int>> KthLevel(TreeNode<int> root, int k)
        {
            var nodes = new List<TreeNode<int>>();
            var queue = new Queue<TreeNode<int>>();
            queue.Enqueue(root);
            int level = 0;
            bool found = false;

            while(queue.Count > 0)
            {
                int size = queue.Count;
                while(size > 0)
                {
                    size--;
                    var node = queue.Dequeue();

                    if (level == k)
                    {
                        found = true;
                        nodes.Add(node);
                    }
                    else
                    {
                        if (node.Left != null) queue.Enqueue(node.Left);

                        if (node.Right != null) queue.Enqueue(node.Right);
                    }
                    
                }            

                level++;
                if (found) break;
            }
            return nodes;
        }
    }
}
