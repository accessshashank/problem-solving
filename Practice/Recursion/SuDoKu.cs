using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class SuDoKu
    {
        static void Main(string[] args)
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

            if (solve(board))
                Display(board);
            else
            {
                Console.WriteLine("Cant solve");
            }

            
        }

        private static void Display(int[,] board)
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

        private static bool solve(int[,] board)
        {
            int row = -1;
            int col = -1;
            bool isSolved = true;
            for(int i=0; i<9;i++)
            {
                for(int j=0; j<9; j++)
                {
                    if(board[i,j] == 0)
                    {
                        isSolved = false;
                        row = i;
                        col = j;
                        break;
                    }
                }
                if (isSolved == false) break;
            }

            //Console.WriteLine("Row {0} Col {1} is empty", row, col);

            if (isSolved == true) return true;

            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(board, row, col, num))
                {
                    //Console.WriteLine("Applied number {0} to Row {1} Col {2} is empty", num, row, col);
                    board[row, col] = num;

                    if (solve(board))
                    {
                       //Display(board);
                        //Console.WriteLine("--------------------");
                        return true;
                    }
                    /*
                    else
                    {
                        board[row, col] = 0;
                        Console.WriteLine("Row {0} Col {1} is reverted", row, col);
                    }
                    */
                }
            }

            board[row, col] = 0;
            return false;

        }

        private static bool IsSafe(int[,] board, int row, int col, int num)
        {
            for(int i=0; i<9; i++)
            {
                if (board[row, i] == num) return false; // check that row
            }

            for (int i = 0; i < 9; i++)
            {
                if (board[i, col] == num) return false; // check that column
            }

            int innerBoxRowIndex = row - row % 3;
            int innerBoxColIndex = col - col % 3;

            for(int i = innerBoxRowIndex; i<=innerBoxRowIndex+2; i++) // check inner box of size 3
            {
                for(int j= innerBoxColIndex; j <= innerBoxColIndex+2; j++)
                {
                    if (board[i, j] == num) return false;
                }
            }

            return true;
        }
    }
}
