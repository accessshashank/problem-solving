using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
