using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BinarySearchTree
{
    class RootToLeafPaths
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating binary search tree ... !");
            int[] input = new int[] { 9, 15, 5, 20, 16, 8, 12, 3, 6 };
            Console.Write("Input Array - ({0})", string.Join(",", input));
            var root = BinarySearchTreeHelper.InitializeBinarySearchTree(input);
            Console.WriteLine();
            /*
             *                                       9
             *                                   5        15
             *                                3     8   12    20
             *                                    6         16    
             * 
             */
            Console.WriteLine("Level Order Display");
            LevelOrderDisplay(root);
            List<int> paths = new List<int>();

            Console.WriteLine("Paths from root to leaf");
            RootToLeaf(root, paths);
        }

        private static void Display(List<int> paths)
        {
            foreach (var item in paths)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private static void RootToLeaf(TreeNode node, List<int> paths)
        {
            paths.Add(node.Value);
            if (node.Left == null && node.Right == null)
            {
                
                Display(paths);
                paths.Remove(node.Value);
                return;
            }

            if(node.Left != null)
            {
               // paths.Add(node.Value);
                RootToLeaf(node.Left, paths);
                //paths.Remove(node.Value);
            }

            if(node.Right != null)
            {
                //paths.Add(node.Value);
                RootToLeaf(node.Right, paths);
                //paths.Remove(node.Value);
            }

            paths.Remove(node.Value);
        }

        private static void LevelOrderDisplay(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
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
    }
}
