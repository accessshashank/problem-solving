using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Practice.Trees;
using System.Threading.Tasks;

namespace Practice
{
    class Revision
    {
        static void Main(string[] args)
        {

            //string str = "abcd";
            //Perm("", str);
            //Subsets("", str);
            //NQueens();
            //SuDoKu();
            //Console.WriteLine(IsBalancedParenthesis("((a+b)*(c+d)))"));
            //Console.WriteLine(InfixToPostfix("3*5+6/2-4"));
            //Console.WriteLine(EvalPostfix(InfixToPostfix("3*5+6/2-4")));

            /*
            bool[] visited = new bool[] { false, false, false, false, false, false, false};
            var graphAL = new Dictionary<int, int[]>() { 
                {1, new int[] {2, 3 } },
                {2, new int[] {4 } },
                {3, new int[] {5 } },
                {4, new int[] {6 } },
                {5, new int[] { } },
                {6, new int[] { }}
                 };
            int currentNode = 1;

            DFS(graphAL, currentNode, visited);
            Console.WriteLine();
            DFSUsingStack(graphAL, currentNode);
            Console.WriteLine();
            BFS(graphAL, currentNode);
            Console.WriteLine();
            Console.WriteLine(hasPathDFS(graphAL, 1, 5));
            Console.WriteLine();
            Console.WriteLine(hasPathBFS(graphAL, 1, 5));
            Console.WriteLine("CountConnectedComponents - " + CountConnectedComponents());
            Console.WriteLine("LargestComponent - " + LargestComponent());
            Console.WriteLine("ShortestPath " + ShortestPath());

            Console.WriteLine("Creating Binary Tree ... !");
            var root = BinaryTreeHelper.InitializeBinaryTree();
            Console.WriteLine("Sum - " + SumTree(root));

            Console.WriteLine("Minimum - " + Minimum(root));

            Console.WriteLine("MaxPathSum - " + MaxPathSum(root));
           
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            Console.WriteLine(string.Join(",",TwoSum(nums, target)));
             */

            //int x = int.MaxValue; //2147483647
            //300429827
            //int i = 122;
            //char ch = Convert.ToChar(i);
            // Console.WriteLine(ch);

            //int[][] input = new int [][] { new int[] {1, 0, 0, 0 }, new int[] {0, 0, 1, 1 }, new int[] {0, 0, 1, 1 } };
            //var a = GetMaxRow(input);

            //int[][] edges = new int[][] { new int[] { 0, 2 }, new int[] { 0, 5 }, new int[] { 2, 4 }, new int[] { 1, 6 }, new int[] { 5, 4 } };
            //int n = 7;
            //CountPairs(n, edges);

            /*
            int[][] grid = new int[][] { new int[] {2, 0, 0, 1 }, 
                                         new int[] {0, 3, 1, 0 }, 
                                         new int[] {0, 5, 2, 0 }, 
                                         new int[] {4, 0, 0, 2 } };

            CheckXMatrix(grid);

           var x = CountHousePlacements(2);
            

            int k = 3;
            int[] arr = new int[] {2, 5, 1, 8, 2, 9 ,1 };
            MaxSumSubArrayOfSizeK(arr, k);
            

            int k = 3;
            int[] arr = new int[] {12, -1, -7, 8, -15, 30, 16, 28 };
            FirstNegativeNumberInEveryWindowOfSizeK(arr, k);
            */

            string pattern = "aaba";
            string str = "aabaabaa";
            Console.WriteLine("CountOccurrancesOfAnangrams - " + CountOccurrancesOfAnangrams(str, pattern));

        }

        public static int CountOccurrancesOfAnangrams(string str, string pattern)
        {
            int ans = 0;
            int[] patternArray = new int[26];
            int[] stringArray = new int[26];

            for(int i=0; i < 26;i++)
            {
                patternArray[i] = 0;
                stringArray[i] = 0;
            }

            int window = pattern.Length;
            int left = 0; int right = 0;
            while(right < window)
            {
                
                patternArray[pattern[right] - 'a']++;
                right++;
            }

            left = 0;
            right = 0;

            while(right < str.Length)
            {
                stringArray[str[right] - 'a']++;
                if ((right - left + 1) < window)
                {
                    right++;
                }
                else if((right-left+1) == window)
                {
                    bool areEqual = Compare(stringArray, patternArray);
                    if(areEqual)
                    {
                        ans++;
                    }
                    right++;
                    stringArray[str[left] - 'a'] -= 1;
                    left++;
                }
            }
            return ans;
        }

