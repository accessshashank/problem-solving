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
            string str = "abcd";
            //Perm("", str);
            //Subsets("", str);
            //NQueens();
            SuDoKu();
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