        private static bool Compare(int[] first, int[] second)
        {
            for(int i =0; i < first.Length; i++)
            {
                if(first[i] != second[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static void FirstNegativeNumberInEveryWindowOfSizeK(int[] arr, int k)
        {
            var negatives = new List<int>();
            var answers = new List<int>();
            int i = 0;
            int j = 0;
            while(j < arr.Length)
            {
                if(arr[j] < 0)
                {
                    negatives.Add(arr[j]);
                }

                if((j - i + 1) < k)
                {
                    j++;
                }
                else if((j-i+1) == k)
                {
                    if(negatives.Count > 0)
                    {
                        answers.Add(negatives[0]);
                    }

                    if(arr[i] < 0)
                    {
                        negatives.RemoveAt(0);
                    }
                    i++;
                    j++;
                }
            }

            Console.WriteLine(string.Join(",", answers.ToArray()));
        }

        public static int MaxSumSubArrayOfSizeK(int[] arr, int k)
        {
            if (k >= arr.Length) return arr.Sum();

            int sum = 0;
            int maxSum = 0;
            for(int i = 0; i<k; i++)
            {
                sum += arr[i];
            }
            maxSum = sum;

            int first = 0;
            int last = k;
            while(last < arr.Length)
            {
                sum = sum + arr[last] - arr[first];
                maxSum = Math.Max(maxSum, sum);
                last++;
                first++;
            }

            return maxSum;
        }
        public static int CountHousePlacements(int n)
        {
            int[] plots = new int[n];
            int sum = PlaceHouse(plots, 0);
            return 2 * sum;
        }

        private static int PlaceHouse(int[] plots, int currentIndex)
        {
            if (currentIndex >= plots.Length) return 0;

            int putHouseInCurrentIndex = 1 + PlaceHouse(plots, currentIndex + 2);
            int skipCurrentIndex = PlaceHouse(plots, currentIndex + 1);

            return putHouseInCurrentIndex + skipCurrentIndex;
        }

        public static bool CheckXMatrix(int[][] grid)
        {
            if (grid == null || grid.Length == 0) return false;

            bool isDiagonalSatisfied = CheckDiagonal(grid);
            if (isDiagonalSatisfied == false) return false;
            bool isOthers = CheckOthers(grid);
            return isOthers;
        }

        private static bool CheckDiagonal(int[][] grid)
        {
            int j = grid.Length - 1;
            for (int i = 0; i < grid.Length; i++)
            {
                if (grid[i][i] == 0 || grid[i][j] == 0) return false;
                j--;
            }
            return true;
        }

        private static bool CheckOthers(int[][] grid)
        {
            int k = grid[0].Length - 1;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (i == j) continue;
                    if (j == k) continue;
                    if (grid[i][j] != 0) return false;
                   
                }
                k--;
            }
            return true;
        }
    

    public static long CountPairs(int n, int[][] edges)
        {
            if (n == 1) return 0;
            var visited = new Dictionary<int, bool>();
            var queue = new Queue<int>();


            int previousCount = 0;
            int currentCount = 0;
            long mult = 1;

            for (int node = 0; node < n; node++)
            {
                if (node == 1 && currentCount == n) return 0;

                if (currentCount > previousCount)
                {
                    mult = mult * (currentCount - previousCount);
                }

                previousCount = visited.Keys.Count();

                if (visited.ContainsKey(node) == false)
                {
                    queue.Enqueue(node);
                    visited.Add(node, true);
                }

                while (queue.Count > 0)
                {
                    var poppedNode = queue.Dequeue();

                    for (int i = 0; i < edges.Length; i++)
                    {
                        var temp = edges[i][0];
                        if (temp == poppedNode)
                        {
                            var adjacentNode = edges[i][1];
                            if (visited.ContainsKey(adjacentNode) == false)
                            {
                                queue.Enqueue(adjacentNode);
                                visited.Add(adjacentNode, true);
                            }
                        }
                    }
                }

                currentCount = visited.Keys.Count();
            }

            return mult;
        }

        public static int GetMaxRow(int[][] input)
        {
            int result = -1;

            for(int col = 0; col < input[0].Length; col++)
            {
                for(int row = 0; row < input.Length; row++)
                {
                    if(input[row][col] == 1)
                    {
                        result = row;
                        break;
                    }
                }
                if (result > -1) break;
            }

            return result;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static int longestSubsequence(string s1, int k)
        {
            
            var s = Reverse(s1);
            int ans = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '0')
                    ++ans;
                else if (i < 30)
                {
                    if (k >= (1 << i))
                    {
                        ++ans;
                        k -= (1 << i);
                    }
                }
            }
            return ans;
        }

        int minimumNumbers1(int num, int k)
        {
            if (num == 0) return num;
            for (int i = 1; i <= num; i++)
            {
                int contrib = k * i;
                int lft = num - contrib;
                if (lft < 0) return -1;
                if (lft % 10 == 0) return i;
            }
            return -1;
        }

        private static int MinimumNumbers(int num, int k)
        {
            if (num == 0)
                return 0;
            for (int i = 1; i <= 100; ++i)
            {
                if (k * i <= num && (k * i) % 10 == num % 10)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                dict.Add(nums[i], i);
            }

            Array.Sort(nums);

            int low = 0;
            int high = nums.Length - 1;
            while (low < high)
            {
                int sum = nums[low] + nums[high];
                if (sum == target) return new int[] { dict[low], dict[high] };

                if (sum < target)
                    low++;
                else
                    high--;

            }
            return new int[] { -1, -1 };
        }

        private static int MaxPathSum(TreeNode<int> node)
        {
            if (node == null) return 0;

            if(node.Left == null && node.Right == null)
            {
                return node.Value;
            }

            int left = MaxPathSum(node.Left);
            int right = MaxPathSum(node.Right);

            return node.Value + Math.Max(left, right);
        }

        private static int Minimum(TreeNode<int> node)
        {
            if (node == null) return int.MaxValue;

            var leftMin = Minimum(node.Left);
            var rightMin = Minimum(node.Right);

            return Math.Min(node.Value, Math.Min(leftMin, rightMin));
        }

        private static int SumTree(TreeNode<int> node)
        {
            if (node == null) return 0;

            int left = SumTree(node.Left);
            int right = SumTree(node.Right);

            return node.Value + left + right;
        }

        private static int ShortestPath()
        {
            var graphAL = new Dictionary<int, int[]>() {
                {1, new int[] {2, 5 } },
                {2, new int[] {1, 3 } },
                {3, new int[] {2 ,4 } },
                {4, new int[] {3, 5 } },
                {5, new int[] {4, 1 }}
                 };

            var dict = new Dictionary<int, bool>();

            var queue = new Queue<Tuple<int, int>>();
            int source = 1;
            int destination = 4;

            queue.Enqueue(Tuple.Create(source, 0));
            dict.Add(source, true);

            while(queue.Count > 0)
            {
                var item = queue.Dequeue();

                if (item.Item1 == destination) return item.Item2;

                foreach(int neighbour in graphAL[item.Item1])
                {
                    if(!dict.ContainsKey(neighbour))
                    {
                        queue.Enqueue(Tuple.Create(neighbour, item.Item2 + 1));
                        dict.Add(neighbour, true);
                    }
                    
                }

            }

            return -1;
        }

        private static int LargestComponent()
        {
            var graphAL = new Dictionary<int, int[]>() {
                {0, new int[] {8, 1, 5 } },
                {1, new int[] {0 } },
                {5, new int[] {0, 8 } },
                {8, new int[] {0 ,5 } },
                {2, new int[] {3, 4 } },
                {3, new int[] {2, 4 }},
                {4, new int[] {3, 2 }}
                 };

            var dict = new Dictionary<int, bool>();

            int max = 0;
            
            foreach (var node in graphAL.Keys)
            {
                max = Math.Max(max, CountNodes(graphAL, node, dict));
            }
            return max;
        }

        private static int CountNodes(Dictionary<int, int[]> graphAL, int node, Dictionary<int, bool> dict)
        {
            if (dict.ContainsKey(node) == true) return 0;

            dict[node] = true;
            int counter = 1;
            foreach (var item in graphAL[node])
            {
                counter = counter + CountNodes(graphAL, item, dict);
            }
            return counter;
        }

        private static int CountConnectedComponents()
        {
            var graphAL = new Dictionary<int, int[]>() {
                {0, new int[] {8, 1, 5 } },
                {1, new int[] {0 } },
                {5, new int[] {0, 8 } },
                {8, new int[] {0 ,5 } },
                {2, new int[] {3, 4 } },
                {3, new int[] {2, 4 }},
                {4, new int[] {3, 2 }}
                 };

            var dict = new Dictionary<int, bool>();
            int counter = 0;
            foreach (var node in graphAL.Keys)
            {
                if(Traverse(graphAL, node, dict) == true)
                {
                    counter++;
                }
            }
            return counter;
        }

        private static bool Traverse(Dictionary<int, int[]> graphAL, int node, Dictionary<int, bool> dict)
        {
            if (dict.ContainsKey(node)) return false;

            dict[node] = true;

            foreach (var item in graphAL[node])
            {
                Traverse(graphAL, item, dict);
            }
            return true;
        }

        private static void BFS(Dictionary<int, int[]> graphAL, int currentNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(currentNode);

            while(queue.Count > 0)
            {
                int node = queue.Dequeue();
                Console.Write(node + " ");
                foreach (var item in graphAL[node])
                {
                    queue.Enqueue(item);
                }
            }
        }

        private static void DFSUsingStack(Dictionary<int, int[]> graphAL, int currentNode)
        {
            var stack = new Stack<int>();
            stack.Push(currentNode);

            while(stack.Count > 0)
            {
                var node = stack.Pop();
                Console.Write(node + " ");
                foreach (var item in graphAL[node])
                {
                    stack.Push(item);
                }
            }
        }

        private static bool hasPathBFS(Dictionary<int, int[]> graphAL, int source, int destination)
        {
            if (source == destination) return true;

            var queue = new Queue<int>();
            queue.Enqueue(source);
            while(queue.Count > 0)
            {
                int item = queue.Dequeue();
                if (item == destination) return true;

                foreach (var node in graphAL[item])
                {
                    queue.Enqueue(node);
                }
            }
            return false;
        }

        private static bool hasPathDFS(Dictionary<int, int[]> graphAL, int source, int destination)
        {
            if (source == destination) return true;

            foreach (var item in graphAL[source])
            {
                if (hasPathDFS(graphAL, item, destination) == true)
                    return true;
            }
            return false;
        }

        private static void DFS(Dictionary<int,int[]> graphAL, int currentNode, bool[] visited)
        {
            Console.Write(currentNode + " ");
            visited[currentNode] = true;

            foreach (var node in graphAL[currentNode])
            {
                if(visited[node] == false)
                {
                    //visited[node] = true;
                    //Console.Write(node + " ");
                    DFS(graphAL, node, visited);
                }
            }
        }

        private static int EvalPostfix(string expression)
        {
            var stack = new Stack<int>();

            foreach (var ch in expression.ToCharArray())
            {
                if(IsOperand(ch))
                {
                    stack.Push(int.Parse(ch.ToString()));
                }
                else
                {
                    switch (ch)
                    {
                        case '+':
                            {
                                var right = stack.Pop();
                                var left = stack.Pop();
                                var val = left + right;
                                stack.Push(val);
                            }

                            break;
                        case '-':
                            {
                                var right = stack.Pop();
                                var left = stack.Pop();
                                var val = left - right;
                                stack.Push(val);
                            }

                            break;
                        case '*':
                            {
                                var right = stack.Pop();
                                var left = stack.Pop();
                                var val = left * right;
                                stack.Push(val);
                            }

                            break;
                        case '/':
                            {
                                var right = stack.Pop();
                                var left = stack.Pop();
                                var val = left / right;
                                stack.Push(val);
                            }

                            break;
                    }

                }
               
            }
            return stack.Pop();
        }

        private static bool IsBalancedParenthesis(string str)
        {
            var stack = new Stack<char>();

            foreach(var ch in str.ToCharArray())
            {
                if(ch == '(')
                {
                    stack.Push(ch);
                }
                else if(ch==')')
                {
                    if (stack.Count == 0) return false;
                    stack.Pop();
                }
            }

            if (stack.Count == 0) return true;
            else return false;
        }

        private static string InfixToPostfix(string expression)
        {
            string postfix = "";
            var stack = new Stack<char>();

            foreach (var ch in expression.ToArray())
            {
                if(IsOperand(ch))
                {
                    postfix += ch;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(ch);
                    }
                    else
                    {
                        var precedence = Precedence(ch);
                        while (stack.Count > 0 && Precedence(stack.Peek()) >= precedence)
                        {
                            postfix += stack.Pop();
                        }
                        stack.Push(ch);
                    }
                }
            }

            while(stack.Count > 0)
            {
                postfix += stack.Pop();
            }
            return postfix;
        }

        private static bool IsOperand(char ch)
        {
            if(ch == '+' || ch=='-' || ch=='*' || ch=='/')
            {
                return false;
            }
            return true;
        }

        private static int Precedence(char ch)
        {
            if(ch == '+' || ch=='-')
            {
                return 1;
            }
            if(ch=='*' || ch=='/')
            {
                return 2;
            }
            return 0;
        }

        private static void SuDoKu()
        {
            int[,] board = new int[9, 9] {
            {5, 3, 0, 0, 7, 0, 0, 0, 0 },
            {6, 0, 0, 1, 9, 5, 0, 0, 0 },
            {0, 9, 8, 0, 0, 0, 0, 6, 0 },
            {8, 0, 0, 0, 6, 0, 0, 0, 3 },
            {4, 0, 0, 8, 0, 3, 0, 0, 1 },
            {7, 0, 0, 0, 2, 0, 0, 0, 6 },
            {0, 6, 0, 0, 0, 0, 2, 8, 0 },
            {0, 0, 0, 4, 1, 9, 0, 0, 5 },
            {0, 0, 0, 0, 8, 0, 0, 7, 9 }
            };

            SolveSuDoKu(board, 0, 0);
        }

        private static bool SolveSuDoKu(int[,] board, int row, int col)
        {
            if(row == 9)
            {
                DisplaySudoKu(board);
                return true;
            }

            if(col == 9)
            {
                return SolveSuDoKu(board, row + 1, 0);
            }

            if(board[row, col] != 0)
            {
                return SolveSuDoKu(board, row, col + 1);
            }

            for(int num=1; num<=9;num++)
            {
                if(IsSafeForSuDoKu(board, row, col, num))
                {
                    board[row, col] = num;
                    bool IsSolved = SolveSuDoKu(board, row, col + 1);
                    if(IsSolved)
                    {
                        return true;
                    }
                }
            }
            board[row, col] = 0;
            return false;
        }

        private static bool IsSafeForSuDoKu(int[,] board, int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == num) return false; // check that row
            }

            for (int i = 0; i < 9; i++)
            {
                if (board[i, col] == num) return false; // check that column
            }

            int innerBoxRowIndex = row - row % 3;
            int innerBoxColIndex = col - col % 3;

            for (int i = innerBoxRowIndex; i <= innerBoxRowIndex + 2; i++) // check inner box of size 3
            {
                for (int j = innerBoxColIndex; j <= innerBoxColIndex + 2; j++)
                {
                    if (board[i, j] == num) return false;
                }
            }

            return true;
        }

        private static void DisplaySudoKu(int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void NQueens()
        {
            const int size = 4;
            bool[,] board = new bool[size, size] {
            {false, false, false, false },
            {false, false, false, false },
            {false, false, false, false },
            {false, false, false, false }
            };

            helper(board, size, 0);
        }

        private static void helper(bool[,] board, int size, int row)
        {
            // base case
            if(row == size)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(board[i, j] ? "Q" : "X");
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("------------------------");
                return;
            }

            for(int col = 0; col < size; col++)
            {
                if(IsSafe(board, size, row, col))
                {
                    board[row, col] = true;
                    helper(board, size, row + 1);
                    board[row, col] = false;
                }
            }
        }

        private static bool IsSafe(bool[,] board, int size, int row, int col)
        {
            //check in row
            for(int j=0; j<=3;j++)
            {
                if (board[row, j] == true)
                    return false;
            }

            //check in col
            for (int j = 0; j <= 3; j++)
            {
                if (board[j, col] == true)
                    return false;
            }

            // check along the diagonal
            int copyRow = row;
            int copyCol = col;

            while (copyRow >= 0 && copyCol >= 0)
            {
                if (board[copyRow, copyCol] == true) return false;
                copyRow--;
                copyCol--;
            }

            copyRow = row;
            copyCol = col;

            while (copyRow >= 0 && copyCol < size)
            {
                if (board[copyRow, copyCol] == true) return false;
                copyRow--;
                copyCol++;
            }

            return true;
        }

        private static void Subsets(string processed, string unprocessed)
        {
            if(string.IsNullOrEmpty(unprocessed))
            {
                Console.WriteLine(processed);
                return;
            }

            char ch = unprocessed[0];
            Subsets(processed + ch, unprocessed.Substring(1, unprocessed.Length - 1));
            Subsets(processed, unprocessed.Substring(1, unprocessed.Length - 1));
        }

        private static void Perm(string processed, string unProcesed)
        {
            if(string.IsNullOrEmpty(unProcesed))
            {
                Console.WriteLine(processed);
                return;
            }

            char ch = unProcesed[0];

            for (int i = 0; i <= processed.Length ; i++)
            {
                string first = processed.Substring(0, i);
                string second = processed.Length >= 1 ? processed.Substring(i, processed.Length - i) : "";
                Perm(first + ch + second, unProcesed.Substring(1, unProcesed.Length - 1));
            }
        }
    }
}
